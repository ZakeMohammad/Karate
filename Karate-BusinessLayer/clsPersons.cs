using Karate_DataAccessLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Karate_BusinessLayer
{

    public class clsPersons
    {

        public clsPersons(int id,string name,string password,char gender,DateTime dateofbirth,string emil,string phoen,string adrress,string imagepath)           
        {
            this.ID= id;
            this.Name= name;
            this.Passwrod= password;
            this.Gender=gender;
            this.DateOfBirth= dateofbirth;
            this.Adrress= adrress;
            this.Email= emil;
            this.ImagePath= imagepath;
            this.Phone= phoen;
        
        }

        public clsPersons ()
        {

        }
        public int ID { get; set; }
        public string Name { get; set; }

        public string Passwrod { get; set; }

        public char Gender { get; set; }

        public DateTime  DateOfBirth { get; set; }

        public string Phone { get; set; }
        public string Email { get; set; }

        public string Adrress { get; set; }
        public string ImagePath { get; set; }


        public static DataTable GitAllPersons()
        {
          return  clsPersons_Data.GittALlPerson();
        }

        public int AddNewPerson()
        {
            return clsPersons_Data.AddNewPerson(this.Name,this.Passwrod,this.Gender,this.DateOfBirth,this.Email,this.Phone,this.Adrress,this.ImagePath);
        }

        public static clsPersons Find(int ID)
        {
            string name = "", passwrod = "", email = "", phone = "", adrress = "", imagepath = "";
            char gendre = ' ';
            DateTime dateofbirth= DateTime.Now;

            if(clsPersons_Data.Find(ID,ref name,ref passwrod,ref gendre,ref dateofbirth,ref email,ref phone,ref adrress,ref imagepath))
            {
                return new clsPersons(ID,name,passwrod,gendre,dateofbirth,email,phone,adrress,imagepath);
            }
            else
            {
                return null;
            }


        }





    }




}
