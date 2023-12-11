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
    public partial class FormForMemberInstructors : Form
    {
        public FormForMemberInstructors()
        {
            InitializeComponent();
            DatagirdviewForMemberInstructersSearch.DataSource = clsMemberInstructor.GitAllMemberInstructer();
        }

        private void TxtSearchByNameOrMemberConstructerID_TextChanged(object sender, EventArgs e)
        {
            if (ComboBoxForSearchMembeInstructers.SelectedIndex == 0)
            {
                if (TxtSearchByNameOrMemberConstructerID.Text == "0" || TxtSearchByNameOrMemberConstructerID.Text == string.Empty)
                {
                    DatagirdviewForMemberInstructersSearch.DataSource =clsInstruchers.GitAllInstruchers();
                    return;
                }
                DatagirdviewForMemberInstructersSearch.DataSource = clsMemberInstructor.GitAllMemberInstructerwithFiltter(Convert.ToInt32(TxtSearchByNameOrMemberConstructerID.Text), "", "");
            }
            if (ComboBoxForSearchMembeInstructers.SelectedIndex == 1)
            {
                DatagirdviewForMemberInstructersSearch.DataSource = clsMemberInstructor.GitAllMemberInstructerwithFiltter(0, TxtSearchByNameOrMemberConstructerID.Text, "");
            }
            if(ComboBoxForSearchMembeInstructers.SelectedIndex==2)
            {
                DatagirdviewForMemberInstructersSearch.DataSource = clsMemberInstructor.GitAllMemberInstructerwithFiltter(0, "", TxtSearchByNameOrMemberConstructerID.Text);
            }
        }

        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            Form AddMemberinstruter = new AddMemberInstucterForm();
            AddMemberinstruter.ShowDialog();

        }

        private void btnListMembers_Click(object sender, EventArgs e)
        {
            Form ListMemberInstructer = new ListMemberInstrcters();
            ListMemberInstructer.ShowDialog();
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            Form Editmemberinstructer = new EditMemberInstructerForm();
            Editmemberinstructer.ShowDialog();
        }
    }
}
