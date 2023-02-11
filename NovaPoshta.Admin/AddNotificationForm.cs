using NovaPoshta.BusinessLogic.Context;
using NovaPoshta.BusinessLogic.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovaPoshta.Admin
{
    public partial class AddNotificationForm : Form
    {
        IRepository<Employee> _employeeRepository=new EmployeeRepository();
        IRepository<Notification> repository=new NotificationRepository();
        IRepository<Poshtomat>poshtomatRepository=new PoshtomatRepository();
        Employee[] employees;
        public AddNotificationForm()
        {
            InitializeComponent();
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "dd.MM.yyyy HH:mm tt";
            dateTimePicker1.Value = DateTime.Now.Date;
            employees = _employeeRepository.GetAll().ToArray();
            if (employees.Length > 0)
            {
                comboBox1.Items.AddRange(employees.Select(x => x.FullName).ToArray());
                comboBox1.SelectedIndex = 0;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex != -1) 
            {
                Notification notification = new Notification();
                notification.Id = Guid.NewGuid();
                notification.StartTime = DateTime.Now;
                notification.EmployeeId = employees[comboBox1.SelectedIndex].Id;
                notification.DueTime = dateTimePicker1.Value;
                poshtomatRepository.Get(employees[comboBox1.SelectedIndex].PoshtomatId).CurrentQuantity++;
                repository.Create(notification);
                repository.SaveChanges();
                poshtomatRepository.SaveChanges();
                this.Close();
            }
        }
    }
}
