using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using MVThread;
using MVThread.Events;
using MVThread.Wordlist;

namespace MVScan
{
    public partial class Form1 : Form
    {
        IRunner _run;
        List<string> _ips = new List<string>();
        List<string> _ports = new List<string>();
        ComboType _comboType;
        int _good, _bad, _timeout;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            _run = new TaskRunner();
            _run.OnStarted += _run_OnStarted;
            _run.OnStopped += _run_OnStopped;
            _run.OnCompleted += _run_OnCompleted;
            _run.OnConfig += _run_OnConfig;
            cboType.SelectedIndex = 0;
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(txtRange.Text) && !string.IsNullOrEmpty(txtPort.Text))
                {
                    _ips.Clear();
                    _ports.Clear();
                    string[] ranges = GetArray(txtRange.Text.Trim());
                    string[] ports = GetArray(txtPort.Text.Trim());
                    foreach (var range in ranges)
                    {
                        if (!string.IsNullOrEmpty(range))
                        {
                            var array = range.Split('-');
                            string start = array[0].Trim();
                            string end = array[1].Trim();
                            string[] ips = IPRange.GetRange(start, end);
                            _ips.AddRange(ips);
                        }
                    }
                    _ports.AddRange(ports);
                    pbCount.Maximum = _ips.Count * _ports.Count;
                }
                else
                    MessageBox.Show("Please enter your IP range and port range!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch(Exception ex)
            {
                MessageBox.Show("Separators include '-' and ',' for example:\r\n\r\n127.0.0.0-127.0.0.255,10.0.0.0-10.0.0.255", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (_ips.Count > 0 && _ports.Count > 0)
            {
                int bot = Convert.ToInt32(numBot.Value);
                _run.SetWordlist(_ips, _ports, _comboType);
                _run.Start(bot);
            }
            else
                MessageBox.Show("IPs and ports must be calculated before starting!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            _run.Stop();
        }

        private void cboType_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (cboType.SelectedIndex)
            {
                case 0:
                    _comboType = ComboType.ChangeUser;
                    break;
                case 1:
                    _comboType = ComboType.ChangePass;
                    break;
                default:
                    _comboType = ComboType.ChangeUser;
                    break;
            }
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            lblIp.Text = $"IP : {_ips.Count}";
            lblPort.Text = $"Port : {_ports.Count}";
            lblCount.Text = $"Count : {_ips.Count * _ports.Count}";
            lblCheck.Text = $"Checked : {_good + _bad}";
            lblGood.Text = $"Good : {_good}";
            lblBad.Text = $"Bad : {_bad}";
            pbCount.Value = _good + _bad;
        }

        private void _run_OnStarted(object sender, StartEventArgs e)
        {
            pbCount.Value = 0;
            _good = 0;
            _bad = 0;
            _timeout = Convert.ToInt32(numTimeOut.Value);
        }

        private void _run_OnStopped(object sender, StopEventArgs e)
        {
            MessageBox.Show("Stopped!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void _run_OnCompleted(object sender, EventArgs e)
        {
            MessageBox.Show("Completed!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private Status _run_OnConfig(object sender, DataEventArgs e)
        {
            try
            {
                var array = e.Data.Split(':');
                string ip = array[0];
                int port = int.Parse(array[1]);
                IPEndPoint iep = new IPEndPoint(IPAddress.Parse(ip), port);
                using (Socket socket = new Socket(iep.AddressFamily, SocketType.Stream, ProtocolType.Tcp))
                {
                    var success = socket.BeginConnect(iep, null, null).AsyncWaitHandle.WaitOne(TimeSpan.FromSeconds(_timeout));
                    if (success)
                    {
                        _good++;
                        e.Save.WriteLine("Good.txt", e.Data);
                    }
                    else
                    {
                        _bad++;
                        e.Save.WriteLine("Bad.txt", e.Data);
                    }
                }
            }
            catch (Exception ex)
            {
                _bad++;
                e.Log.WriteLine(ex.Message);
                e.Save.WriteLine("ToCheck.txt", e.Data);
            }
            return Status.OK;
        }

        private string[] GetArray(string text)
        {
            string[] result = null;
            if (text.Contains(","))
            {
                result = text.Split(',');
            }
            else
            {
                result = new string[] { text };
            }
            return result;
        }
    }
}
