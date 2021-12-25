using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Shoeshop
{
    public partial class Cate : Form
    {
        public Cate()
        {
            InitializeComponent();
        }

        

        private void homeToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Homepage().Show();
            this.Hide();
        }

        private void cateToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Cate().Show();
            this.Hide();
        }

        private void storageToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Storage().Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void Cate_Load(object sender, EventArgs e)
        {
            List<Category> list = new CateBUS().GetAll();
            dataGridView2.DataSource = list;
        }

        private void dataGridView2_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView2.SelectedRows.Count == 1)
            {
                int id = int.Parse(dataGridView2.SelectedRows[0].Cells["ID"].Value.ToString());
                Category snk = new CateBUS().GetDetails(id);
                if (snk != null)
                {
                    txtid1.Text = snk.id.ToString();
                    
                    txtname1.Text = snk.Name;
                    
                }
            }
        }
        private void btnadd1_Click(object sender, EventArgs e)
        {
            Category snk = new Category()
            {
                id = 0,          
                Name = txtname1.Text.Trim(),
            };
            bool result = new CateBUS().Add(snk);
            if (result)
            {
                List<Category> list = new CateBUS().GetAll();
                dataGridView2.DataSource = list;

            }
            else
            {
                MessageBox.Show("no value");
            }
        }

        private void btnup_Click(object sender, EventArgs e)
        {
            Category snk = new Category()
            {
                id = int.Parse(txtid1.Text.Trim()),
               
                Name = txtname1.Text.Trim(),
                

            };
            bool result = new CateBUS().Update(snk);
            if (result)
            {
                List<Category> list = new CateBUS().GetAll();
                dataGridView2.DataSource = list;

            }
            else
            {
                MessageBox.Show("no value");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int ID = int.Parse(txtid1.Text.Trim());
                bool res = new CateBUS().Delete(ID);
                if (res)
                {
                    List<Category> list = new CateBUS().GetAll();
                    dataGridView2.DataSource = list;

                }
                else
                {
                    MessageBox.Show("no value");
                }
            }
        }

        private void btnsearch1_Click(object sender, EventArgs e)
        {
            String keyword = textBox5.Text.Trim();
            List<Category> employees = new CateBUS().Search(keyword);
            dataGridView2.DataSource = employees;
        }
    }
}
