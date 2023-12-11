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
    public partial class FormForDashboard : Form
    {
        public FormForDashboard()
        {
            InitializeComponent();
            RefreschData();
        }

        void RefreschData()
        {
            lblNumberOfMembers.Text = clsMembers.GitNumberOfMembers().ToString();
            lblNumberOfUsers.Text= clsUsers.GitNumberOfUsers().ToString();
            lblNumberOfInstructor.Text=clsInstruchers.GitNumberOfInstructor().ToString();
            lblNumberOfSubsicription.Text=clsSubscriptions.GitNumberOfSubsecriptions().ToString();
            lblNumberOfPayments.Text=clsPayments.GitNumberOfPayments().ToString();
            lblNumberOfBeltTests.Text = clsTests.GitNumberOfTest().ToString();
        }
    }
}
