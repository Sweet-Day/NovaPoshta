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
    public partial class AdminPanel : Form
    {
        IRepository<Notification> _notificationRepository = new NotificationRepository();
        public AdminPanel()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddNotificationForm form = new AddNotificationForm();
            form.ShowDialog();
            dataGridView1.DataSource = _notificationRepository.GetAll().ToArray();
        }

        private void AdminPanel_Load(object sender, EventArgs e)
        {
            dataGridView1.DataSource = _notificationRepository.GetAll().ToArray();
            
        }
    }
}
