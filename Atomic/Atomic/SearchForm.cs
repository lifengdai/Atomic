using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Atomic
{
    public partial class SearchForm : Form
    {
        private bool back;
        private bool isDetail;

        private DealDatabaseOnServer ddos;
        private ViewAll va;

        private List<Tuple<string, string>> thingsNeedSearch;
        private string lastT;
        private string lastTT;

        public SearchForm()
        {
            InitializeComponent();
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            back = false;

            isDetail = false;
            thingsNeedSearch = new List<Tuple<string, string>>();
            ddos = new DealDatabaseOnServer();
            lastT = "";
            lastTT = "";
            timer1.Start();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public bool Back
        {
            get { return back; }
            set { back = value; }
        }

        private void SearchForm_FormClosing(object sender, EventArgs e)
        {
            back = true;
        }

        

        private void btnsearch_Click(object sender, EventArgs e)
        {
            if (isDetail)
            {

            }
            else
            {
                if (txtbName.Text != "")
                {
                    thingsNeedSearch.Add(Tuple.Create("familyName", txtbName.Text));
                }
                //else
                //{
                //    thingsNeedSearch.Add(Tuple.Create("familyName", "1+1"));
                //}
                if (txtbSuburb.Text != "")
                {
                    thingsNeedSearch.Add(Tuple.Create("suburb", txtbSuburb.Text));
                }
                //else
                //{
                //    thingsNeedSearch.Add(Tuple.Create("suburb", "1+1"));
                //}
                if (txtbAddress.Text != "")
                {
                    thingsNeedSearch.Add(Tuple.Create("address", txtbAddress.Text));
                }
                //else
                //{
                //    thingsNeedSearch.Add(Tuple.Create("address", "1+1"));
                //}
            }
                ddos.openConnection();
                va = new ViewAll(ddos.Search(thingsNeedSearch));
                thingsNeedSearch.Clear();
                va.Show();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            autoDropDown(txtbName.Text, dataGridView1, ref lastT, "familyName");
            autoDropDown(txtbAddress.Text,dataGridView2, ref lastTT, "address");
        }

        private void autoDropDown(string text, DataGridView dgv, ref string last, string row)
        {
            if (text != "")
            {
                if (text != last)
                {
                    dgv.Visible = true;
                    dgv.Rows.Clear();
                    ddos.openConnection();

                    foreach (string s in ddos.autosearch(row, text))
                    {
                        dgv.Rows.Add(s);
                    }
                    last = text;
                }
            }
            else
            {
                dgv.Visible = false;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtbName.Text = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }

        private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                txtbAddress.Text = dataGridView2.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
            }
        }
    }
}
