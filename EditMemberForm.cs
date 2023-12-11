using Karate.Properties;
using Karate_BusinessLayer;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Resources;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Karate
{
    public partial class EditMemberForm : Form
    {
        public EditMemberForm()
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



        clsMembers _Member;


        void FillMemberDataToForm(clsMembers Member)
        {
            clsPersons Person = clsPersons.Find(Member.PersonID);


            TxtMemberID.Text = Member.MemberID.ToString();
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

            ComboBoxBeltRank.SelectedIndex = Member.LastBeltRank - 1;

            if (Member.IsActive == "Yes")
            {
                RDYes.Checked = true;
            }
           if(Member.IsActive=="No")
            {
                RDNo.Checked = true;
            }
   

            DateMakerMember.Value = Person.DateOfBirth;

            if(Person.ImagePath==null && Person.Gender=='F')
            {
                PictureForMember.Image = Resources.pngimg_com___karate_PNG18;
                PictureForMember.Tag = Resources.pngimg_com___karate_PNG18.Tag.ToString();
            }
            if (Person.ImagePath == null && Person.Gender =='M')
            {
                PictureForMember.Image = Resources.ewwewe;
                PictureForMember.Tag =Resources.ewwewe.ToString();
            }
            else
            {
                PictureForMember.Image =Image.FromFile(Person.ImagePath);
                PictureForMember.Tag = Person.ImagePath;
            }      

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if(TxtSerarchByID.Text==string.Empty)
            {
                Form New = new FormForWrongNotExist("Plese Enter Member ID To Search");
                New.ShowDialog();
                return;
            }

            clsMembers Member=clsMembers.Find(Convert.ToInt32(TxtSerarchByID.Text));
          
            if (Member != null)
            {
                FillMemberDataToForm(Member);

                _Member = Member;               
            }
            else
            {
                Form New = new FormForWrongWithReasons("The Member Does Not Exist");
                New.ShowDialog();
            }


        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FillDataToNewMember()
        {
            _Member.MemberID = Convert.ToInt32(TxtMemberID.Text);
            _Member.Name = TxtName.Text;
            _Member.Email = TxtEmail.Text;
            _Member.Passwrod = TxtPassword.Text;
            _Member.Phone = TxtPhone.Text;
            _Member.DateOfBirth = DateMakerMember.Value;
            _Member.Adrress=TxtAdrress.Text;


            _Member.ImagePath = PictureForMember.Tag.ToString();


            if (RDYes.Checked)
            {
                _Member.IsActive = "Yes";
            }
            if (RDNo.Checked)
            {
                _Member.IsActive = "No";
            }

            _Member.LastBeltRank = ComboBoxBeltRank.SelectedIndex + 1 ;

            if (CoboBoxGender.SelectedIndex == 0)
            {
                _Member.Gender = 'M';
            }
            if (CoboBoxGender.SelectedIndex == 1)
            {
                _Member.Gender = 'F';
            }

        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            FillDataToNewMember();

            if(clsMembers.UpdateMember(_Member.MemberID,_Member.Passwrod,_Member.Name,_Member.Gender,_Member.Email,_Member.Phone,_Member.DateOfBirth,_Member.Adrress,_Member.IsActive,_Member.LastBeltRank,_Member.ImagePath)!=0)
            {
                Form New = new FormForRithThing("The Member Updated");
                New.ShowDialog();
            }
            else
            {
                Form New = new FormForWrongWithReasons("The Member Does Not Updated");
                New.ShowDialog();
            }
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Title = "Open Image";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                PictureForMember.Image = new Bitmap(openFileDialog1.FileName);
               _Member.ImagePath = openFileDialog1.FileName;
            }
            else
            {
                _Member.ImagePath = "uiuiu";
            }
        }

    
    }
}
