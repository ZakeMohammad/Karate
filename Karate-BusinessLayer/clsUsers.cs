using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Karate_DataAccessLayer;
namespace Karate_BusinessLayer
{
    public class clsUsers : clsPersons
    {
        public clsUsers(string username,int userid,int permission,int personid) 
        { 
            this.UserName= username;
            this.UserID=userid;
         this.Permissions= permission;
            this.PersonID=personid;
        }
        public clsUsers()
        {

        }

        enum enPermissions { ManageMebers=1,ManageUsers=2,ManageInstructors=4,ManageMemberInstructore=8,ManageSubscriptions=16,ManageBeltRanks=32,ManageBeltTests=64,ManagePayments=128}



        public int Permissions { get; set; }
        public int UserID { get; set; }
        public int PersonID { get; set; }
        public string UserName { get; set; }





        public static DataTable GitAllUsers()
        {
            return clsUsers_Data.GitALlUsers();
        }

        public static int GitNumberOfUsers()
        {
            return clsUsers_Data.GitNumberOfUsers();
        }

        public static  int AddNewUser(string username, int permission, int personid)
        {

            return clsUsers_Data.AddNewUser(username,permission,personid);
        }

        public static int UpdateUser( string Username, string Passwrod ,string Name,char Gender,string Email,string Phone, DateTime DateOfBirth, string Adrress, int Permissions ,string ImagePath)
        {                
          return clsUsers_Data.UpdateUser( Username, Passwrod, Name, Gender, Email, Phone, DateOfBirth, Adrress, Permissions,ImagePath);       
        }


        public static clsUsers Find(string username) 
        {
           int Userid = 0, Permissoin= 0, PersonId = 0;
          
            if( clsUsers_Data.Find(username,ref Userid,ref Permissoin,ref PersonId))
            {
                return new clsUsers(username,Userid,Permissoin,PersonId);
            }
            else
            {
                return null;
            }
           
        }


        public static bool DeleteUser(string Username) 
        {
            int ID = 0;

          clsUsers User=clsUsers.Find(Username);

            if( User!=null )
            {
                ID = User.PersonID;
               if(clsPersons_Data.DeletePerson(ID))
                {
                    return clsUsers_Data.DeleteUser(Username);
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public static bool IsExist(string Username)
        {
            return clsUsers_Data.IsExist(Username);
        }

        public static DataTable GitAllUsersByFeltarWithUsername(string username)
        {

            DataTable dt = clsUsers_Data.GitAllUsersByFeltarWithUsername(username);


            return dt;
        }

        public static DataTable GitAllUsersByFeltarWithUserID(int ID)
        {
            DataTable dt = clsUsers_Data.GitAllUsersByFeltarWithUserID(ID);
            return dt;
        }



    }
}
