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
    public partial class AddUserForm : Form
    {
        int PersonID = 0;
        public AddUserForm(int personiD)
        {
            InitializeComponent();
           PersonID = personiD;
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }

        public AddUserForm()
        {
            

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
            if(CHAllPerimmisons.Checked==true)
            {
                CheakALl();
            }
            if(CHAllPerimmisons.Checked==false)
            {
                NotCheakALL();
            }
        }

        int GitPremissions()
        {
            int P = 0;

            if(CHAllPerimmisons.Checked)
            {
                return -1;
            }
            if(CHManageMembers.Checked)
            {
                P += 1;
            }
            if(CHManageUsers.Checked)
            {
                P += 2;
            }
            if(CHManageInstructors.Checked)
            {
                P += 4;
            }
            if(CHManageMemberInstructors.Checked)
            {
                P += 8;
            }   
            if(CHManageSubscriptions.Checked)
            {
                P += 16;
            }
            if(CHManageBeltRanks.Checked)
            {
                P += 32;
            }
            if(CHManageBeltTests.Checked)
            {
                P += 64;
            }
            if(CHManagePayments.Checked)
            {
                P += 128;
            }
            return P; 
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            clsUsers User= new clsUsers();

            User.UserName=TxtUsername.Text;
            User.PersonID = PersonID;
            User.Permissions = GitPremissions();
            User.PersonID=PersonID;

            if(clsUsers.AddNewUser(User.UserName,User.Permissions,User.PersonID)!=0)
            {
                Form New = new FormForRithThing("The User Successfully Added");
                New.ShowDialog();

                this.Close();
                return;
            }
            else
            {
                Form New = new FormForWrongNotExist("The User Does Not Added");
                New.ShowDialog();

                this.Close();
                return;
            }

        }

        private void CHAllPerimmisons_CheckedChanged(object sender, EventArgs e)
        {
            GitCheakes();
        }
    }
}
