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

namespace Kollos3
{
    public partial class Form2 : Form
    {
        private bool Edit = false;
        private bool Add = false;
        private string Name, Owner, Type;

        public Form2()
        {
            InitializeComponent();
            MaximizeBox = false;
            Add = true;
        }

        public Form2(DataGridViewSelectedRowCollection selectedRows)
        {
            InitializeComponent();
            MaximizeBox = false;
            Edit = true;
            foreach (DataGridViewRow i in selectedRows)
            {
                textBox1.Text = i.Cells[2].Value.ToString(); Name = i.Cells[2].Value.ToString();
                comboBox1.SelectedItem = comboBox1.Items.Equals(i.Cells[1].Value.ToString()); Owner = i.Cells[1].Value.ToString();
                comboBox2.SelectedItem = comboBox2.Items.Equals(i.Cells[3].Value.ToString()); Type = i.Cells[3].Value.ToString();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            SqlServerDbAnimalsOwner animalsOwner = new SqlServerDbAnimalsOwner();
            comboBox1.DataSource = animalsOwner.AnimalsOwner();

            SqlServerDbAnimalsType animalsType = new SqlServerDbAnimalsType();
            comboBox2.DataSource = animalsType.AnimalsType();
        }

        //--OK
        private void button1_Click(object sender, EventArgs e)
        {
            //Add
            if (Add) {
                Add = false;
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text) &&
                    !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text))
                {
                    new SqlServerDbAddAnimal(textBox1.Text, comboBox1.Text, comboBox2.Text);
                } else {
                    MessageBox.Show("EROR, NULL!");
                }
            }
            //Edit
            if(Edit) {
                Edit = false;
                if (!string.IsNullOrEmpty(textBox1.Text) && !string.IsNullOrEmpty(comboBox1.Text) && !string.IsNullOrEmpty(comboBox2.Text) &&
                !string.IsNullOrWhiteSpace(textBox1.Text) && !string.IsNullOrWhiteSpace(comboBox1.Text) && !string.IsNullOrWhiteSpace(comboBox2.Text))
                {
                    new SqlServerDbEditAnimal(Name, Owner, Type, textBox1.Text, comboBox1.Text, comboBox2.Text);
                } else {
                    MessageBox.Show("EROR, NULL!");
                }
            }
            Close();
        }
        //--Cancel
        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
