using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licenta
{
    public partial class home : Form
    {

        private List<String> alertsList = new List<String>();
        public home()
        {
            InitializeComponent();
            contentPanel.Controls.Add(homeTab.Instance);
            homeTab.Instance.BringToFront();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImportAttribute("user32.dll")]
        public static extern bool ReleaseCapture();



        private void configureButton_Click(object sender, EventArgs e)
        {
            this.contentLabel.Text = "Configure";
            configureButton.BackColor = Color.FromArgb(39, 63, 78);
            monitorButton.BackColor = Color.FromArgb(41, 53, 65);
            if (!contentPanel.Controls.Contains(configureTab.Instance(alertsList)))
            {
                contentPanel.Controls.Add(configureTab.Instance(alertsList));
                configureTab.Instance(alertsList).BringToFront();
            }
            else
            {
                configureTab.Instance(alertsList).BringToFront();
            }

        }

        private void headerPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void logoPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            Environment.Exit(1);
        }

        private void label3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            this.contentLabel.Text = "Home";
            configureButton.BackColor = Color.FromArgb(41, 53, 65);
            monitorButton.BackColor = Color.FromArgb(41, 53, 65);
            if (!contentPanel.Controls.Contains(homeTab.Instance))
            {
                contentPanel.Controls.Add(homeTab.Instance);
                homeTab.Instance.BringToFront();
            }
            else
            {
                homeTab.Instance.BringToFront();
            }
        }

        private void monitorButton_Click(object sender, EventArgs e)
        {
            this.contentLabel.Text = "Monitor";
            monitorButton.BackColor = Color.FromArgb(39, 63, 78);
            configureButton.BackColor = Color.FromArgb(41, 53, 65);
            if (!contentPanel.Controls.Contains(monitorTab.Instance(alertsList)))
            {
                contentPanel.Controls.Add(monitorTab.Instance(alertsList));
                monitorTab.Instance(alertsList).BringToFront();
            }
            else
            {
                monitorTab.Instance(alertsList).BringToFront();
            }
        }

        private void configureButton_MouseEnter(object sender, EventArgs e)
        {
            configureButton.ForeColor = Color.FromArgb(227, 126, 46);
        }

        private void configureButton_MouseLeave(object sender, EventArgs e)
        {
            configureButton.ForeColor = Color.Gray;
        }

        private void monitorButton_MouseEnter(object sender, EventArgs e)
        {
            monitorButton.ForeColor = Color.FromArgb(227, 126, 46);
        }

        private void monitorButton_MouseLeave(object sender, EventArgs e)
        {
            monitorButton.ForeColor = Color.Gray;
        }
    }
}
