using System;
namespace HospitalManagemntSystem;

public class Patient
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Age { get; set; }
    public string Condition { get; set; }

    public Patient(int id, string name, int age, string condition)
    {
        this.Id = id;
        this.Name = name;
        this.Age = age;
        this.Condition = condition;
    }
}