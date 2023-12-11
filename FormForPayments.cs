using Karate_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Karate
{
    public partial class FormForPayments : Form
    {
        public FormForPayments()
        {
            InitializeComponent();
            DataGridViewForPayments.DataSource = clsPayments.GittAllPayments();
        }

        private void btnAddNewPayments_Click(object sender, EventArgs e)
        {
            Form New=new AddNewPaymentForm();
            New.ShowDialog();
        }

        private void btnListPayments_Click(object sender, EventArgs e)
        {
            Form New=new ListPaymentsForm();
            New.ShowDialog();
        }

        private void btnEditPayments_Click(object sender, EventArgs e)
        {
            Form New=new EditPaymentForm();
            New.ShowDialog();
        }






    }
}
