using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_DataAccessLayer
{
    public class clsInstruchers_Data
    {
        public static DataTable GitALlInstructors()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from AllInstruchers";

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

        public static int GitNumberOfInstructors()
        {
            int NumberOfInstructor = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Query = "select NumberOfInstructor = Count(*) from AllInstruchers";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    NumberOfInstructor = (int)Reader[0];
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return NumberOfInstructor;
        }
        public static DataTable GitAllInstructorByFeltarWithMemberID(int FeltarID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from AllInstruchers where InstrucherID like '" + FeltarID + "%'";

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

        public static int AddNewInstructor(int personid)
        {
            int InstrucherID = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"insert into Instruchers (PersonID) values (@personid); select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Querey, Conniction);      
            Command.Parameters.AddWithValue("@personid", personid);

            try
            {
                Conniction.Open();

                object Ruslt = Command.ExecuteScalar();

                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int insertedID))
                {
                    InstrucherID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Conniction.Close();
            }
            return InstrucherID;
        }

        public static int UpdateInstructor(int InstructorID, string password, string name, char gender, string email, string phoen, DateTime dateofbirth, string addrees , string imagepath)
        {
            int Ruslt = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"Update AllInstruchers set Password=@password, Name=@name,Gender=@gender,DateOfBirth=@date,Email=@email,Phone=@phone,Adrress=@adrress,ImagePath=@imagepath where InstrucherID=@instructid;";

            SqlCommand Command = new SqlCommand(Querey + Querey, Conniction);

            Command.Parameters.AddWithValue("@instructid", InstructorID);
            Command.Parameters.AddWithValue("@password", password);
            Command.Parameters.AddWithValue("@name", name);
            Command.Parameters.AddWithValue("@gender", gender);
            Command.Parameters.AddWithValue("@date", dateofbirth);
            Command.Parameters.AddWithValue("@email", email);
            Command.Parameters.AddWithValue("@phone", phoen);
            Command.Parameters.AddWithValue("@adrress", addrees);
            if (imagepath != null || imagepath != "")
            {
                Command.Parameters.AddWithValue("@imagepath", imagepath);
            }
            else
            {
                imagepath = "None";
                Command.Parameters.AddWithValue("@imagepath", imagepath);
            }

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

        public static bool DeleteInstructer(int InstructidID)
        {
            bool IsDeleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"delete Instruchers where InstrucherID =@instructer";

            SqlCommand Command = new SqlCommand(Querey, Connection);

            Command.Parameters.AddWithValue("@instructer",InstructidID);

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
        public static bool Find(int InstructerID ,ref int PersonId)
        {
            bool IsFound = false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from Instruchers where InstrucherID=@instructer";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@instructer", InstructerID);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    InstructerID = Convert.ToInt32(Reader[0]);               
                    PersonId = Convert.ToInt32(Reader[1]);
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

        public static bool IsExist(int InstructerID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select IsFound=1 from Instruchers where InstrucherID=@instructer";
            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@instructer", InstructerID);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    IsExist = true;
                }
                Reader.Close();
            }
            catch
            (
            Exception e)
            {

            }
            finally
            {
                Conniction.Close();
            }

            return IsExist;
        }




        public static bool Find(string Name,ref int instrcterid, ref int PersonId)
        {
            bool IsFound = false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from FindInstrcterByName where Name=@name";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@name", Name);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    instrcterid = Convert.ToInt32(Reader[0]);
                    Name = Reader[1].ToString();
                    PersonId = Convert.ToInt32(Reader[2]);

                    PersonId = Convert.ToInt32(Reader[2]);

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



    }
}
