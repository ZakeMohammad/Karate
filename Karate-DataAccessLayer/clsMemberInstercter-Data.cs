using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Karate_DataAccessLayer
{
  
    public class clsMemberInstercter_Data
    {

        public static  DataTable GitAllMemberInstructer()
        {
            DataTable dt= new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from MemberInstructorsTabel";

            SqlCommand Command=new SqlCommand(Querey,Connection);

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

        public static int AddMemberInstercter(string memberName, string instrectername,DateTime assigndate)
        {
            int MemberInstrcerID = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"insert into MemberInstructorsTabel (MemberName,InstructorName,AssignDate) values (@membername,@instructername,@assigndate); select SCOPE_IDENTITY();";

            SqlCommand Command= new SqlCommand(Querey,Conniction);

            Command.Parameters.AddWithValue("@membername", memberName);
            Command.Parameters.AddWithValue("@instructername", instrectername);
            Command.Parameters.AddWithValue("@assigndate",assigndate);

            try
            {
                Conniction.Open();

                object Ruslt = Command.ExecuteScalar();
                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int insertedID))
                {
                    MemberInstrcerID = insertedID;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                Conniction.Close();
            }
            return MemberInstrcerID;
        }

        public static int UpdateMemberInstructer(int memberinstructerid,string membername,string instrectername,DateTime assigndate)
        {
            int Ruslt = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"update MemberInstructorsTabel set MemberName=@membername , InstructorName=@instruname , AssignDate=@assigndate  where MemberInstructorID=@memberinstructerid";

            SqlCommand Command= new SqlCommand(Querey,Conniction);

            Command.Parameters.AddWithValue("@membername", membername);
            Command.Parameters.AddWithValue("@instruname",instrectername );
            Command.Parameters.AddWithValue("@assigndate",assigndate );
            Command.Parameters.AddWithValue("@memberinstructerid", memberinstructerid);

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

        public static int DeleteMemberInstructer(int memberinstructerid )
        {
            int Ruslt = 0;


            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"delete MemberInstructorsTabel where MemberInstructorID=@memberinstrctid;";
            SqlCommand Command= new SqlCommand(Querey,Conniction);

            Command.Parameters.AddWithValue("@memberinstrctid", memberinstructerid);

            try
            {
                Conniction.Open();

                int RowEffected = Command.ExecuteNonQuery();

                if (RowEffected > 0)
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


        public static bool Find(int memberinstructerid,ref string  Membername,ref string Instructername,ref DateTime assigndate)
        {
            bool IsFound = false;
            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);


            string Querey = @"select * from MemberInstructorsTabel where MemberInstructorID=@memberinstrctid;";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@memberinstrctid", memberinstructerid);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    memberinstructerid = Convert.ToInt32(Reader[0]);
                    Membername = Reader[1].ToString();
                    Instructername = Reader[2].ToString();
                    assigndate = (DateTime)Reader[3];
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

         public static DataTable GitAllMemberInstructerwithFiltter(int id=0,string membername="",string instutname="")
         {
            DataTable dt = new DataTable();

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "";

            if(id!=0)
            {
                Querey = "select * from MemberInstructorsTabel where MemberInstructorID like '" + id + "%'";
            }
         else if(membername!="")
            {
                Querey = "select * from MemberInstructorsTabel where MemberName like '" + membername + "%'";
            }
          else  if(instutname!="")
            {
                Querey = "select * from MemberInstructorsTabel where InstructorName like '" + instutname + "%'";
            }

            SqlCommand Command=new SqlCommand(Querey,Conniction);

            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
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



            return dt;

         }

        public static DataTable GitAllMemberNames()
        {
            DataTable dt = new DataTable();

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

           string Querey = "select Name from AllMembers";

            SqlCommand Command=new SqlCommand(Querey,Conniction);

            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
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
            return dt;
        }

        public static DataTable GitAllInstructrsNames()
        {
            DataTable dt = new DataTable();

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select Name from AllInstruchers";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
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

            return dt;
        }

        public static DataTable GitAllBeltsNames()
        {
            DataTable dt = new DataTable();


            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select Rank_Name from Belt_Ranks";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            try
            {
                Conniction.Open();
                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.HasRows)
                {
                    dt.Load(Reader);
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
            return dt;

        }


    }




}
