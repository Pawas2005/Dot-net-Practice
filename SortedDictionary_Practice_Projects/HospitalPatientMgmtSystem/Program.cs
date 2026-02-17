using System;
namespace HospitalManagemntSystem;

public class Program
{
    public static void Main()
    {
        HospitalMangager manager = new HospitalMangager();
        manager.RegisterPatient(1, "John Doe", 45, "Hypertension");
        manager.RegisterPatient(2, "Jane Smith", 32, "Diabetes");
        manager.ScheduleAppointment(1);
        manager.ScheduleAppointment(2);

        var nextPatient = manager.ProcessNextAppointment();
        Console.WriteLine(nextPatient.Name); // Should output: John Doe

        var diabeticPatients = manager.FindPatientsByCondition("Diabetes");
        Console.WriteLine(diabeticPatients.Count); // Should output: 1
    }
}