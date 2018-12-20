using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Licenta
{
    public partial class homeTab : UserControl
    {
        private static homeTab _instance;
        public static homeTab Instance
        {
            get
            {
                if (_instance == null)
                    _instance = new homeTab();
                return _instance;

            }
        }
        public homeTab()
        {
            InitializeComponent();
        }
    }
}
