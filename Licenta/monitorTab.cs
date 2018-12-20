using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Diagnostics;

namespace Licenta
{
    public partial class monitorTab : UserControl
    {
        private static monitorTab _instance;
        private List<String> alertsList;
        private Dictionary<string, Color> alertTypes = new Dictionary<string, Color>() { { "sqli", Color.Red } };


        public static monitorTab Instance(List<String> alertsList)
        {
            if (_instance == null)
                _instance = new monitorTab(alertsList);
            return _instance;
        }
        public monitorTab(List<String> alertsList)
        {
            this.alertsList = alertsList;
            InitializeComponent();
            Thread thread = new Thread(update_alertsList_loop);
            thread.Start();
        }

        public void update_alertsList()
        {
            this.monitorList.Items.Clear();
            foreach (var alert in alertsList)
            {
                string key = alert.Split(':')[0];
                //if (alertTypes.ContainsKey(key))
                //    this.monitorList.Items.Add(new Dictionary<string, object> { { "Text", alert},
                //                                                                { "ForeColor", alertTypes[key]}});
                //else
                //    this.monitorList.Items.Add(new Dictionary<string, object> { { "Text", alert } });
                this.monitorList.Items.Add(alert);
            }
        }
        public void update_alertsList_loop()
        {
            while (true)
            {
                if (this.monitorList.InvokeRequired)
                    this.Invoke(new MethodInvoker(() => this.monitorList.Items.Clear()));
                else
                    this.monitorList.Items.Clear();

                foreach (var alert in alertsList)
                {
                    string key = alert.Split(new[] { ':' }, 2)[0];

                    if (this.monitorList.InvokeRequired)
                        this.Invoke(new MethodInvoker(() => this.monitorList.Items.Add(alert)));
                    //if (alertTypes.ContainsKey(key))
                    //    this.Invoke(new MethodInvoker(() => this.monitorList.Items.Add(new Dictionary<string, object> { { "Text", alert},
                    //                                                                                                    { "ForeColor", alertTypes[key]}})));
                    //else
                    //{
                    //    this.Invoke(new MethodInvoker(() => this.monitorList.Items.Add(new Dictionary<string, object> { { "Text", alert },
                    //                                                                                                    { "ForeColor", Color.Black}})));
                    //}
                    else
                        this.monitorList.Items.Add(alert);
                    //    if (alertTypes.ContainsKey(key))
                    //    this.monitorList.Items.Add(new Dictionary<string, object> { { "Text", alert},
                    //                                                                    { "ForeColor", alertTypes[key]}});
                    //else
                    //    this.monitorList.Items.Add(new Dictionary<string, object> { { "Text", alert } });
                }

                Thread.Sleep(5000);
            }
        }
        private void listBox1_MouseDown(object sender, MouseEventArgs e)
        {
            this.monitorList.SelectedIndex = this.monitorList.IndexFromPoint(e.X, e.Y);

            if (e.Button == MouseButtons.Right & this.monitorList.SelectedIndex != -1)
            {
                string text = this.monitorList.GetItemText(this.monitorList.SelectedItem);
               

                this.alertsList.Remove(text);

                this.update_alertsList();
            }
        }

    }
}
