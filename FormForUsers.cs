using Guna.UI2.WinForms;
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
    public partial class FormForUsers : Form
    {
        public FormForUsers()
        {
            InitializeComponent();
        }

        private void TxtSearchByNameOrUsername_TextChanged(object sender, EventArgs e)
        {
            if (ComboBoxForSearchUser.SelectedIndex == 0)
            {
                DataTable dt = clsUsers.GitAllUsersByFeltarWithUsername(TxtSearchByNameOrUsername.Text);
                DatagirdviewForUsersSearch.DataSource = dt;
            }
            if (ComboBoxForSearchUser.SelectedIndex == 1)
            {
                if (TxtSearchByNameOrUsername.Text == "0" || TxtSearchByNameOrUsername.Text == string.Empty)
                {
                    DatagirdviewForUsersSearch.DataSource = clsUsers.GitAllUsers();
                    return;
                }
                         
                DataTable dt = clsUsers.GitAllUsersByFeltarWithUserID(Convert.ToInt32( TxtSearchByNameOrUsername.Text));
                DatagirdviewForUsersSearch.DataSource = dt;
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (ComboBoxForSearchUser.SelectedIndex == 0)
            {
                DataTable dt = clsUsers.GitAllUsersByFeltarWithUsername(TxtSearchByNameOrUsername.Text);
                DatagirdviewForUsersSearch.DataSource = dt;
            }
            if (ComboBoxForSearchUser.SelectedIndex == 1)
            {
                DataTable dt = clsUsers.GitAllUsersByFeltarWithUserID(Convert.ToInt32(TxtSearchByNameOrUsername.Text));
                DatagirdviewForUsersSearch.DataSource = dt;
            }
        }

        private void FormForUsers_Load(object sender, EventArgs e)
        {
            DataTable dt = clsUsers.GitAllUsers();
            DatagirdviewForUsersSearch.DataSource = dt;
        }

        private void btnListUsers_Click(object sender, EventArgs e)
        {
            Form allusers = new AllUsersForm();
            allusers.ShowDialog();
        }

        private void btnAddNewUser_Click(object sender, EventArgs e)
        {
            Form addPerson = new AddNewPersonForm(2);
            addPerson.Show();
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            Form EditUser = new EditUserForm();
            EditUser.Show();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
           if(MessageBox.Show("Are you shure you what to delete this User ?","Karate Club",MessageBoxButtons.YesNo,MessageBoxIcon.Question)==DialogResult.Yes)
            {
                if (clsUsers.DeleteUser( DatagirdviewForUsersSearch.CurrentRow.Cells[1].Value.ToString()))
                {
                    MessageBox.Show("The User Deleted","Karate Club",MessageBoxButtons.OK,MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("The User Does Not  Deleted", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
           }
           
        }

    
    }
}
