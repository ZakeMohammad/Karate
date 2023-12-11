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
    public partial class FormForInstructors : Form
    {
        public FormForInstructors()
        {
            InitializeComponent();
            ReferchData();
        }    

        void ReferchData()
        {
            DatagirdviewForInstructionSearch.DataSource = clsInstruchers.GitAllInstruchers();
        }
        private void btnListInstructions_Click(object sender, EventArgs e)
        {
            Form ListInsturctor=new ListInstructorsForm();
            ListInsturctor.ShowDialog(); 
        }

        private void btnAddNewInstructions_Click(object sender, EventArgs e)
        {
            Form AddPerson=new AddNewPersonForm(3);
            AddPerson.ShowDialog();
        }

        private void TxtSearchByInstructionsID_TextChanged(object sender, EventArgs e)
        {
           
            if (ComboBoxForSearchInstructions.SelectedIndex == 0)
            {
                DataTable dt = clsInstruchers.GitAllInstructorByFeltarWithMemberID(Convert.ToInt32(TxtSearchByInstructionsID.Text));
                DatagirdviewForInstructionSearch.DataSource = dt;
            }
        }

        private void btnEditInstructions_Click(object sender, EventArgs e)
        {
            Form editinstructer = new EditInstructorForm();
            editinstructer.ShowDialog();

        }




    }
}
