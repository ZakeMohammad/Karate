using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Karate_DataAccessLayer
{
    public class clsTests_Data
    {


        public static DataTable GitAllTests()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from AllTests";

            SqlCommand Command = new SqlCommand(Querey, Connection);

            try
            {
                Connection.Open();

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
                Connection.Close();
            }

            return dt;
        }


        public static int AddTest(int MemberId,int RankID,string Result,DateTime Date,int InstrecterID,int PaymentID)
        {
            int testid = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"insert into Tests (MemberID,RankID,Result,Date,InstructerID,PaymentID) values (@memberid,@rankid,@result,@date,@instrecterid,@paymentid); select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@memberid", MemberId);
            Command.Parameters.AddWithValue("@rankid",RankID );
            Command.Parameters.AddWithValue("@result", Result);
            Command.Parameters.AddWithValue("@date", Date);
            Command.Parameters.AddWithValue("@instrecterid",InstrecterID );
            Command.Parameters.AddWithValue("@paymentid",PaymentID );
           

            try
            {
                Conniction.Open();

                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int insertedID))
                {
                    testid = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Conniction.Close();
            }
            return testid;
        }

        public static int UpdateTest(int TestID, int MemberId, int RankID, string Result, DateTime Date, int InstrecterID, int PaymentID)
        {
            int Ruslt = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"Update TestsDetelis set MemberID=@memberid, RankID=@rankid,Result=@result,Date=@date,InstructerID=@instructrid,PaymentID=@paymentid  where TestID=@testid ; ";

            SqlCommand Command = new SqlCommand(Querey + Querey, Conniction);

            Command.Parameters.AddWithValue("@memberid", MemberId);
            Command.Parameters.AddWithValue("@rankid",RankID );
            Command.Parameters.AddWithValue("@date",Date );
            Command.Parameters.AddWithValue("@result", Result);
            Command.Parameters.AddWithValue("@instructrid", InstrecterID);
            Command.Parameters.AddWithValue("@paymentid", PaymentID);
            Command.Parameters.AddWithValue("@testid", TestID);

            try
            {
                Conniction.Open();

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
                Conniction.Close();
            }


            return Ruslt;
        }


        public static bool DeleteTest(int TestID)
        {
            bool IsDeleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"delete Tests where TestID=@testid";

            SqlCommand Command = new SqlCommand(Querey, Connection);

            Command.Parameters.AddWithValue("@testid", TestID);

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


        public static bool Find(int TestID,ref int MemberId,ref int RankID,ref string Result,ref DateTime Date,ref int InstrecterID,ref int PaymentID)
        {
            bool IsFound = false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from Tests where TestID=@testid";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@testid", TestID);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    TestID = Convert.ToInt32(Reader[0]);
                    MemberId = Convert.ToInt32(Reader[1]);
                    MemberId = Convert.ToInt32(Reader[2]);
                    Result = Reader[3].ToString();
                   Date= Convert.ToDateTime(Reader[4]);
                    InstrecterID = Convert.ToInt32(Reader[5]);
                    PaymentID = Convert.ToInt32(Reader[6]);

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


        public static int GitNumberOfTest()
        {
            int NumberOfMember = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Query = "select Number = Count(*) from Tests";

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
    }
}
