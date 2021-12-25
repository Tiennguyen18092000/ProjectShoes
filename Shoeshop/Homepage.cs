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
    public partial class Homepage : Form
    {
        public Homepage()
        {
            InitializeComponent();
        }

        

        private void logoutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void homeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Homepage().Show();
            this.Hide();
        }

        private void cateToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new Cate().Show();
            this.Hide();
        }

        private void storageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            
        }

        private void storageToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            new Storage().Show();
            this.Hide();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Homepage_Load(object sender, EventArgs e)
        {
            List<Sneaker> list = new HomepageBUS().GetAll();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count == 1)
            {
                int id = int.Parse(dataGridView1.SelectedRows[0].Cells["ID"].Value.ToString());
                Sneaker emp = new HomepageBUS().GetDetails(id);
                if (emp != null)
                {
                    txtid.Text = emp.id.ToString();
                    txtcateid.Text = emp.cateid.ToString();
                    txtname.Text = emp.name;
                    txtdetail.Text = emp.detail;
                }
            }
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            Sneaker snk = new Sneaker()
            {
                id = 0,
                cateid = int.Parse(txtcateid.Text.Trim()),
                name = txtname.Text.Trim(),
                detail = txtdetail.Text.Trim(),
                

            };
            bool result = new HomepageBUS().Add(snk);
            if (result)
            {
                List<Sneaker> list = new HomepageBUS().GetAll();
                dataGridView1.DataSource = list;

            }
            else
            {
                MessageBox.Show("no value");
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            Sneaker snk = new Sneaker()
            {
                id = int.Parse(txtid.Text.Trim()),
                cateid = int.Parse(txtcateid.Text.Trim()),
                name = txtname.Text.Trim(),
                detail = txtdetail.Text.Trim(),

            };
            bool result = new HomepageBUS().Update(snk);
            if (result)
            {
                List<Sneaker> list = new HomepageBUS().GetAll();
                dataGridView1.DataSource = list;

            }
            else
            {
                MessageBox.Show("no value");
            }
        }

        private void btndelete_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure?", "CONFIRMATION", MessageBoxButtons.YesNo);
            if (result == DialogResult.Yes)
            {
                int ID = int.Parse(txtid.Text.Trim());
                bool res = new HomepageBUS().Delete(ID);
                if (res)
                {
                    List<Sneaker> list = new HomepageBUS().GetAll();
                    dataGridView1.DataSource = list;

                }
                else
                {
                    MessageBox.Show("no value");
                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            String keyword = textBox1.Text.Trim();
            List<Sneaker> employees = new HomepageBUS().Search(keyword);
            dataGridView1.DataSource = employees;
        }
    }
}
