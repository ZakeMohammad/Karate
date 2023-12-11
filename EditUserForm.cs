using Karate.Properties;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace Karate
{
    public partial class EditUserForm : Form
    {
        public EditUserForm()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }


        private const int cGrip = 16;
        private const int cCaption = 32;
        protected override void WndProc(ref Message m)
        {
            if (m.Msg == 0x84)
            {
                Point pos = new Point(m.LParam.ToInt32());
                pos = this.PointToClient(pos);
                if (pos.Y < cCaption)
                {
                    m.Result = (IntPtr)2;
                    return;
                }
                if (pos.X >= this.ClientSize.Width - cGrip && pos.Y >= this.ClientSize.Height - cGrip)
                {
                    m.Result = (IntPtr)17;
                }
            }
            base.WndProc(ref m);
        }


        clsUsers _User;
        enum enPermissions { ManageMebers = 1, ManageUsers = 2, ManageInstructors = 4, ManageMemberInstructore = 8, ManageSubscriptions = 16, ManageBeltRanks = 32, ManageBeltTests = 64, ManagePayments = 128 }
        int GitPremissions()
        {
            int P = 0;

            if (CHAllPerimmisons.Checked)
            {
                return -1;
            }
            if (CHManageMembers.Checked)
            {
                P += 1;
            }
            if (CHManageUsers.Checked)
            {
                P += 2;
            }
            if (CHManageInstructors.Checked)
            {
                P += 4;
            }
            if (CHManageMemberInstructors.Checked)
            {
                P += 8;
            }
            if (CHManageSubscriptions.Checked)
            {
                P += 16;
            }
            if (CHManageBeltRanks.Checked)
            {
                P += 32;
            }
            if (CHManageBeltTests.Checked)
            {
                P += 64;
            }
            if (CHManagePayments.Checked)
            {
                P += 128;
            }
            return P;
        }

        void CheakALl()
        {
            CHManageBeltRanks.Checked = true;
            CHManageBeltTests.Checked = true;
            CHManagePayments.Checked = true;
            CHManageSubscriptions.Checked = true;
            CHManageMemberInstructors.Checked = true;
            CHManageMembers.Checked = true;
            CHManageUsers.Checked = true;
            CHManageInstructors.Checked = true;
        }

        void NotCheakALL()
        {
            CHManageBeltRanks.Checked = false;
            CHManageBeltTests.Checked = false;
            CHManagePayments.Checked = false;
            CHManageSubscriptions.Checked = false;
            CHManageMemberInstructors.Checked = false;
            CHManageMembers.Checked = false;
            CHManageUsers.Checked = false;
            CHManageInstructors.Checked = false;
        }

        void GitCheakes()
        {
            if (CHAllPerimmisons.Checked == true)
            {
                CheakALl();
            }
            if (CHAllPerimmisons.Checked == false)
            {
                NotCheakALL();
            }
        }

        void GitWhoIsCheakedForUser(clsUsers User)
        {

            if (((int)enPermissions.ManageMebers & User.Permissions )== (int)enPermissions.ManageMebers)
            {
                CHManageMembers.Checked = true;
            }

            if (((int)enPermissions.ManageUsers & User.Permissions) == (int)enPermissions.ManageUsers)
            {
                CHManageUsers.Checked = true;
            }

            if (((int)enPermissions.ManageMemberInstructore & User.Permissions) == (int)enPermissions.ManageMemberInstructore)
            {
                CHManageMemberInstructors.Checked = true;
            }

            if (((int)enPermissions.ManageInstructors & User.Permissions) == (int)enPermissions.ManageInstructors)
            {
                CHManageInstructors.Checked = true;
            }

            if (((int)enPermissions.ManageBeltRanks & User.Permissions) == (int)enPermissions.ManageBeltRanks)
            {
                CHManageBeltRanks.Checked = true;
            }

            if (((int)enPermissions.ManageBeltTests & User.Permissions) == (int)enPermissions.ManageBeltTests)
            {
                CHManageBeltTests.Checked = true;
            }

            if (((int)enPermissions.ManagePayments & User.Permissions) == (int)enPermissions.ManagePayments)
            {
                CHManagePayments.Checked = true;
            }

            if (((int)enPermissions.ManageSubscriptions & User.Permissions) == (int)enPermissions.ManageSubscriptions)
            {
                CHManageSubscriptions.Checked = true;
            }
           



        }


        void FillUserDataToForm(clsUsers User)
        {
            clsPersons Person = clsPersons.Find(User.PersonID);


            TxtUsername.Text = User.UserName;
            TxtName.Text = Person.Name;
            TxtPassword.Text = Person.Passwrod;
            TxtPhone.Text = Person.Phone;
            TxtEmail.Text = Person.Email;
            TxtAdrress.Text = Person.Adrress;


            if (Person.Gender == 'M')
            {
                CoboBoxGender.SelectedIndex = 0;
            }
            else
            {
                CoboBoxGender.SelectedIndex = 1;
            }


            DateMakerUser.Value = Person.DateOfBirth;

            if (Person.ImagePath == null && Person.Gender == 'F')
            {
                PictureForUser.Image = Resources.pngimg_com___karate_PNG18;
                PictureForUser.Tag = Resources.pngimg_com___karate_PNG18.Tag.ToString();
            }
            if (Person.ImagePath == null && Person.Gender == 'M')
            {
                PictureForUser.Image = Resources.ewwewe;
                PictureForUser.Tag = Resources.ewwewe.ToString();
            }
            else
            {
                
                PictureForUser.Image = Image.FromFile(Person.ImagePath);
                PictureForUser.Tag = Person.ImagePath;
            }

            if(User.Permissions==-1)
            {
                CHAllPerimmisons.Checked = true;
            }
            else
            {
                GitWhoIsCheakedForUser(User);
            }



        }




        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSearchForUser_Click(object sender, EventArgs e)
        {
            if (TxtSearchByUsername.Text == string.Empty)
            {
                Form New = new FormForWrongNotExist("Plese Enter Username To Search");
                New.ShowDialog();
                return;
            }

            clsUsers User = clsUsers.Find(TxtSearchByUsername.Text);

            if (User != null)
            {
                FillUserDataToForm(User);

                _User = User;
            }
            else
            {

                Form New = new FormForWrongWithReasons("The User Does Not Exist");
                New.ShowDialog();
            }

        }


        void FillDataToNewMember()
        {
            _User.UserName = TxtUsername.Text;
            _User.Name = TxtName.Text;
            _User.Email = TxtEmail.Text;
            _User.Passwrod = TxtPassword.Text;
            _User.Phone = TxtPhone.Text;
            _User.DateOfBirth = DateMakerUser.Value;
            _User.Adrress = TxtAdrress.Text;

            _User.ImagePath = PictureForUser.Tag.ToString();

            if (CoboBoxGender.SelectedIndex == 0)
            {
                _User.Gender = 'M';
            }
            if (CoboBoxGender.SelectedIndex == 1)
            {
                _User.Gender = 'F';
            }

            _User.Permissions = GitPremissions();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillDataToNewMember();

            if (clsUsers.UpdateUser(_User.UserName,_User.Passwrod, _User.Name, _User.Gender, _User.Email, _User.Phone, _User.DateOfBirth, _User.Adrress, _User.Permissions, _User.ImagePath) != 0)
            {
                Form New = new FormForRithThing("The User Updated");
                New.ShowDialog();
            }
            else
            {

                Form New = new FormForWrongWithReasons("The User Does Not Updated");
                New.ShowDialog();
            }
        }

        private void CHAllPerimmisons_CheckedChanged(object sender, EventArgs e)
        {
            GitCheakes();
        }
    }
}
