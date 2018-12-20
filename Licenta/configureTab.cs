using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Text.RegularExpressions;
using System.Diagnostics;
using System.IO;
using System.Threading;

namespace Licenta
{
    public partial class configureTab : UserControl
    {
        private static configureTab _instance;
        private String port_listen = "";
        private String port_server = "";
        private String ip_server = "";
        private List<String> alertsList;
        private Process process;
        private List<String> ip_listen = new List<String>();
        private static readonly Regex validIpV4AddressRegex = new Regex(@"^(([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5]).){3}([0-9]|[1-9][0-9]|1[0-9]{2}|2[0-4][0-9]|25[0-5])$", RegexOptions.IgnoreCase);
        public static configureTab Instance(List<String> alertsList)
        {

                if (_instance == null)
                    _instance = new configureTab(alertsList);
                return _instance;

           
        }
        public configureTab(List<String> alertsList)
        {
            this.alertsList = alertsList;
            InitializeComponent();
        }

        private void configureTab_Paint(object sender, PaintEventArgs e)
        {
            Graphics line = e.Graphics;
            Pen p = new Pen(Color.Gray, 1);
            line.DrawLine(p, 90, 165, 550, 165);
            line.DrawLine(p, 100, 18, 550, 18);
            line.Dispose();
        }
        public static bool IsIpV4AddressValid(string address)
        {
            if (!string.IsNullOrWhiteSpace(address))
            {
                return validIpV4AddressRegex.IsMatch(address.Trim());
            }

            return false;
        }
        private void saveButton_Click(object sender, EventArgs e)
        {
            string ip = this.serverIPText.Text;
            string port = this.serverPortText.Text; // 65535
            int port_int;
            try
            {
                port_int = Int32.Parse(port);
                if (port_int < 1 || port_int > 65535)
                    throw new System.FormatException();

                if (IsIpV4AddressValid(ip))
                {
                    this.port_server = port;
                    this.ip_server = ip;
                    this.serverAddressText.Text = ip + ':' + port;
                    this.serverPortText.Text = "";
                    this.serverIPText.Text = "";
                }
                else
                {
                    //this.serverIPText.Text = "";
                    System.Windows.Forms.MessageBox.Show("Invalid address!");
                }
                
            }
            catch (FormatException)
            {
                //this.serverPortText.Text = "";
                System.Windows.Forms.MessageBox.Show("Invalid port!");
            }
             
        }
        private void update_lisatenList()
        {
            this.listenList.Items.Clear();
            foreach (var ip in ip_listen)
            {
                this.listenList.Items.Add(ip + ":" + this.port_listen);
            }
        }
        private void addIPButtonn_Click(object sender, EventArgs e)
        {
            string ip = this.listenIPText.Text;


            if (IsIpV4AddressValid(ip))
            {
                if (!this.ip_listen.Contains(ip))
                    this.ip_listen.Add(ip);
                this.update_lisatenList();
                this.listenIPText.Text = "";
            }
            else
            {
                //this.serverIPText.Text = "";
                System.Windows.Forms.MessageBox.Show("Invalid address!");
            }
        }

        private void setPortButton_Click(object sender, EventArgs e)
        {
            string port = this.listenPortText.Text; // 65535
            int port_int;
            try
            {
                port_int = Int32.Parse(port);
                if (port_int < 1 || port_int > 65535)
                    throw new System.FormatException();
                this.port_listen = port;
                this.update_lisatenList();

            }
            catch (FormatException)
            {
                //this.listenPortText.Text = "";
                System.Windows.Forms.MessageBox.Show("Invalid port!");
            }
        }
        public void startProxy(string args)
        {

            ProcessStartInfo start = new ProcessStartInfo();
            start.FileName = "C:\\Python27\\python.exe";
            start.Arguments = args;
            start.UseShellExecute = false;
            start.CreateNoWindow = true;
            start.RedirectStandardOutput = true;
            start.RedirectStandardError = true;
            process = Process.Start(start);
            ChildProcessTracker.AddProcess(process);

            string output;
            while (!process.StandardOutput.EndOfStream)
            {
                if (!process.StandardOutput.EndOfStream)
                {
                    output = process.StandardOutput.ReadLine();
                    //Debug.WriteLine(output);
                    if (output.StartsWith("blocked-->"))
                    {
                        string alert = output.Split(new string[] { "-->" }, StringSplitOptions.None)[1];
                        this.alertsList.Add(alert);
                    }
                    if (output.StartsWith("Error: "))
                    {
                        if (this.start_stopButton.InvokeRequired)
                            this.Invoke(new MethodInvoker(() => this.start_stopButton.Text = "start"));
                        else
                            this.start_stopButton.Text = "start";
                        MessageBox.Show(output);
                        if (!process.HasExited)
                            process.Kill();
                        return;
                    }
                }
            }
            if (!process.StandardError.EndOfStream)
            {
                output = process.StandardError.ReadLine();
                Debug.WriteLine(output);
                MessageBox.Show(output);
                if (this.start_stopButton.InvokeRequired)
                    this.Invoke(new MethodInvoker(() => this.start_stopButton.Text = "start"));
                else
                    this.start_stopButton.Text = "start";
                if (!process.HasExited)
                    process.Kill();
            }

        }
        private void start_stopButton_Click(object sender, EventArgs e)
        {
            if (this.start_stopButton.Text.Equals("start"))
            {

                if (this.port_server.Equals(""))
                {
                    this.warningLabel.Text = "No server port was set";
                    return;
                }
                if (this.port_server.Equals(""))
                {
                    this.warningLabel.Text = "No server ip was set";
                    return;
                }

                if (this.port_listen.Equals(""))
                {
                    this.warningLabel.Text = "No listen port was set";
                    return;
                }
                if (!this.ip_listen.Any())
                {
                    this.warningLabel.Text = "No listen ip was set";
                    return;
                }

                this.warningLabel.Text = "";

                string cmd = Path.Combine(Environment.CurrentDirectory, @"server\proxy.py");
                string args = "-c " + Path.Combine(Environment.CurrentDirectory, @"server\server.crt") + 
                    " -k " + Path.Combine(Environment.CurrentDirectory, @"server\server.key") +
                    " -m " + Path.Combine(Environment.CurrentDirectory, @"server\sqli.model") +
                    " --server-ip " + this.ip_server + " --server-port " + this.port_server
                    + " --listen-ip [";
                foreach (var ip in ip_listen)
                    args += "'" + ip + "',";
                args = args.Remove(args.Length - 1);
                args += "] --listen-port " + this.port_listen;
                string arguments = string.Format("-u {0} {1}", cmd, args);

                Thread thread = new Thread(() => startProxy(arguments));
                thread.Start();


                this.alertsList.Clear();
                this.start_stopButton.Text = "stop";
            }
            else
            {
                if (!process.HasExited)
                    process.Kill();
                this.start_stopButton.Text = "start";
            }
        }


        private void listenList_MouseDown(object sender, MouseEventArgs e)
        {
            listenList.SelectedIndex = listenList.IndexFromPoint(e.X, e.Y);

            if (e.Button == MouseButtons.Right & listenList.SelectedIndex != -1)
            {
                string text = listenList.GetItemText(listenList.SelectedItem);
                string ip = text.Split(':')[0];

                this.ip_listen.Remove(ip);

                this.update_lisatenList();
            }
        }
    }
}
