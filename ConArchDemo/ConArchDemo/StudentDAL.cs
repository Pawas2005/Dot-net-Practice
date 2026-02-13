using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//For ADO.NET
using System.Data.SqlClient;
using System.Data;
using System.CodeDom;
using System.Diagnostics.Contracts;

namespace ConArchDemo
{
    /// <summary>
    /// Demo Code For Connected Architecture in StudentDAL class
    /// </summary>
    public class StudentDAL
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        SqlDataReader sdr = null;

        public StudentDAL()
        {
            con = new SqlConnection();
            con.ConnectionString = "Server=.\\Sqlexpress;Integrated Security=SSPI; Databse=LPU_Db";
        }
        public List<Student> ShowAllStudents()
        {
            List<Student> studList = null;
            //Code for Connected Architecture below
            try
            {
                con.Open();

                //for initializing the command object
                cmd = new SqlCommand();
                cmd.CommandText = "Select * from Students";
                cmd.Connection = con;
                cmd.CommandType = CommandType.Text;

                //Holding data via Reader
                sdr = cmd.ExecuteReader();

                DataTable myDt = new DataTable();

                myDt.Load(sdr);
                //convert Table into list
                foreach(DataRow drow in myDt.Rows)
                {
                    Student sObj = new Student()
                    {
                        RollNo = Convert.ToInt32(drow[0].ToString()),
                        Name = drow[1].ToString(),
                        Address = drow[3].ToString(),
                        PhoneNo = drow[5].ToString(),
                    };
                    if(sObj != null)
                    {
                        studList.Add(sObj);
                    }
                }
            }
            catch (SqlException e)
            {
                throw e;
            }
            finally
            {
                con.Close();
            }

            return studList;
        }

        public List<Student> SearchByName(string Name)
        {
            List<Student> studList = null;

            return studList;
        }

        public Student SearchByRollNo(int id)
        {
            Student tempObj = null;

            return tempObj;
        }
    }
}
