using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DCFF
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void aProposDeLapplicationToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutBox ab = new AboutBox();
            ab.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            jobcreation jc = new jobcreation();
            jc.ShowDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            WebClient wc = new WebClient();
            try
            {
                string t = wc.DownloadString("https://api.matis-dev.cf/k.ok");
                if(t == "oui\n")
                {}
                else
                {
                    Application.Exit();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                //Application.Exit();
            }
        }
    }
}
