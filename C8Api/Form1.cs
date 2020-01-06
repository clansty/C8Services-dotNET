using ServiceStack.Redis;
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
            string baseAddress = "http://127.0.0.1:8308/";
            Microsoft.Owin.Hosting.WebApp.Start<Startup>(url: baseAddress);
        }

        private void notifyIcon1_MouseClick(object sender, MouseEventArgs e)
        {
            Show();
            label1.Text = new Homework().ToString();
        }

        [DllImport("user32.dll")]
        internal static extern bool SetProcessDPIAware();

        private void Form1_Shown(object sender, EventArgs e)
        {
            Hide();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Hide();
            e.Cancel = true;
        }

        private void 刷新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            notifyIcon1_MouseClick(null, null);
        }

        private void 编辑作业ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FrmEdit().Show();
        }
    }
}