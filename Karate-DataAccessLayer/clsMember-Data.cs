using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace Karate_DataAccessLayer
{
    public class clsMember_Data
    {

        public static DataTable GitALlMembers()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from MembersData";

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


        public static DataTable GitAllMemberByFeltarWithName(string name)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from MembersData where Name like '" + name+"%'";

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
        public static DataTable GitAllMemberByFeltarWithMemberID(int ID)
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from MembersData where MemberID like '" + ID+"%'";

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


        public static int GitNumberOfMembers()
        {

            int NumberOfMember = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Query = "select NumberOfMember = Count(*) from AllMembers";

            SqlCommand Command= new SqlCommand(Query, Connection);

            try
            {
                Connection.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if(Reader.Read())
                {
                    NumberOfMember = (int)Reader[0];
                }

            }
            catch(Exception ex)
            {

            }
            finally 
            { 
                Connection.Close(); 
            }
            return NumberOfMember;
        }

        public static int AddNewMember(int LastBelt, string IsActive, int personid)
        {
            int memberid = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"insert into Members (Last_Belt,Is_Active,PersonID) values (@last_belt,@is_active,@personid); select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@last_belt", LastBelt);
            Command.Parameters.AddWithValue("@is_active", IsActive);
            Command.Parameters.AddWithValue("@personid", personid);

            try
            {
                Conniction.Open();

                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int insertedID))
                {
                    memberid = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Conniction.Close();
            }
            return memberid;
        }

        public static int UpdateMember(int MemberID, string password, string name, char gender, string email, string phoen, DateTime dateofbirth, string addrees, string IsActive, int LastBelt, string imagepath)
        {
            int Ruslt = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"Update MembersData set Password=@password, Name=@name,Gender=@gender,DateOfBirth=@date,Email=@email,Phone=@phone,Adrress=@adrress,ImagePath=@imagepath where MemberID=@memberid;
                                Update Members 
                                set Last_Belt=@lastbelt , Is_Active=@isactive
                                 where MemberID=@memberid; ";

            SqlCommand Command = new SqlCommand(Querey + Querey, Conniction);

            Command.Parameters.AddWithValue("@MemberID", MemberID);
            Command.Parameters.AddWithValue("@password", password);
            Command.Parameters.AddWithValue("@name", name);
            Command.Parameters.AddWithValue("@gender", gender);
            Command.Parameters.AddWithValue("@date", dateofbirth);
            Command.Parameters.AddWithValue("@email", email);
            Command.Parameters.AddWithValue("@phone", phoen);
            Command.Parameters.AddWithValue("@adrress", addrees);
            Command.Parameters.AddWithValue("@lastbelt", LastBelt);
            Command.Parameters.AddWithValue("@isactive", IsActive);
            if (imagepath != null || imagepath != "")
            {
                Command.Parameters.AddWithValue("@imagepath", imagepath);
            }
            else
            {
                imagepath = "";
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

        public static bool DeleteMember(int MemberID)
        {
            bool IsDeleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"delete Members where MemberID=@memberid";

            SqlCommand Command = new SqlCommand(Querey, Connection);

            Command.Parameters.AddWithValue("@memberid", MemberID);

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

        public static bool Find(int MemberID, ref int Last_Belt, ref string Is_Active, ref int PersonId)
        {
            bool IsFound = false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from Members where MemberID=@memberid";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@memberid", MemberID);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    MemberID = Convert.ToInt32(Reader[0]);
                    Last_Belt = Convert.ToInt32( Reader[1]);
                    Is_Active = (Reader[2]).ToString();
                    PersonId = Convert.ToInt32(Reader[3]);
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

        public static bool Find(string Name, ref int MemberID, ref int Last_Belt, ref string Is_Active, ref int PersonId)
        {
            bool IsFound = false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from FindmemberByName where Name=@name";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@name", Name);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    MemberID = Convert.ToInt32(Reader[0]);
                    Name = Reader[1].ToString();
                    Last_Belt = Convert.ToInt32(Reader[2]);
                    Is_Active = (Reader[3]).ToString();
                    PersonId= Convert.ToInt32(Reader[4]);
              
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




        public static bool IsExist(int MemberID)
        {
            bool IsExist = false;
            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select IsFound=1 from Members where MemberID=@memberid";
            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@memberid", MemberID);

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

    }
}
