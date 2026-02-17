using System;
namespace YogaMeditation;

public class Meditation
{
    public int MemberId { get; set; }
    public int Age { get; set; }
    public double Weight { get; set; }
    public double Height { get; set; }
    public string Goal { get; set; }
    public double BMI { get; set; }

    public Meditation() {}

    public Meditation(int id, int age, double weight, double height, string goal, double bmi)
    {
        this.MemberId = id;
        this.Age = age;
        this.Weight = weight;
        this.Height = height;
        this.Goal = goal;
        this.BMI = bmi;
    }
}