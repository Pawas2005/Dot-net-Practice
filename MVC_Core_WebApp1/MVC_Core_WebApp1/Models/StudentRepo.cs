using System;
using System.Collections.Generic;

namespace MVC_Core_WebApp1.Models
{
    public class StudentRepo : IRepo<Student>
    {
        public static List<Student> studList = null;

        public StudentRepo()
        {
            if (studList == null)
            {
                //Collection Initializer
                studList = new List<Student>()
                {
                    new Student() {RollNo = 101, Name = "Alok", Age = 22, Address = "Pune" },
                    new Student() {RollNo = 102, Name = "Amit", Age = 24, Address = "Mumbai" }
                };
            }
        }
        public bool AddData(Student obj)
        {
            bool flag = false;
            if(obj != null)
            {
                studList.Add(obj);
                flag = true;
            }
            else
            {
                throw new NullReferenceException("Object is not Initialized");
            }
            return flag;
        }

        public bool DeleteData(int id)
        {
            bool flag = false;
            Student sObj = studList.Find(s => s.RollNo == id);
            if (sObj != null)
            {
                studList.Remove(sObj);
                flag = true;
            }
            return flag;
        }

        public List<Student> ShowAllData()
        {
            return studList;
        }

        public Student ShowDetailsByID(int id)
        {
            Student sObj = studList.Find(s => s.RollNo == id);
            return sObj;
        }

        public bool UpdateData(int id, Student obj)
        {
            bool flag = false;
            Student sObj = studList.Find(s => s.RollNo == id);
            if (sObj != null)
            {
                sObj.Name = obj.Name;
                sObj.Age = obj.Age;
                sObj.Address = obj.Address;
                flag = true;
            }
            return flag;
        }
    }
}
