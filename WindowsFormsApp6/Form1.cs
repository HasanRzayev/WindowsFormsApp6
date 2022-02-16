using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp6
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        class Product
        {
            public Product(string productname, string country, string cost)
            {
                this.productname = productname;
                this.country = country;
                this.cost = cost;
            }

            public string productname { get; set; }
            public string country { get; set; }

            public string cost { get; set; }
            public override string ToString() => $"Product name----{productname}------country----{country}----cost---{cost}";
          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form_system form2 = new Form_system();
   
            if (form2.ShowDialog() == DialogResult.OK)
            {
                if (form2.textBox1.Text != null && form2.textBox2.Text != null && form2.textBox3.Text != null)
                {
                    listBox1.Items.Add(new Product(form2.textBox1.Text, form2.textBox2.Text, form2.textBox3.Text));
                }
            }

            //var humans = JsonConvert.SerializeObject(listBox1.items, Newtonsoft.Json.Formatting.Indented);
            //File.WriteAllText($"products.json", humans);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form_system form2 = new Form_system();

            if (listBox1.SelectedItem != null)
            {
                foreach (var item in listBox1.Items)
                {
                    if (listBox1.SelectedItem == item)
                    {
                        form2.textBox1.Text = (item as Product).productname;
                        form2.textBox2.Text = (item as Product).country;
                        form2.textBox3.Text = (item as Product).cost;
                    }
                }
                if (form2.ShowDialog() == DialogResult.OK)
                {

                    foreach (var itemm in listBox1.Items)
                    {
                        if (listBox1.SelectedItem == itemm)
                        {
                          
                            (itemm as Product).productname = form2.textBox1.Text;
                            (itemm as Product).country = form2.textBox2.Text;
                            (itemm as Product).cost = form2.textBox3.Text;
                        }

                    }

                }
                
            }
            
        }
        private void button3_Click(object sender, EventArgs e)
        {
            if (listBox1.SelectedItem != null)
            {
                listBox1.Items.Remove(listBox1.SelectedItem);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            listBox1.Items.Clear();
        }
    }
}
