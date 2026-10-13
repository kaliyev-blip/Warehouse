using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Warehouse_system
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text) ||
                string.IsNullOrEmpty(textBox2.Text) ||
                string.IsNullOrEmpty(textBox3.Text) ||
                string.IsNullOrEmpty(textBox4.Text) ||
                string.IsNullOrEmpty(textBox5.Text) ||
                string.IsNullOrEmpty(textBox6.Text))
            {
                MessageBox.Show("Please enter value", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                dataGridView1.Rows.Add(textBox1.Text, textBox2.Text, textBox4.Text,
                    textBox3.Text, textBox5.Text, textBox6.Text);

                notifyIcon1.BalloonTipTitle = "Success";
                notifyIcon1.BalloonTipText = "Product add datebase";
                notifyIcon1.ShowBalloonTip(8000);
                notifyIcon1.Icon = SystemIcons.Information;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Are sure exit?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (d == DialogResult.Yes)
            {
                Close();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            toolTip1.Active = true;
            toolTip1.ToolTipTitle = "Information";
            toolTip1.ToolTipIcon = ToolTipIcon.Info;
            toolTip1.IsBalloon = true;
            toolTip1.SetToolTip(textBox7, "Please enter product name");

            textBox1.KeyPress += letter_KeyPress;
            textBox7.KeyPress += letter_KeyPress;
            textBox2.KeyPress += number_KeyPress;
            textBox3.KeyPress += number_KeyPress;
            textBox4.KeyPress += number_KeyPress;
            textBox5.KeyPress += number_KeyPress;
            textBox6.KeyPress += number_KeyPress;
        }

        private void letter_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && e.KeyChar != ' ')
                e.Handled = true;
        }

        private void number_KeyPress(object? sender, KeyPressEventArgs e)
        {
            if (!char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar))
                e.Handled = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                DialogResult d = MessageBox.Show("Are you sure delete product?", "Question", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (d == DialogResult.Yes)
                {
                    dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                    MessageBox.Show("Product delete", "Info", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select product", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.IsNewRow || row.Cells[0].Value == null)
                    continue;

                if (row.Cells[0].Value.ToString() == textBox7.Text)
                {
                    MessageBox.Show("Found");
                }
            }
        }
    }
}