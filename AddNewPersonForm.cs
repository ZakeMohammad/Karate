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
    public partial class AddNewPersonForm : Form
    {

        int AddMemberOrUserOrInstructer = 0;
        public AddNewPersonForm(int AddForHow)
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            btnRadioMale.Checked =true;
            AddMemberOrUserOrInstructer=AddForHow;
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
        int PersonID = 0;
        string ImagePath="";
        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Title = "Open Image";
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                PictreForPerson.Image = new Bitmap(openFileDialog1.FileName);
                ImagePath = openFileDialog1.FileName;
            }
            else
            {
                ImagePath = "";
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            clsPersons Person=new clsPersons();


            Person.Name=TxtName.Text;
            Person.Passwrod=TxtPasswrod.Text;
            Person.Email=TxtEmail.Text;
            Person.Adrress=TxtAdrress.Text;
            Person.Phone=TxtPhone.Text;
            Person.DateOfBirth = DateTimePakierForPerson.Value;

            if(btnRadioFemale.Checked)
            {
                Person.Gender = 'F';
            }
            if(btnRadioMale.Checked)
            {
                Person.Gender = 'M';
            }
            if(ImagePath!="")
            {
                Person.ImagePath=ImagePath;
            }
            else
            {
                Person.ImagePath =null;
            }

            if ((PersonID = Person.AddNewPerson())!=0)
            {                           

                if(AddMemberOrUserOrInstructer==1)
                {
                    Form AddMember = new AddMemberForm(PersonID);
                    AddMember.ShowDialog();
                    this.Close();
                }
             
                if(AddMemberOrUserOrInstructer==2)
                {
                  Form AddUser= new AddUserForm(PersonID);
                    AddUser.ShowDialog();
                    this.Close();
                }
                if(AddMemberOrUserOrInstructer==3)
                {
                    Form AddInstructor = new AddInstrctorForm(PersonID);
                    AddInstructor.ShowDialog();
                    this.Close();
                }

            }
            else
            {
                Form New = new FormForWrongNotExist("The Person Deos Not Added");
                New.ShowDialog();

                this.Close();
                return;
            }



        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }




    }


}
