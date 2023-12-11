using Karate_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Karate_BusinessLayer
{
    public class clsInstruchers : clsPersons
    {
        public int PersonID { get; set; }

        public int InstruchersID { get; set; }

        public string Name { get; set; }

      public  clsInstruchers(int InstruchersID,int personid) 
        {
            this.InstruchersID = InstruchersID;
            this.PersonID = personid;
        }


       public clsInstruchers(string InstrecterName,int instercterid,int personid) 
        {
            this.PersonID = personid;
            this.Name= InstrecterName;
            this.InstruchersID= instercterid;
        }


        public clsInstruchers()
        {

        }



        public static DataTable GitAllInstruchers()
        {
            return clsInstruchers_Data.GitALlInstructors();
        }
        public static DataTable GitAllInstructorByFeltarWithMemberID(int FeltarID)
        {
            return clsInstruchers_Data.GitAllInstructorByFeltarWithMemberID(FeltarID);
        }

        public static int GitNumberOfInstructor()
        {
            return clsInstruchers_Data.GitNumberOfInstructors();
        }

        public static int AddNewInstruchers( int personid)
        {

            return clsInstruchers_Data.AddNewInstructor(personid) ;
        }

        public static int UpdateInstruchers(int InstruchersID, string Passwrod, string Name, char Gender, string Email, string Phone, DateTime DateOfBirth, string Adrress, string ImagePath)
        {
            return clsInstruchers_Data.UpdateInstructor(InstruchersID,  Passwrod,  Name,  Gender,  Email,  Phone,  DateOfBirth,  Adrress,ImagePath);
        }


        public static clsInstruchers Find(int InstruchersID)
        {
            int personid = 0;        
            if (clsInstruchers_Data.Find(InstruchersID, ref personid))
            {
                return new clsInstruchers(InstruchersID,personid) ;
            }
            else
            {
                return null;
            }

        }


        public static bool DeleteInstruchers(int InstruchersID)
        {
            int ID = 0;

            clsInstruchers Instruchers = clsInstruchers.Find(InstruchersID);
            if (Instruchers != null)
            {
                ID = Instruchers.InstruchersID;

                if (clsPersons_Data.DeletePerson(ID))
                {
                    return clsInstruchers_Data.DeleteInstructer(InstruchersID);
                }
            }
            else
            {
                return false;
            }

            return false;
        }

        public static bool IsExist(int InstruchersID)
        {
            return clsInstruchers_Data.IsExist(InstruchersID);
        }



        public static clsInstruchers Find(string Name)
        {
            int personid = 0,instercterid=0;

            if(clsInstruchers_Data.Find(Name,ref instercterid, ref personid))
            {
                return new clsInstruchers(Name,instercterid, personid);
            }
            else
            { 
                return null; 
            }
          
        }






    }
}
