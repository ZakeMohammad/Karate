using Karate_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Karate_BusinessLayer
{
    public class clsTests
    {

        public clsTests(int Testid,int memberid,int rankid,string result,DateTime date,int instercterid,int paymentid)
        {
            this.TestID = Testid;
            this.Result = result;
            this.TestDate = date;
            this.InstructerID = instercterid;
            this.PaymentID = paymentid;
            this.MemberID = memberid;
            this.RankID = rankid;
        }

        public clsTests()
        {

        }

        public int TestID { get; set; }

        public int MemberID { get; set; }

        public DateTime TestDate { get; set; }

        public int InstructerID { get; set; }

        public int RankID { get; set; }

        public string Result { get; set; }

        public int PaymentID { get; set; }


        public static DataTable GitAllTests()
        {
            return clsTests_Data.GitAllTests();
        }

        public static int AddTest(int MemberId, int RankID, string Result, DateTime Date, int InstrecterID, int PaymentID)
        {
            return clsTests_Data.AddTest(MemberId,RankID,Result,Date,InstrecterID,PaymentID);
        }

        public static int UpdateTest(int TestID, int MemberId, int RankID, string Result, DateTime Date, int InstrecterID, int PaymentID)
        {
            return clsTests_Data.UpdateTest(TestID, MemberId, RankID, Result, Date, InstrecterID, PaymentID);
        }


        public static clsTests Find(int TestID)
        {
            int memberid=0,instercterid=0,paymentid=0,rankid=0;
            string result = "";
            DateTime date=DateTime.Now;

            if (clsTests_Data.Find(TestID, ref memberid, ref rankid, ref result, ref date, ref instercterid, ref paymentid))
            {
                return new clsTests(TestID, memberid, rankid, result, date, instercterid, paymentid);
            }
            else
                return null;

        }


        public static int DeleteTest(int TestID)
        {
            if (clsTests_Data.DeleteTest(TestID))
                return 1;
            else
                return 0;
        }

        public static int GitNumberOfTest()
        {
            return clsTests_Data.GitNumberOfTest();
        }



    }
}
