using Karate_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Runtime.InteropServices;

namespace Karate_BusinessLayer
{
    public class clsMembers : clsPersons
    {

        clsMembers(int memberid, int lastbelt,string isactive,int personid) 
        {
            this.LastBeltRank=lastbelt;
            this.MemberID=memberid;
            this.PersonID=personid;
            this.IsActive = isactive;
        }
        clsMembers(string Name,int memberid, int lastbelt, string isactive, int personid)
        {
            this.LastBeltRank = lastbelt;
            this.MemberID = memberid;
            this.PersonID = personid;
            this.IsActive = isactive;
            this.Name= Name;
        }


        public clsMembers()
        {

        }

        public int LastBeltRank { get; set; }
        public int MemberID { get; set; }
        public int PersonID { get; set; }
        public string IsActive { get; set; }

        public string Name { get; set; }

        public static DataTable GitAllMembers()
        {
            return clsMember_Data.GitALlMembers();
        }

        public static int GitNumberOfMembers()
        {
            return clsMember_Data.GitNumberOfMembers();
        }

       
        public static DataTable GitAllMemberByFeltarWithName(string name)
        {
            return clsMember_Data.GitAllMemberByFeltarWithName(name);
        }

        public static DataTable GitAllMemberByFeltarWithMemberID(int id)
        {
            return clsMember_Data.GitAllMemberByFeltarWithMemberID(id);
        }


        public static int AddNewMember(int lastbelt,string isactive, int personid)
        {

            return clsMember_Data.AddNewMember(lastbelt, isactive, personid);
        }

        public static int UpdateMember(int MemberID , string Passwrod, string Name, char Gender, string Email, string Phone, DateTime DateOfBirth, string Adrress,string isactive, int lastbelt, string ImagePath)
        {
            return clsMember_Data.UpdateMember(MemberID, Passwrod, Name, Gender, Email, Phone, DateOfBirth, Adrress, isactive, lastbelt, ImagePath);
        }


        public static clsMembers Find(int MemberID)
        {
            string  isactive = ""; int personid = 0;
            int lastbelt = 0;
            if (clsMember_Data.Find(MemberID,ref lastbelt,ref isactive,ref personid))
            {
                return new clsMembers(MemberID,lastbelt,isactive,personid);
            }
            else
            {
                return null;
            }

        }


        public static clsMembers Find(string Name)
        {
            string isactive = ""; int personid = 0 , MemberID=0;
            int lastbelt = 0;
            if (clsMember_Data.Find(Name,ref MemberID, ref lastbelt, ref isactive, ref personid))
            {
                return new clsMembers(Name,MemberID, lastbelt, isactive, personid);
            }
            else
            {
                return null;
            }

        }





        public static bool DeleteMember(int MemberID)
        {
            int ID = 0;

            clsMembers Member = clsMembers.Find(MemberID);
            if (Member != null)
            {
                ID = Member.PersonID;
                if (clsMember_Data.DeleteMember(MemberID))
                {

                    return clsPersons_Data.DeletePerson(ID);
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public static bool IsExist(int MemberID )
        {
            return clsMember_Data.IsExist(MemberID);
        }

    }
}
