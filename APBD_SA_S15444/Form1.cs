using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DalDb;
using DalDb.Interfaces;

namespace Kollos3
{
    public partial class Form1 : Form
    {
        private IAnimalsDb db;
        public Form1(IAnimalsDb db)
        {
            InitializeComponent();
            this.db = db;
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            dataGridView1.DataSource = db.GetAnimals();
        }

        //--Add
        private void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
            dataGridView1.DataSource = null;
            dataGridView1.DataSource = db.GetAnimals();
            Form1_Load(null, null);
        }

        //--Edit
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                Form2 form2 = new Form2(dataGridView1.SelectedRows);
                form2.ShowDialog();
                dataGridView1.DataSource = null;
                dataGridView1.DataSource = db.GetAnimals();
                Form1_Load(null, null);
            }
        }

        //--Delete
        private void button3_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count >= 1)
            {
                if (MessageBox.Show("Are you sure to delete selected data?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    new SqlServerDbDeleteAnimal(dataGridView1.SelectedRows);
                    dataGridView1.DataSource = null;
                    dataGridView1.DataSource = db.GetAnimals();
                    Form1_Load(null, null);
                }
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button1_Click(null, null);
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button2_Click(null, null);
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            button3_Click(null, null);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            dataGridView1.Columns[0].HeaderText = "First name (owner)";
            dataGridView1.Columns[1].HeaderText = "Last name (owner)";
            dataGridView1.Columns[2].HeaderText = "Name of animal";
            dataGridView1.Columns[3].HeaderText = "Animal type";
            for (int i = 0; i < dataGridView1.ColumnCount; i++)
            {
                dataGridView1.Columns[i].Width = 123;
            }
        }
    }
}
