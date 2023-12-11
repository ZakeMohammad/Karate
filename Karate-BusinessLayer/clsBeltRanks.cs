using Karate_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Karate_BusinessLayer
{
    public class clsBeltRanks
    {
        public clsBeltRanks(int BeltID, string BeltName, int TestsFees)
        {
            this.BeltID = BeltID;
            this.BeltName = BeltName;
            this.TestsFees = TestsFees;
        }

        public clsBeltRanks(string name,int rankid)
        {
            this.BeltName=name;
            this.BeltID=rankid;
        }
        public clsBeltRanks()
        {

        }
        public int BeltID { get; set; }

        public string BeltName { get; set; }

        public int TestsFees { get; set; }


        public static DataTable GittAllBeltRanks()
        {
            return clsBeltRanks_Data.GittAllBeltRanks();
        }


        public static int AddNewBeltRank(string BeltName, int TestsFees)
        {
            return clsBeltRanks_Data.AddNewBeltRank(BeltName, TestsFees);

            //if(this.BeltID > 0)
            //{
            //     return new clsBeltRanks(this.BeltID, this.BeltName, this.TestsFees);
            //}
            // else
            // {
            //     return null;
            // }

        }


        public static clsBeltRanks Find(int RankID)
        {
            string RankName = "";
            int TestFees = 0;

            if (clsBeltRanks_Data.Find(RankID, ref RankName, ref TestFees))
            {
                return new clsBeltRanks(RankID, RankName, TestFees);
            }
            else
                return null;

        }

        public static bool DeleteBeltRank(int RankID)
        {
            if (clsBeltRanks_Data.DeleteBeltRank(RankID))            
              return true;
            else
                return false;


        }


        public static int UpdateBeltRank(int id,string name,int TestsFees)
        {
            return clsBeltRanks_Data.UpdateBeltRank(id, name, TestsFees);
        }

        public static DataTable Fillter(int id=0,string name="",int TestsFees=0)
        {
            return clsBeltRanks_Data.Fillter(id, name, TestsFees);
        }

        public static clsBeltRanks Find(string Name)
        {
            int rankid = 0;

            if(clsBeltRanks_Data.Find(Name,ref rankid))
            {
                return new clsBeltRanks(Name, rankid);
            }
            else
                return null;
        }

    }
    
}
