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
    public partial class FormForSubscriptonPeriods : Form
    {
        public FormForSubscriptonPeriods()
        {
            InitializeComponent();
            DataGridViewForSearchSubsecriptions.DataSource = clsSubscriptions.GitallSubsecriptions();
        }

        private void btnAddNewSubsecription_Click(object sender, EventArgs e)
        {
            Form New = new AddNewSubsecriptionForm();
            New.ShowDialog();
        }

        private void btnListSubsecriptions_Click(object sender, EventArgs e)
        {
            Form New= new AllSubsecriptionsForm();
            New.ShowDialog();
        }

        private void FormForSubscriptonPeriods_Load(object sender, EventArgs e)
        {
            DataGridViewForSearchSubsecriptions.DataSource = clsSubscriptions.GitallSubsecriptions();
        }
    }
}
