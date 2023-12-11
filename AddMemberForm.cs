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
    public partial class AddMemberForm : Form
    {
         int PersonID = 0;
        public AddMemberForm(int personiD)
        {
            InitializeComponent();
            PersonID = personiD;          
            this.SetStyle(ControlStyles.ResizeRedraw, true);
        }
        public AddMemberForm()
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

        private void btnAddMember_Click(object sender, EventArgs e)
        {
            clsMembers Member=new clsMembers();


            Member.LastBeltRank =Convert.ToInt32( ComboBoxLastBelt.SelectedIndex)+1;

            if(btnRadioNO.Checked )
            {
                Member.IsActive = "No";
            }
            if(btnRadioYes.Checked )
            {
                Member.IsActive = "Yes";
            }
            Member.PersonID = PersonID;


            if(clsMembers.AddNewMember(Member.LastBeltRank, Member.IsActive,PersonID)!=0)
            {
                Form New = new FormForRithThing("The Member Successfully Added");
                New.ShowDialog();
                this.Close();
                return;
            }
            else
            {
                Form New = new FormForWrongNotExist("The Member Does Not Added");
                New.ShowDialog();
                this.Close();
                return;
            }

        }




    }
}
