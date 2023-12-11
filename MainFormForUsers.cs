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
using System.Web.UI.WebControls;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;

namespace Karate
{
    public partial class MainFormForUsers : Form
    {
        public MainFormForUsers(string Username)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            CurrentUser = clsUsers.Find(Username);

            clsPersons Person = clsPersons.Find(CurrentUser.PersonID);

            LabelCurrentUserName.Text = Person.Name;
            PictrueForUser.Image = System.Drawing.Image.FromFile(Person.ImagePath);
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



        private Guna2Button CurrentButton;
        private Form CurrentForm;

        clsUsers CurrentUser;

        enum enPermissions { ManageMebers = 1, ManageUsers = 2, ManageInstructors = 4, ManageMemberInstructore = 8, ManageSubscriptions = 16, ManageBeltRanks = 32, ManageBeltTests = 64, ManagePayments = 128 }

        private void OpenChiledForm(Form ChildForm)
        {
            if (CurrentForm != null)
            {
                CurrentForm.Close();
            }
            CurrentForm = ChildForm;
            CurrentForm.TopLevel = false;
            ChildForm.FormBorderStyle = FormBorderStyle.None;
            ChildForm.Dock = DockStyle.Fill;
            PanelForAllForms.Controls.Add(ChildForm);
            PanelForAllForms.Tag = ChildForm;
            ChildForm.BringToFront();
            ChildForm.Show();
            
        }
        public void DesabliButton()
        {
            if (CurrentButton != null)
            {
                CurrentButton.TextAlign = HorizontalAlignment.Left;
                CurrentButton.ImageAlign = HorizontalAlignment.Left;
                CurrentButton.ImageOffset = new Point(12, 0);
                CurrentButton.TextOffset = new Point(10, 0);
                CurrentButton.FillColor = Color.Black;
            }
        }
        public void ActiveButtoun(Guna2Button Button)
        {
            if (Button != null)
            {
                DesabliButton();
                CurrentButton = (Guna2Button)Button;
                Button.TextAlign = HorizontalAlignment.Center;
                Button.ImageAlign = HorizontalAlignment.Center;
                Button.ImageOffset = new Point(0, 0);
                Button.TextOffset = new Point(0, 0);
                Button.FillColor = Color.LightSlateGray;
            }
        }

        private void btnDahboard_Click(object sender, EventArgs e)
        {
           
            ActiveButtoun((Guna2Button)sender);

            OpenChiledForm(new FormForDashboard());
        }

        private bool CheakPermiisoins(enPermissions Permissoin)
        {
            if((CurrentUser.Permissions & (int)Permissoin)==(int)Permissoin)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        private void btnMembers_Click(object sender, EventArgs e)
        {
          
            ActiveButtoun((Guna2Button)sender);
           
            if (CheakPermiisoins(enPermissions.ManageMebers))
             {
                OpenChiledForm(new FormForMembers());
            }
            else
            {
                MessageBox.Show("You Not Allowd To Use This Future Contact With Your Admin", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            
            
        }

        private void btnInstructors_Click(object sender, EventArgs e)
        {          
            ActiveButtoun((Guna2Button)sender);
            
            if (CheakPermiisoins(enPermissions.ManageInstructors))
            {
                OpenChiledForm(new FormForInstructors());
            }
            else
            {
                MessageBox.Show("You Not Allowd To Use This Future Contact With Your Admin", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnUsers_Click(object sender, EventArgs e)
        {          
            ActiveButtoun((Guna2Button)sender);
        
            if (CheakPermiisoins(enPermissions.ManageUsers))
            {
                OpenChiledForm(new FormForUsers());
            }
            else
            {
                MessageBox.Show("You Not Allowd To Use This Future Contact With Your Admin", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnMemberInstructors_Click(object sender, EventArgs e)
        {           
            ActiveButtoun((Guna2Button)sender);
           
            if (CheakPermiisoins(enPermissions.ManageMemberInstructore))
            {
                OpenChiledForm(new FormForMemberInstructors());
            }
            else
            {
                MessageBox.Show("You Not Allowd To Use This Future Contact With Your Admin", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnBeltRanks_Click(object sender, EventArgs e)
        {          
            ActiveButtoun((Guna2Button)sender);
           
            if (CheakPermiisoins(enPermissions.ManageBeltRanks))
            {
                OpenChiledForm(new FormForBeltRanks());
            }
            else
            {
                MessageBox.Show("You Not Allowd To Use This Future Contact With Your Admin", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnSubscriptionPeriods_Click(object sender, EventArgs e)
        {
            ActiveButtoun((Guna2Button)sender);
            
            if (CheakPermiisoins(enPermissions.ManageSubscriptions))
            {
                OpenChiledForm(new FormForSubscriptonPeriods());
            }
            else
            {
                MessageBox.Show("You Not Allowd To Use This Future Contact With Your Admin", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnBeltTests_Click(object sender, EventArgs e)
        {
            ActiveButtoun((Guna2Button)sender);
            
            if (CheakPermiisoins(enPermissions.ManageBeltTests))
            {
                OpenChiledForm(new FormForBeltTests());
            }
            else
            {
                MessageBox.Show("You Not Allowd To Use This Future Contact With Your Admin", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnPayments_Click(object sender, EventArgs e)
        {
            ActiveButtoun((Guna2Button)sender);
           
            if (CheakPermiisoins(enPermissions.ManagePayments))
            {
                OpenChiledForm(new FormForPayments());
            }
            else
            {
                MessageBox.Show("You Not Allowd To Use This Future Contact With Your Admin", "Karate Club", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void btnLogOut_Click(object sender, EventArgs e)
        {
            ActiveButtoun((Guna2Button)sender);
            CurrentUser = null;

            Form Login = new LoginForm();
            Login.Show();
            this.Close();
        }


    }
}
