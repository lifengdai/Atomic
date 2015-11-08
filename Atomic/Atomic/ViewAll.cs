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
    public partial class ViewAll : Form
    {
        private const int COLUMNCOUNT = 7;

        private DealDatabaseOnServer ddos;
        private Detail dtl;

        public ViewAll()
        {
            init();
            populateData(null);
        }

        public ViewAll(List<List<string>> ltss)
        {
            init();
            this.Name = "Search Result";
            this.Text = "Search Result";
            populateData(ltss);
        }

        private void init()
        {
            InitializeComponent();
            ddos = new DealDatabaseOnServer();
        }

        private void populateData(List<List<string>> lls)
        {
            int count = 0;
            ddos.openConnection();
            foreach (List<string> ls in lls == null ? ddos.popAll() : lls)
            {
                dataGridView1.Rows.Add();
                for (int i = 0; i < COLUMNCOUNT; i++)
                {
                    dataGridView1.Rows[count].Cells[i].Value = ls[i];
                }
                count++;
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if ((e.ColumnIndex == 6) && (dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null))
            {
                dtl = new Detail(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value);
                dtl.Show();
            }
        }
    }
}
