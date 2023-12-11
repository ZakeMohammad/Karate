using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Karate_DataAccessLayer
{
    public class clsUsers_Data
    {
        public static DataTable GitALlUsers()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from AllUserss";

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

        public static int GitNumberOfUsers()
        {
            int NumberOfUsers = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Query = "select NumberOfUsers = Count(*) from AllUserss";

            SqlCommand Command = new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    NumberOfUsers = (int)Reader[0];
                }

            }
            catch (Exception ex)
            {

            }
            finally
            {
                Connection.Close();
            }
            return NumberOfUsers;
        }

        public static int AddNewUser(string username,int permission,int personid)
        {
            int userid = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"insert into Users (Username,Permissions,PersonID) values (@username,@permission,@personid); select SCOPE_IDENTITY();";

            SqlCommand Command=new SqlCommand(Querey,Conniction);

            Command.Parameters.AddWithValue("@username", username);
            Command.Parameters.AddWithValue("@permission", permission);
            Command.Parameters.AddWithValue("@personid", personid);

            try
            {
                Conniction.Open();

                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int insertedID))
                {
                    userid = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Conniction.Close();
            }
            return userid;
        }

        public static int UpdateUser(string Username, string password, string name, char gender, string email,string phoen, DateTime dateofbirth, string addrees , int permissions ,string imagepath)
        {
            int Ruslt = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"Update AllUserss set Password=@password, Name=@name,Gender=@gender,DateOfBirth=@date,Email=@email,Phone=@phone,Adrress=@adrress,ImagePath=@imagepath where Username=@username;
                                Update Users 
                                set Permissions=@permissoin
                                 where Username=@username; ";

            SqlCommand Command=new SqlCommand(Querey+ Querey,Conniction);

            Command.Parameters.AddWithValue("@username", Username);
            Command.Parameters.AddWithValue("@password", password);
            Command.Parameters.AddWithValue("@name", name);
            Command.Parameters.AddWithValue("@gender", gender);
            Command.Parameters.AddWithValue("@date", dateofbirth);
            Command.Parameters.AddWithValue("@email",email);
            Command.Parameters.AddWithValue("@phone", phoen);
            Command.Parameters.AddWithValue("@adrress", addrees);
            Command.Parameters.AddWithValue("@permissoin", permissions);
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

                if(RowEffected > 0)
                {
                    Ruslt = 1;
                }
            }
            catch(Exception e)
            {
                
            }
            finally
            {
                Conniction.Close();
            }


            return Ruslt;
        }

        public static bool DeleteUser(string Username)
        {
            bool IsDeleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"delete Users where Username=@username";
                             


            SqlCommand Command = new SqlCommand(Querey, Connection);

            Command.Parameters.AddWithValue("@username", Username);

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
        public static bool Find(string username,ref int Userid,ref int Permissoin,ref int PersonId)
        {
            bool IsFound=false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from Users where Username=@username";

                SqlCommand Command=new SqlCommand(Querey,Conniction);

            Command.Parameters.AddWithValue("@username", username);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.Read())
                {
                    IsFound= true;
                    Userid = Convert.ToInt32(Reader[0]);
                    username = Reader[1].ToString();
                    Permissoin = Convert.ToInt32(Reader[2]);
                    PersonId= Convert.ToInt32(Reader[3]);
                }
                Reader.Close();
            }
            catch(Exception e)
            { 
            
            }
            finally
            {
                Conniction.Close();
            }

            return IsFound;

        }

        public static bool IsExist(string Username)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select IsFound=1 from Users where UserName=@username";
            SqlCommand Command=new SqlCommand(Querey,Conniction);

            Command.Parameters.AddWithValue ("@username", Username);

            try
            {
                Conniction.Open();

                SqlDataReader Reader=Command.ExecuteReader();

                if(Reader.HasRows)
                {
                    IsExist= true;
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



        public static DataTable GitAllUsersByFeltarWithUsername(string Username)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from AllUserss where Username like '" + Username + "%'";

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

        public static DataTable GitAllUsersByFeltarWithUserID(int UserID )
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from AllUserss where UserID like '" + UserID + "%'";

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






    }
}
