using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;

namespace Karate_DataAccessLayer
{

    public class clsPersons_Data
    {

        public static DataTable GittALlPerson()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from Persons";

            SqlCommand Command=new SqlCommand(Querey,Connection);

            try 
            { 
                Connection.Open();

                SqlDataReader Reader= Command.ExecuteReader();

                if(Reader.HasRows) 
                {
                    dt.Load(Reader);
                }
                Reader.Close();

            }
            catch(Exception ex) 
            {
                
            }
            finally 
            {
                Connection.Close();
            } 

            return dt;
        }


        public static int AddNewPerson(string name,string passwrod,char gendar,DateTime dateofbirth,string emil,string phoen,string adrress ,string imagepath)
        {
            int id = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey ="insert into Persons (Name,Password,Gender,DateOfBirth,Email,Phone,Adrress,ImagePath) values (@name,@password,@gender,@date,@email,@phone,@adrress,@imagepath); select SCOPE_IDENTITY();";

            SqlCommand Command= new SqlCommand(Querey,Connection);
            Command.Parameters.AddWithValue("@name", name);
            Command.Parameters.AddWithValue("@password", passwrod);
            Command.Parameters.AddWithValue("@gender", gendar);
            Command.Parameters.AddWithValue("@date", dateofbirth);
            Command.Parameters.AddWithValue("@email", emil);
            Command.Parameters.AddWithValue("@phone", phoen);
            Command.Parameters.AddWithValue("@adrress", adrress);

            if(imagepath ==null)
            {
                imagepath=DBNull.Value.ToString();
                Command.Parameters.AddWithValue("@imagepath", imagepath);
            }
            else
            {              
                Command.Parameters.AddWithValue("@imagepath", imagepath);
            }


            try
            {
               Connection.Open();

                object Ruslt = Command.ExecuteScalar();

                if (Ruslt != null && int.TryParse(Ruslt.ToString(), out int insertedID))
                {
                    id = insertedID;
                }
            }
            catch 
            {

            }
            finally 
            {
                Connection.Close();
            }
            return id;
        }


        public static bool DeletePerson(int ID)
        {
            bool IsDeleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"delete Persons where PersonID=@id;
                                  ";


            SqlCommand Command = new SqlCommand(Querey, Connection);

            Command.Parameters.AddWithValue("@id", ID);


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


        public static bool Find(int ID,ref string name,ref string  Passwrod,ref char gendre,ref DateTime dateofbirht,ref string emil,ref string phone,ref string adrress,ref string imagepath)
        {
            bool IsFound = false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from Persons where PersonID=@id";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@id", ID);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                   
                    ID = Convert.ToInt32(Reader[0]);
                    name = Reader[1].ToString();
                    Passwrod = Reader[2].ToString();
                   gendre = Convert.ToChar(Reader[3]);
                    dateofbirht= (DateTime)Reader[4];
                    emil = Reader[5].ToString();
                    phone= Reader[6].ToString();
                    adrress = Reader[7].ToString();
                    imagepath = Reader[8].ToString();
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
