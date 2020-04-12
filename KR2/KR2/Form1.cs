using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KR2
{
    public partial class Form1 : Form
    {
        task_n2 Z2;

        public Form1()
        {
            InitializeComponent();
            dataGridView1.Columns.Add(" "," ");
            dataGridView1.Rows.Add();
            Z2 = new task_n2(richTextBox1);
        }

        private void Add_2_Click(object sender, EventArgs e)
        {
            
            dataGridView1.Columns.Add(" ", " ");
        }

        private void Delete_2_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.Columns.RemoveAt(dataGridView1.Columns.Count - 1);
            }
            catch { }
        }

        private void Strart_2_Click(object sender, EventArgs e)
        {
            Z2.M1 = new int[dataGridView1.Columns.Count];

            for (int i = 0; i < dataGridView1.Columns.Count; i++)
            {
                Z2.M1[i] = Convert.ToInt32(dataGridView1[i,0].Value);
            }

            Z2.MCH();
        }
    }
}
