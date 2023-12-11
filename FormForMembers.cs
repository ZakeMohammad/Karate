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
    public partial class FormForMembers : Form
    {
        public FormForMembers()
        {
            InitializeComponent();  
        }


        private void TxtSearchByNameOrMemberID_TextChanged(object sender, EventArgs e)
        {
            if (ComboBoxForSearchMember.SelectedIndex == 1)
            {
                DataTable dt = clsMembers.GitAllMemberByFeltarWithName(TxtSearchByNameOrMemberID.Text);
                DatagirdviewForMemberSearch.DataSource = dt;
            }
            if (ComboBoxForSearchMember.SelectedIndex == 0)
            {
                DataTable dt = clsMembers.GitAllMemberByFeltarWithMemberID(Convert.ToInt32(TxtSearchByNameOrMemberID.Text));
                DatagirdviewForMemberSearch.DataSource = dt;
            }

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ComboBoxForSearchMember.SelectedIndex == 1)
            {
                DataTable dt = clsMembers.GitAllMemberByFeltarWithName(TxtSearchByNameOrMemberID.Text);
                DatagirdviewForMemberSearch.DataSource = dt;
            }
            if (ComboBoxForSearchMember.SelectedIndex == 0)
            {
                DataTable dt = clsMembers.GitAllMemberByFeltarWithMemberID(Convert.ToInt32(TxtSearchByNameOrMemberID.Text));
                DatagirdviewForMemberSearch.DataSource = dt;
            }
        }
        private void FormForMembers_Load(object sender, EventArgs e)
        {
            DataTable dt = clsMembers.GitAllMembers();
            DatagirdviewForMemberSearch.DataSource = dt;
        }

        private void btnListMembers_Click(object sender, EventArgs e)
        {
            Form allmemberform=new ListMembersForm();
            allmemberform.ShowDialog();
        }
  
        private void btnAddNewMember_Click(object sender, EventArgs e)
        {
            Form addPerson = new AddNewPersonForm(1);
            addPerson.ShowDialog();
        }

        private void btnEditMember_Click(object sender, EventArgs e)
        {
            Form EditMember = new EditMemberForm();
            EditMember.ShowDialog();

        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you shure you what to delete this Member ?", "Karate Club", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (clsMembers.DeleteMember((int)(DatagirdviewForMemberSearch.CurrentRow.Cells[0].Value)))
                {
                    MessageBox.Show("The Member Deleted", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The Member Does Not  Deleted", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }



    }
}
