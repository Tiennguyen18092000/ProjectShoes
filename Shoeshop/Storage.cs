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
    public partial class Storage : Form
    {
        public Storage()
        {
            InitializeComponent();
        }

        private void homeToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Homepage().Show();
            this.Hide();
        }

        private void cateToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Cate().Show();
            this.Hide();
        }

        private void storageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Storage().Show();
            this.Hide();
        }

        private void logoutToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            new Login().Show();
            this.Hide();
        }

        private void Storage_Load(object sender, EventArgs e)
        {
            List<Stor> list = new StorBUS().GetAll();
            dataGridView3.DataSource = list;
        }

        private void dataGridView3_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridView3.SelectedRows.Count == 1)
            {
                int id = int.Parse(dataGridView3.SelectedRows[0].Cells["ID"].Value.ToString());
                Stor snk = new StorBUS().GetDetails(id);
                if (snk != null)
                {
                    txtid2.Text = snk.id.ToString();
                    txtsneakerid2.Text = snk.sneakerID.ToString();
                    txtquantity.Text = snk.quantity.ToString();
                    txtprice.Text = snk.price.ToString();
                    txtstatus.Text = snk.status;
                }
            }
        }

        private void btnadd3_Click(object sender, EventArgs e)
        {
            Stor snk = new Stor()
            {
                id = 0,
                sneakerID = int.Parse(txtsneakerid2.Text.Trim()),
                quantity = int.Parse(txtquantity.Text.Trim()),
                price = int.Parse(txtprice.Text.Trim()),
                status = txtstatus.Text

            };
            bool result = new StorBUS().Add(snk);
            if (result)
            {
                List<Stor> list = new StorBUS().GetAll();
                dataGridView3.DataSource = list;

            }
            else
            {
                MessageBox.Show("no value");
            }
        }

        private void btnup3_Click(object sender, EventArgs e)
        {
            
                Stor snk = new Stor()
                {
                    id = int.Parse(txtid2.Text.Trim()),
                    sneakerID = int.Parse(txtsneakerid2.Text.Trim()),
                    quantity = int.Parse(txtquantity.Text.Trim()),
                    price = int.Parse(txtprice.Text.Trim()),
                    status = txtstatus.Text


                };
                bool result = new StorBUS().Update(snk);
                if (result)
                {
                    List<Stor> list = new StorBUS().GetAll();
                    dataGridView3.DataSource = list;

                }
                else
                {
                    MessageBox.Show("no value");
                }
            
        }

        private void btndel3_Click(object sender, EventArgs e)
        {
            {
                DialogResult result = MessageBox.Show("Are you sure?", "CONFIRMATION", MessageBoxButtons.YesNo);
                if (result == DialogResult.Yes)
                {
                    int ID = int.Parse(txtid2.Text.Trim());
                    bool res = new CateBUS().Delete(ID);
                    if (res)
                    {
                        List<Stor> list = new StorBUS().GetAll();
                        dataGridView3.DataSource = list;

                    }
                    else
                    {
                        MessageBox.Show("no value");
                    }
                }
            }
        }

        private void comboBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            ComboBox cb = sender as ComboBox;

            if (!e.Handled && !cb.DroppedDown && (e.KeyChar != (char)Keys.Return) && (e.KeyChar != (char)Keys.Escape))
            {
                if ((cb.DropDownStyle == ComboBoxStyle.DropDownList) && ((cb.AutoCompleteMode == AutoCompleteMode.Suggest) || (cb.AutoCompleteMode == AutoCompleteMode.SuggestAppend)))
                {
                    cb.DroppedDown = true;
                }
            }

            

            

        }

    }
    }

