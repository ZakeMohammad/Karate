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
using System.Xml.Linq;

namespace Karate
{
    public partial class EditPaymentForm : Form
    {
        public EditPaymentForm()
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

        clsPayments _Payment;

        void FillPaymentDataToForm(clsPayments Payment1)
        {

           TxtPaymentID.Text=Payment1.PaymentID.ToString();

           DataTable dt1 = clsMemberInstructor.GitAllMemberNames();
           foreach (DataRow Row in dt1.Rows)
           {
                    ComboBoxMembersNames.Items.Add(Row[0].ToString());
           }

          clsMembers Member = clsMembers.Find(Payment1.MemberID);
            clsPersons Person=clsPersons.Find(Member.PersonID);
            if(Member!=null)
            {
                ComboBoxMembersNames.SelectedItem = Person.Name.ToString();

                NumberOfAmountPaid.Value = (int)Payment1.Amount_Paid;

                DateForPayment.Value = Payment1.PaymentDate;
            }

          
        }

        private void btnSearchForPayment_Click(object sender, EventArgs e)
        {
            if (TxtPaymentIDSearch.Text == string.Empty)
            {
                Form New = new FormForWrongNotExist("Plese Enter Payment ID To Search");
                New.ShowDialog();
                return;
            }

            clsPayments Payment1 = clsPayments.Find(Convert.ToInt32(TxtPaymentIDSearch.Text));

            if (Payment1 != null)
            {
                FillPaymentDataToForm(Payment1);

                _Payment = Payment1;
            }
            else
            {

                Form New = new FormForWrongWithReasons("The Payment Does Not Exist");
                New.ShowDialog();
            }
        }


        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        void FillDataToNewPayment()
        {
            _Payment.PaymentDate=DateForPayment.Value;

            _Payment.Amount_Paid =(int) NumberOfAmountPaid.Value;

            clsMembers Memeber = clsMembers.Find(_Payment.MemberID);

            Memeber.Name=ComboBoxMembersNames.SelectedItem.ToString();

            _Payment.MemberID = Memeber.MemberID;

        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            FillDataToNewPayment();

            if (clsPayments.UpdatePayment(_Payment.PaymentID,_Payment.PaymentDate,_Payment.Amount_Paid) != 0)
            {
                Form New = new FormForRithThing("The Payment Updated");
                New.ShowDialog();

            }
            else
            {
                Form New = new FormForWrongNotExist("The Payment Does Not Updated");
                New.ShowDialog();

            }
        }
    }
}
