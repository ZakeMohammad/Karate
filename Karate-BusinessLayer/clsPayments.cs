using Karate_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_BusinessLayer
{
    public class clsPayments
    {
        public clsPayments(int Paymentid,int memberid,DateTime paymentdate,double amountpaid) 
        {
            this.PaymentID = Paymentid;
            this.PaymentDate = paymentdate;
            this.MemberID= memberid;
            this.Amount_Paid= amountpaid;
        }

        public clsPayments()
        {


        }



        public int PaymentID { get; set; }

        public int MemberID { get; set; }

        public DateTime PaymentDate { get; set; }

        public double Amount_Paid { get; set; }

        public static DataTable GittAllPayments()
        {
            return clsPayments_Data.GittAllPayments();
        }

        public static int AddNewPayment(int MemberID,DateTime PaymentDate,double Amount_Paid)
        {
            return clsPayments_Data.AddNewPayment(MemberID, PaymentDate, Amount_Paid);
        }

        public static int UpdatePayment(int PaymentID, DateTime PaymentDate, double Amount_Paid)
        {
            return clsPayments_Data.UpdatePayment(PaymentID,PaymentDate, Amount_Paid);
        }

        public static clsPayments Find(int PaymentID)
        {
            int Memberid = 0;
            double amount = 0;
            DateTime Paymetndate= DateTime.Now;


            if (clsPayments_Data.Find(PaymentID, ref Memberid, ref Paymetndate, ref amount))       
                return new clsPayments(PaymentID, Memberid, Paymetndate, amount);      
            else
                return null;

        }

        public static int DeletePayment(int PaymentID)
        {
            return clsPayments_Data.DeletePayment(PaymentID);
        }


        public static DataTable GitLastesPayment()
        {
            return clsPayments_Data.GitLastesPayment();
        }
        public static int GitNumberOfPayments()
        {
            return clsPayments_Data.GitNumberOfPayments();
        }

    }
}
