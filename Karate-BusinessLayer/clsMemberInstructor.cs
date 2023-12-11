using Karate_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
using System.Threading.Tasks;

namespace Karate_BusinessLayer
{

    public class clsMemberInstructor
    {
        public clsMemberInstructor(int id,string membername,string instructname,DateTime assignname)
        {
            this.AssignDate = assignname;
            this.InstructerName= instructname;
            this.MemberInstructerID= id;
            this.MemberName= membername;
        }
        public clsMemberInstructor() 
        {

        }

        public int MemberInstructerID { get; set; }

        public string MemberName { get; set; }  

        public string InstructerName { get; set; }

        public DateTime AssignDate { get; set; }



        public static DataTable GitAllMemberInstructer ()
        {
            return clsMemberInstercter_Data.GitAllMemberInstructer();
        }


        public static int AddMemberInstercter(string memberName,string instrectername,DateTime assigndate)
        {
                    
     
            clsMembers Member=clsMembers.Find(memberName);

            if(Member!=null)
            {
                if(Member.IsActive=="Yes")
                {
                    return 2;
                }
                else
                {
                    if (clsMemberInstercter_Data.AddMemberInstercter(memberName, instrectername, assigndate) != 0)
                    {
                        Member.IsActive ="Yes";
                        return 1;
                    }
                    else
                        return 0;
                }
            }

            return 0;
        }

        public static int UpdateMemberInstructer(int memberinstructerid, string membername, string instrectername, DateTime assigndate)
        {
            clsMembers Member = clsMembers.Find(membername);

            if (Member != null)
            {
                if (Member.IsActive == "Yes")
                {
                    return 2;
                }
                else
                {
                    
                }

            }

            int Rustl = clsMemberInstercter_Data.UpdateMemberInstructer(memberinstructerid, membername, instrectername, assigndate);

            return Rustl ;
        }

        public static clsMemberInstructor Find(int memberinstructerid)
        {
            string membername = "", Insterctername = "";
            DateTime assigndate=DateTime.Now;
           
            if(clsMemberInstercter_Data.Find(memberinstructerid,ref membername, ref Insterctername,ref assigndate))
            {
                return new clsMemberInstructor(memberinstructerid,membername,Insterctername, assigndate);
            }
            else
            {
                return null;
            }
        }

        public static int DeleteMemberInstrect(int memberinstructerid)
        {

            if(clsMemberInstercter_Data.DeleteMemberInstructer(memberinstructerid)!=0)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }


        public static DataTable GitAllMemberInstructerwithFiltter(int id=0,string membername="",string instructname="")
        {
         return clsMemberInstercter_Data.GitAllMemberInstructerwithFiltter(id,membername,instructname);
        }

        public static DataTable GitAllMemberNames()
        {
            return clsMemberInstercter_Data.GitAllMemberNames();
        }
        public static DataTable GitAllInstructrsNames()
        {
            return clsMemberInstercter_Data.GitAllInstructrsNames();
        }

        public static DataTable GitAllBeltsNames()
        {
            return clsMemberInstercter_Data.GitAllBeltsNames();
        }

    }




}
