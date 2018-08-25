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
        inventoryEntities1 en = new inventoryEntities1();

        public Form1()
        {
            
           
                   
            var testing = from td in en.logins select td;
            var da = testing.ToList();


            //dataGridView1.DataSource = da;
            
            
            
            InitializeComponent();
           
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var testing = from td in en.logins orderby td.id select td;
            foreach (var detail in testing)
            {

                if (detail.id == 0)
                {
                    detail.username = textBox1.Text;
                    detail.passwords = textBox2.Text;

                }
                else if (detail.id ==0 )
                {

                    detail.username = textBox1.Text;
                    detail.passwords = textBox2.Text;
                }

            }
            en.SaveChanges();
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            inventoryEntities1 en = new inventoryEntities1();
            var t = new login //Make sure you have a table called test in DB
            {
                
                username = textBox1.Text,
                passwords=textBox2.Text
            };

            en.logins.Add(t);
            en.SaveChanges();
        }
    }
}
