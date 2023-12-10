using System.Net.Sockets;
using MVThread;

namespace MVScan
{
    public partial class Main : Form
    {
        #region Fields (private)

        private readonly object _goodObj = new object();
        private readonly object _badObj = new object();
        private IRunner _runner;
        private string[] _seprators = new string[] { ",", "\r\n" };
        private List<string> _ipList = new List<string>();
        private List<Tuple<string, string>> _ipRangeList = new List<Tuple<string, string>>();
        private List<string> _portList = new List<string>();
        private int _good = 0, _bad = 0, _timeout = 3000;
        private ComboType _type = ComboType.ChangeUser;
        private bool _addedList = false;
        private bool _isStarted = false;
        private string _dateTime = string.Empty;

        #endregion

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _runner = new TaskRunner(false);
            _runner.OnStarted += _runner_OnStarted;
            _runner.OnStopped += _runner_OnStopped;
            _runner.OnCompleted += _runner_OnCompleted;
            _runner.OnConfig += _runner_OnConfig;
            cboType.SelectedIndex = 0;
            AllowControls(RunnerStatus.Idle);
        }

        private void btnIpRanges_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Title = "Open ip ranges list";
                open.Filter = "Text Files|*.txt";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    _ipList.Clear();
                    _ipRangeList.Clear();
                    listIpRanges.Items.Clear();
                    Task.Factory.StartNew(() =>
                    {
                        try
                        {
                            _addedList = false;
                            SetStatus("Please Wait...");
                            string source = File.ReadAllText(open.FileName);
                            string[] ipRanges = source.Split(_seprators, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                            foreach (string address in ipRanges)
                            {
                                var range = address.Split('-');
                                string start = range[0].Trim();
                                string end = range[1].Trim();
                                if (IPRange.IsValid(start, end))
                                {
                                    _ipRangeList.Add(new Tuple<string, string>(start, end));
                                    string[] ips = IPRange.GetRange(start, end);
                                    _ipList.AddRange(ips);
                                }
                            }
                            this.Invoke(() =>
                            {
                                foreach (var item in _ipRangeList)
                                {
                                    listIpRanges.Items.Add(new ListViewItem(new string[] { item.Item1, item.Item2 }));
                                }
                            });
                            _addedList = true;
                            SetStatus($"Your IPs list has been successfully added!");
                        }
                        catch (Exception ex)
                        {
                            SetStatus(ex.Message);
                        }
                    });
                }
            }
        }

        private void btnPortRanges_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog open = new OpenFileDialog())
            {
                open.Title = "Open port list";
                open.Filter = "Text Files|*.txt";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string source = File.ReadAllText(open.FileName);
                        string[] portRanges = source.Split(_seprators, StringSplitOptions.TrimEntries | StringSplitOptions.RemoveEmptyEntries);
                        _portList.Clear();
                        _portList.AddRange(portRanges);
                        listPortRanges.Items.Clear();
                        listPortRanges.Items.AddRange(portRanges);
                        SetStatus("Your port list has been successfully added!");
                    }
                    catch (Exception ex)
                    {
                        SetStatus(ex.Message);
                    }
                }
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_runner.IsRunning || _isStarted)
                return;

            if (_ipList.Count * _portList.Count > 0 && _addedList)
            {
                _isStarted = true;
                int bot = Convert.ToInt32(numBot.Value);
                pbProgress.Maximum = _ipList.Count * _portList.Count;

                Task.Factory.StartNew(() =>
                {
                    SetStatus("Please Wait...");
                    _runner.SetWordlist(_ipList, _portList, _type);
                    _runner.Start(bot);
                });
            }
            else
                SetStatus("Enter your ip and port range lists!");
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            if (!_runner.IsRunning)
                return;

            _isStarted = false;
            _runner.Stop();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboType.SelectedIndex)
            {
                case 0:
                    _type = ComboType.ChangeUser;
                    break;
                case 1:
                    _type = ComboType.ChangePass;
                    break;
                default:
                    _type = ComboType.ChangeUser;
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblIp.Text = _ipList.Count.ToString();
            lblPort.Text = _portList.Count.ToString();
            lblCount.Text = (_ipList.Count * _portList.Count).ToString();
            lblChecked.Text = (_good + _bad).ToString();
            lblGood.Text = _good.ToString();
            lblBad.Text = _bad.ToString();
            lblCpm.Text = _runner.CPM.ToString();
            lblElapsed.Text = _runner.Elapsed;
            pbProgress.Value = _good + _bad;
            lblProgress.Text = pbProgress.Maximum > 0 ? $"{Math.Round((double)((pbProgress.Value * 100) / pbProgress.Maximum))}%" : "0%";
        }

        #region Events

        private void _runner_OnStarted(object? sender, StartEventArgs e)
        {
            numBot.Value = e.Bot;
            _good = 0;
            _bad = 0;
            _timeout = Convert.ToInt32(numTimeout.Value);
            _isStarted = true;
            _dateTime = DateTime.Now.ToString("yyyy.MM.dd HH.mm.ss");
            Folder();
            SetStatus("Started checking!");
            AllowControls(_runner.RunnerStatus);
        }

        private void _runner_OnStopped(object? sender, StopEventArgs e)
        {
            _isStarted = false;
            SetStatus("Stopped checking!");
            AllowControls(_runner.RunnerStatus);
        }

        private void _runner_OnCompleted(object? sender, EventArgs e)
        {
            _isStarted = false;
            SetStatus("Completed checking!");
            AllowControls(_runner.RunnerStatus);
        }

        private ConfigStatus _runner_OnConfig(object sender, DataEventArgs e)
        {
            try
            {
                var address = e.Data.Split(':');
                string host = address[0].Trim();
                int port = int.Parse(address[1].Trim());
                using (var connectDoneEvent = new ManualResetEventSlim())
                {
                    using (TcpClient tcpClient = new TcpClient())
                    {
                        tcpClient.BeginConnect(host, port, ar =>
                        {
                            try
                            {
                                tcpClient.EndConnect(ar);
                            }
                            catch { }
                            connectDoneEvent.Set();
                        }, tcpClient);

                        if (!connectDoneEvent.Wait(_timeout))
                        {
                            tcpClient.Close();
                        }

                        if (tcpClient.Connected)
                        {
                            Good();
                            e.Save.WriteLine($"{Environment.CurrentDirectory}\\Result\\{_dateTime}\\Good.txt", e.Data);
                        }
                        else
                            Bad();
                    }
                }
            }
            catch (Exception ex)
            {
                Bad();
                e.Log.Write(ex.Message);
                e.Save.WriteLine($"{Environment.CurrentDirectory}\\Result\\{_dateTime}\\ToCheck.txt", e.Data);
            }
            return ConfigStatus.OK;
        }

        #endregion

        #region Methods (private)

        private void Good()
        {
            lock (_goodObj)
            {
                ++_good;
            }
        }

        private void Bad()
        {
            lock (_badObj)
            {
                ++_bad;
            }
        }

        private void SetStatus(string text)
        {
            this.Invoke(() =>
            {
                lblStatus.Text = $"Status : {text}";
            });
        }

        private void AllowControls(RunnerStatus status)
        {
            this.Invoke(() =>
            {
                if (status == RunnerStatus.Started)
                {
                    btnIpRanges.Enabled = false;
                    btnPortRanges.Enabled = false;
                    btnStart.Enabled = false;
                    btnStop.Enabled = true;
                    numBot.Enabled = false;
                    numTimeout.Enabled = false;
                    cboType.Enabled = false;
                }
                else
                {
                    btnIpRanges.Enabled = true;
                    btnPortRanges.Enabled = true;
                    btnStart.Enabled = true;
                    btnStop.Enabled = false;
                    numBot.Enabled = true;
                    numTimeout.Enabled = true;
                    cboType.Enabled = true;
                }
            });
        }

        private void Folder()
        {
            if (!Directory.Exists($"{Environment.CurrentDirectory}\\Result"))
                Directory.CreateDirectory($"{Environment.CurrentDirectory}\\Result");

            if (!Directory.Exists($"{Environment.CurrentDirectory}\\Result\\{_dateTime}"))
                Directory.CreateDirectory($"{Environment.CurrentDirectory}\\Result\\{_dateTime}");
        }

        #endregion
    }
}
