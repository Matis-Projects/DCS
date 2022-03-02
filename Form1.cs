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
        //Form app = null;
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
            
            //tabcontrol
            //jc.Size = jc.Parent.Size;
            //app = jc;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*WebClient wc = new WebClient();
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
            }*/
        }

        private void treeView1_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text.StartsWith("Job Creator"))
            {
                TabPage tabPage = new TabPage("Job Creation ID:" + (tabControl1.TabCount + 1));

                jobcreation jc = new jobcreation();
                jc.MdiParent = this;
                jc.Parent = tabPage;
                jc.FormBorderStyle = FormBorderStyle.None;
                jc.Dock = DockStyle.Fill;
                jc.Show();
                tabControl1.TabPages.Add(tabPage);
            }else if (e.Node.Text.StartsWith("Category Creator"))
            {
                /*TabPage tabPage = new TabPage("Category Creation ID:" + (tabControl1.TabCount + 1));

                jobcreation jc = new jobcreation();
                jc.MdiParent = this;
                jc.Parent = tabPage;
                jc.FormBorderStyle = FormBorderStyle.None;
                jc.Dock = DockStyle.Fill;
                jc.Show();
                tabControl1.TabPages.Add(tabPage);*/
                MessageBox.Show("Disponible à la prochaine mise à jour!");
            }
        }

        /*private void Form1_SizeChanged(object sender, EventArgs e)
        {
            if (app != null)
            {
                app.Size = app.Parent.Size;
            }
            
        }*/
    }
}
