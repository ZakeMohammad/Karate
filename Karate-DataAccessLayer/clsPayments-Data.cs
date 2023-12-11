using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_DataAccessLayer
{
    public class clsPayments_Data
    {


        public static DataTable GittAllPayments()
        {
           DataTable dt= new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from AllPaymetnsDetelis";

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


        public static int AddNewPayment(int MemberID,DateTime PaymentDate,double Amount_Paid)
        {
            int PaymentID = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querye = @"insert into Payments (MemberID,PaymentDate,Amount_Paid) values (@memberid,@paymetnDate,@Amount_Paid); select SCOPE_IDENTITY(); ";

           SqlCommand Command=new SqlCommand(Querye,Connection);

            Command.Parameters.AddWithValue("@memberid", MemberID);
            Command.Parameters.AddWithValue("@paymetnDate", PaymentDate);
            Command.Parameters.AddWithValue("@Amount_Paid", Amount_Paid);

            try
            {
                Connection.Open();

                object Ruslt = Command.ExecuteScalar();

                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int insertedID))
                {
                    PaymentID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return PaymentID;
        }

        public static int UpdatePayment(int PaymentID,DateTime PaymentDate, double Amount_Paid)
        {
            int IsUpdated = 0;


            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"update Payments set  PaymentDate=@paymentdate , Amount_Paid=@amountpaid where PaymentID=@paymentid ;";

           SqlCommand Command= new SqlCommand(Querey,Connection);

            Command.Parameters.AddWithValue("@paymentdate", PaymentDate);
            Command.Parameters.AddWithValue("@amountpaid", Amount_Paid);
            Command.Parameters.AddWithValue("@paymentid", PaymentID);

            try
            {
                Connection.Open();

                int RowEffected = Command.ExecuteNonQuery();

                if (RowEffected > 0)
                {
                    IsUpdated = 1;
                }
            }
            catch (Exception e)
            {

            }
            finally
            {
                Connection.Close();
            }
            
            return IsUpdated;
        }

        public static int DeletePayment(int PaymentID)
        {
            int IsDeleted = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"delete Payments where PaymentID=@paymentid";

            SqlCommand Command=new SqlCommand(Querey,Connection);

            Command.Parameters.AddWithValue("@paymentid", PaymentID);

            try
            {
                Connection.Open();

                int RowEffected = Command.ExecuteNonQuery();

                if (RowEffected > 0)
                {
                    IsDeleted = 1;
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


        public static bool Find(int PaymentID, ref int MemberID,ref DateTime PaymentDate,ref double Amount_Paid)
        {
            bool isFound=false;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);


            string Querey = @"select * from Payments where PaymentID=@paymentid";

            SqlCommand Command = new SqlCommand(Querey, Connection);

            Command.Parameters.AddWithValue("@paymentid", PaymentID);

            try
            {
                Connection.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    isFound = true;
                    PaymentID = (int)Reader[0];
                    MemberID = (int)Reader[1];
                    PaymentDate = (DateTime)Reader[2];
                    Amount_Paid= Convert.ToDouble( Reader[3]);
                   
                }
                Reader.Close();
            }
            catch (Exception e)
            {

            }
            finally
            {
                Connection.Close();
            }

            return isFound;

        }


        public static DataTable GitLastesPayment()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from LastesPayment";

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

        public static int GitNumberOfPayments()
        {
            int NumberOfMember = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Query = "select Number = Count(*) from Payments";

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
