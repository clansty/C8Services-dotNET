using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace C8Api
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            SetProcessDPIAware();
            notifyIcon1.Visible = true;
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
        }

        private void Form1_Shown(object sender, EventArgs e)
        {
            
        }



        [DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();

        }
}