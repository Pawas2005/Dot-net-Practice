using System;
namespace Domain
{
    public class Student : BaseEntity
    {
        public string Name { get; set; }
        public double GPA { get; set; }

        public override void Validate()
        {
            if(GPA < 0 || GPA > 10)
            {
                throw new Exceptions.InvalidGPAException("GPA must be 0-10");
            }
            
        }
    }
}