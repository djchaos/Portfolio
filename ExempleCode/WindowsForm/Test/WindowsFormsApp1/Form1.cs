using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private Customers currCustomer;

        public Form1()
        {
            InitializeComponent();
            Customers.InitializeDB();
            LoadAll();
        }

        private void LoadAll()
        {
            List<Customers> customer = Customers.GetCustomers();

            listView1.Items.Clear();

            foreach (Customers c in customer)
            {
                ListViewItem item = new ListViewItem(new String[] { c.CustNo.ToString(), c.Name, c.Phone, c.Email });
                item.Tag = c;

                listView1.Items.Add(item);
            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void folderBrowserDialog2_HelpRequest(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                ListViewItem item = listView1.SelectedItems[0];
                currCustomer = (Customers)item.Tag;

            }
        }

        private void button4_Click(object sender, EventArgs e) // save button
        {
            String n = textBox2.Text;
            String a = textBox3.Text;
            String p = textBox4.Text;
            String em = textBox5.Text;
            String w = textBox6.Text;

            if (String.IsNullOrEmpty(n) || String.IsNullOrEmpty(p))
            {
                MessageBox.Show("empty name or phone");
                return;
            }

            currCustomer.Update(n, a, p, em, w);

            LoadAll();
        }

        private void button1_Click(object sender, EventArgs e) // add button
        {
            int c_no = int.Parse(textBox1.Text);
            String n = textBox2.Text;
            String a = textBox3.Text;
            String p = textBox4.Text;
            String em = textBox5.Text;
            String w = textBox6.Text;

            if (c_no == null ||String.IsNullOrEmpty(n) || String.IsNullOrEmpty(p))
            {
                MessageBox.Show("empty name, phone or customerNo");
                return;
            }

            currCustomer = Customers.Add(c_no, n, a, p, em, w);

            LoadAll();
        }

        private void button5_Click(object sender, EventArgs e) // delete button
        {
            if (currCustomer == null)
            {
                MessageBox.Show("no customer selected");
                return;
            }

            DialogResult areYouSure = MessageBox.Show("are you sure do you want to delete this customer ?","Delete", MessageBoxButtons.YesNo);
            if (areYouSure == DialogResult.Yes)
            {
                currCustomer.Delete();
                LoadAll();
            }
        }

        private void button2_Click(object sender, EventArgs e) // edit button
        {
            if (currCustomer != null)
            {
                textBox1.Text = currCustomer.CustNo.ToString();
                textBox2.Text = currCustomer.Name;
                textBox3.Text = currCustomer.Adress;
                textBox4.Text = currCustomer.Phone;
                textBox5.Text = currCustomer.Email;
                textBox6.Text = currCustomer.WebSite;
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
