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

namespace Karate
{
    public partial class EditInstructorForm : Form
    {
        public EditInstructorForm()
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

        clsInstruchers _Instructer;

        void FillInstructorDataToForm(clsInstruchers Instructer)
        {
            clsPersons Person = clsPersons.Find(Instructer.PersonID);


            TxtInstructerID.Text = Instructer.InstruchersID.ToString();
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

            DateMakerInstructoer.Value = Person.DateOfBirth;    
                      
          PictureForInstructer.Image = Image.FromFile(Person.ImagePath);
          PictureForInstructer.Tag = Person.ImagePath;
            

        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (TxtSerarchByID.Text == string.Empty)
            {
                Form New = new FormForWrongNotExist("Plese Enter Instructer ID To Search");
                New.ShowDialog();
                return;
            }

            clsInstruchers Instructer = clsInstruchers.Find(Convert.ToInt32(TxtSerarchByID.Text));

            if (Instructer != null)
            {
                FillInstructorDataToForm(Instructer);

                _Instructer = Instructer;
            }
            else
            {
                Form New = new FormForWrongWithReasons("The Instructer Does Not Exist in system");
                New.ShowDialog();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FillDataToNewMember()
        {
            _Instructer.InstruchersID = Convert.ToInt32(TxtInstructerID.Text);
            _Instructer.Name = TxtName.Text;
            _Instructer.Email = TxtEmail.Text;
            _Instructer.Passwrod = TxtPassword.Text;
            _Instructer.Phone = TxtPhone.Text;
            _Instructer.DateOfBirth = DateMakerInstructoer.Value;
            _Instructer.Adrress = TxtAdrress.Text;


            _Instructer.ImagePath = PictureForInstructer.Tag.ToString();


            if (CoboBoxGender.SelectedIndex == 0)
            {
                _Instructer.Gender = 'M';
            }
            if (CoboBoxGender.SelectedIndex == 1)
            {
                _Instructer.Gender = 'F';
            }


        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillDataToNewMember();

            if (clsInstruchers.UpdateInstruchers(_Instructer.InstruchersID, _Instructer.Passwrod, _Instructer.Name, _Instructer.Gender, _Instructer.Email, _Instructer.Phone, _Instructer.DateOfBirth, _Instructer.Adrress ,_Instructer.ImagePath) != 0)
            {
                Form New = new FormForRithThing("The Instructer Updated");
                New.ShowDialog();

            }
            else
            {
                Form New = new FormForWrongWithReasons("The Instructer Does Not Updated");
                New.ShowDialog();
               
            }
        }

        private void lblSetImage_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            openFileDialog1.Title = "Open Image";

            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                PictureForInstructer.Image = new Bitmap(openFileDialog1.FileName);
                _Instructer.ImagePath = openFileDialog1.FileName;
            }
            else
            {
                _Instructer.ImagePath = "uiuiu";
            }
        }


    }
}
