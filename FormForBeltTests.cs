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
    public partial class FormForBeltTests : Form
    {
        public FormForBeltTests()
        {
            InitializeComponent();
         
        }

        private void btnListTests_Click(object sender, EventArgs e)
        {
           Form New =new ListTestsForm();
            New.ShowDialog();
        }

        private void btnAddNewTest_Click(object sender, EventArgs e)
        {
            Form New = new AddTestForm();
            New.ShowDialog();
        }

        private void FormForBeltTests_Load(object sender, EventArgs e)
        {
            DataGridViewForTests.DataSource = clsTests.GitAllTests();
        }
    }
}
