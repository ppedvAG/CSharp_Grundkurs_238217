using Microsoft.EntityFrameworkCore;

namespace HalloEfCore
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        NorthwndContext context = new NorthwndContext();

        private void button1_Click(object sender, EventArgs e)
        {
            //dataGridView1.DataSource = context.Employees.ToList();
            //dataGridView1.DataSource = context.Employees.Where(x => x.BirthDate.Value.Year > 1900) //mit LazyLoading
            //                                            .OrderBy(x => x.BirthDate.Value.Month).ToList();

            dataGridView1.DataSource = context.Employees.Include(x => x.Orders).ThenInclude(x => x.Customer) //eagerLogin 
                                                        .Where(x => x.BirthDate.Value.Year > 1900)
                                                        .OrderBy(x => x.BirthDate.Value.Month).ToList();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            context.SaveChanges();
            context = new NorthwndContext();
        }

        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (dataGridView1.CurrentRow.DataBoundItem is Employee employee)
            {
                var orders = context.Orders.Where(x => x.EmployeeId == employee.EmployeeId); //explizit loading

                //var orderText = string.Join(", ", employee.Orders.Select(x => $"{x.OrderDate.Value.ToString("d")} {x.Customer.CompanyName}"));
                var orderText = string.Join(", ", orders.Select(x => $"{x.OrderDate.Value.ToString("d")} {x.Customer.CompanyName}"));
                MessageBox.Show(employee.FirstName + " " + orderText);
            }
        }
    }
}
