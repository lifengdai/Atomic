using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Atomic
{
    public partial class Form1 : Form
    {
        private SearchForm sf;
        private ViewAll va;
        private Detail det;

        public Form1()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }

        private void btnCreateFam_Click(object sender, EventArgs e)
        {
            det = new Detail();
            det.Show();
        }

        private void btnSearchOrView_Click(object sender, EventArgs e)
        {
            sf = new SearchForm();
            sf.Activate();
            sf.Show();
            btnSearchOrView.Enabled = false;
            sf.Back = false;
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(sf.Back == true) {
                btnSearchOrView.Enabled = true;
                timer1.Stop();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            va = new ViewAll();
            va.Activate();
            va.Show();
        }
    }
}
