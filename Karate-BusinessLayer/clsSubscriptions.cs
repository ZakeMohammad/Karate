using Karate_DataAccessLayer;
using System;
using Karate_DataAccessLayer;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_BusinessLayer
{
    public class clsSubscriptions
    {

        public clsSubscriptions(int Periodid,int memberid,double fees,string ispaid,DateTime stsrtdate,DateTime enddate,int paymetnID)           
        {
            this.StartDate = stsrtdate;
            this.EndDate = enddate;
            this.PeriodID = Periodid;
            this.PaymentID = paymetnID;
            this.Fees = fees;
            this.MemberID= memberid;
            this.IsPaid= ispaid;
        }

        public clsSubscriptions()
        {

        }

        public int PeriodID { get; set; }

        public int MemberID { get; set; }

        public double Fees { get; set; }

        public string IsPaid { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int PaymentID { get; set; }




       public static DataTable GitallSubsecriptions()
        {
            return clsSubscriptions_Data.GitallSubsecriptions();
        }

        public static int AddNewSubsecription(int MemberId,double Fees,string IsPaid,DateTime StartDate,DateTime EndDate,int PaymentID)
        {
            return clsSubscriptions_Data.AddNewSubsecription(MemberId, Fees, IsPaid, StartDate, EndDate, PaymentID);
        }


        public static int UpdateSubsecription(int PeriodID, int MemberID, int Fees, string IsPaid, DateTime StartDate, DateTime EndDate, int PaymentID)
        {
            return clsSubscriptions_Data.UpdateSubsecription(PeriodID,MemberID,Fees,IsPaid,StartDate,EndDate,PaymentID);
        }


        public static bool DeleteSubsecription(int PeriodID)
        {
            return clsSubscriptions_Data.DeleteSubsecription(PeriodID);
        }

    

        public clsSubscriptions Find(int PeriodID)
        {
            int MemberID=0, PaymentID = 0;
            double Fees = 0;
            string IsPaid = "";
            DateTime StartDate = DateTime.Now , EndDate=DateTime.Now;

            if(clsSubscriptions_Data.Find(PeriodID,ref MemberID,ref Fees,ref IsPaid,ref StartDate , ref EndDate, ref PaymentID))
            {
                return new clsSubscriptions(PeriodID,MemberID,Fees,IsPaid,StartDate,EndDate,PaymentID);
            }
            else
            { 
                return null;
            }

        }

        public static int GitNumberOfSubsecriptions()
        {
            return clsSubscriptions_Data.GitNumberOfSubsecriptions();
        }
    }
}
