using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_DataAccessLayer
{
    public class clsBeltRanks_Data
    {

        public static DataTable GittAllBeltRanks()
        {
            DataTable dt = new DataTable();

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "select * from Belt_Ranks";

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

        public static int AddNewBeltRank(string BeltName,int TestFees)
        {
            int id = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "insert into Belt_Ranks (Rank_Name,Test_Fees) values (@beltrank,@testsfees); select SCOPE_IDENTITY();";

            SqlCommand Command = new SqlCommand(Querey, Connection);

            Command.Parameters.AddWithValue("@beltrank", BeltName);
            Command.Parameters.AddWithValue("@testsfees", TestFees);


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


        public static bool Find(int ID, ref string RankName, ref int TestsFees)
        {
            bool IsFound = false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from Belt_Ranks where RankID=@id";

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
                    RankName = Reader[1].ToString();
                    TestsFees= Convert.ToInt32(Reader[2]);
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

        public static bool DeleteBeltRank(int ID)
        {
            bool IsDeleted = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"delete Belt_Ranks where RankID=@id;";


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

        public static int UpdateBeltRank(int RankID, string RankName, int TestFees)
        {
            int Ruslt = 0;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"Update Belt_Ranks set Rank_Name=@rankname,Test_Fees=@testfees where RankID=@id;";
                               

            SqlCommand Command = new SqlCommand(Querey + Querey, Conniction);

            Command.Parameters.AddWithValue("@id", RankID);
            Command.Parameters.AddWithValue("@rankname", RankName);
            Command.Parameters.AddWithValue("@testfees", TestFees);
           
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


        public static DataTable Fillter(int id=0,string name="",int testFees = 0)
        {
            DataTable dataTable= new DataTable();

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = "";

            if(id!=0)
            {
                Querey = "select * from Belt_Ranks where RankID like '"+id+"%'";
            }
            if(name!="")
            {
                Querey = "select * from Belt_Ranks where Rank_Name like '"+name+"%'";
            }
            if(testFees!=0)
            {
                Querey = "select * from Belt_Ranks where Test_Fees like '"+testFees+"%'";
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




        public static bool Find(string Name, ref int rankid)
        {
            bool IsFound = false;

            SqlConnection Conniction = new SqlConnection(clsDataAccessConnictonString.ConnictionString);

            string Querey = @"select * from Belt_Ranks  where Rank_Name=@name";

            SqlCommand Command = new SqlCommand(Querey, Conniction);

            Command.Parameters.AddWithValue("@name", Name);

            try
            {
                Conniction.Open();

                SqlDataReader Reader = Command.ExecuteReader();

                if (Reader.Read())
                {
                    IsFound = true;
                    rankid = Convert.ToInt32(Reader[0]);
                    Name = Reader[1].ToString();                 
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
