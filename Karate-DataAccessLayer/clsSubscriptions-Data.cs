using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Karate_DataAccessLayer
{
    public class clsSubscriptions_Data
    {
       public static DataTable GitallSubsecriptions()
        {
            DataTable dt = new DataTable();

            SqlConnection Connicton = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from SubscriptionsDetelis";

            SqlCommand Command= new SqlCommand(Querey,Connicton);

            try
            {
                Connicton.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
                }
                Reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connicton.Close();
            }
            return dt;
        }

        public static int AddNewSubsecription(int MemberID,double Fees,string IsPaid,DateTime StartDate,DateTime EndDate,int PaymentID)
        {
            int SubsecriptionID = 0;

            SqlConnection Connicton = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"insert into Subscriptions (MemberID,Fees,IsPaid,StartDate,EndDate,PaymentID)
                          values (@memberid,@fees,@ispaid,@startdate,@enddate,@paymentid); select SCOPE_IDENTITY();";


            SqlCommand Command= new SqlCommand(Querey, Connicton);

            Command.Parameters.AddWithValue("@memberid", MemberID);
            Command.Parameters.AddWithValue("@fees",Fees );
            Command.Parameters.AddWithValue("@ispaid",IsPaid );
            Command.Parameters.AddWithValue("@startdate", StartDate);
            Command.Parameters.AddWithValue("@enddate", EndDate);
            Command.Parameters.AddWithValue("@paymentid", PaymentID);

            try
            {
                Connicton.Open();

                object Ruslt = Command.ExecuteScalar();

                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int insertedID))
                {
                    SubsecriptionID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connicton.Close();
            }

            return SubsecriptionID;
        }

        public static int UpdateSubsecription(int PeriodID, int MemberID, double Fees, string IsPaid, DateTime StartDate, DateTime EndDate, int PaymentID)
        {
            int Ruslt = 0;

            SqlConnection Connicton = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "@ update Subscriptions set MemberID=@memberid , Fees=@fees , IsPaid=@ispaid , StartDate=@startdate , EndDate=@enddate , PaymentID=@paymentid  where PeriodID=@periodid ; ";

            SqlCommand Command=new SqlCommand(Querey,Connicton);

            Command.Parameters.AddWithValue("@memberid", MemberID);
            Command.Parameters.AddWithValue("@fees", Fees);
            Command.Parameters.AddWithValue("@ispaid", IsPaid);
            Command.Parameters.AddWithValue("@startdate", StartDate);
            Command.Parameters.AddWithValue("@enddate", EndDate);
            Command.Parameters.AddWithValue("@paymentid", PaymentID);
            Command.Parameters.AddWithValue("@periodid",PeriodID);

            try
            {
                Connicton.Open();

                int RowEffected = Command.ExecuteNonQuery();

                if (RowEffected > 0)
                {
                    Ruslt = 1;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                Connicton.Close();
            }

            return Ruslt;
        }

        public static bool DeleteSubsecription(int PeriodID)
        {
            bool IsDeleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"delete Subscriptions where PeriodID=@periodid";

            SqlCommand Command = new SqlCommand(Querey, Connection);

            Command.Parameters.AddWithValue("@periodid", PeriodID);

            try
            {
                Connection.Open();

                int RowEffected = Command.ExecuteNonQuery();
                if (RowEffected > 0)
                {
                    IsDeleted = true;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                Connection.Close();
            }


            return IsDeleted;
        }

        public static bool Find(int PeriodID,ref int MemberID,ref double Fees,ref string IsPaid,ref DateTime StartDate,ref DateTime EndDate,ref int PaymentID)
        {
            bool IsFound = false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from Subscriptions where PeriodID=@periodid";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@periodid", PeriodID);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    PeriodID = Convert.ToInt32(Reader[0]);
                    MemberID = Convert.ToInt32(Reader[1]);
                    Fees =Convert.ToDouble( (Reader[2]));
                    IsPaid = Reader[3].ToString();
                    StartDate =(DateTime) Reader[4];
                    EndDate= (DateTime)Reader[5];
                    PaymentID= Convert.ToInt32(Reader[6]);
                }
                Reader.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                Conniction.Close();
            }

            return IsFound;

        }

        public static int GitNumberOfSubsecriptions()
        {
            int NumberOfMember = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Query = "select Number = Count(*) from Subscriptions";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    NumberOfMember = (int)Reader[0];
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return NumberOfMember;
        }

        public static DataTable Fillter(int periodid = 0, int paymentid = 0)
        {
            DataTable dataTable = new DataTable();

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "";

            if (periodid != 0)
            {
                Querey = "select * from SubscriptionsDetelis where PeriodID like '" + periodid + "%'";
            }
            
            if (paymentid != 0)
            {
                Querey = "select * from SubscriptionsDetelis where PaymentID like '" + paymentid + "%'";
            }

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dataTable.Load(Reader);
                }
                Reader.Close();

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Conniction.Close();
            }
            return dataTable;
        }





    }
}
