using System;
using System.Linq;
using System.Windows.Forms;

namespace HalloEf
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        Model1Container model1 = new Model1Container();

        private void button1_Click(object sender, EventArgs e)
        {
            dataGridView1.DataSource = model1.People.ToList();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            model1.SaveChanges();
        }
    }
}
