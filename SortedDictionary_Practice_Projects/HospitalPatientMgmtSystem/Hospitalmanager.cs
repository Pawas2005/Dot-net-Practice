using System;
using System.Collections.Generic;
using System.Linq;
namespace HospitalManagemntSystem;

public class HospitalMangager
{
    private Dictionary<int, Patient> _patients = new Dictionary<int, Patient>();
    private Queue<Patient> _appointmentQueue = new Queue<Patient>();

    // Add a new patient to the system
    public void RegisterPatient(int id, string name, int age, string condition)
    {
        // TODO: Create patient and add to dictionary   
        Patient patient = new Patient(id, name, age, condition);
        _patients.Add(id, patient);
    }

    // Add patient to appointment queue
    public void ScheduleAppointment(int patientId)
    {
        // TODO: Find patient and add to queue
        _appointmentQueue.Enqueue(_patients[patientId]);
    }

    // Process next appointment (remove from queue)
    public Patient ProcessNextAppointment()
    {
        // TODO: Return and remove next patient from queue 
        return _appointmentQueue.Dequeue();
    }

    // Find patients with specific condition using LINQ
    public List<Patient> FindPatientsByCondition(string condition)
    {
        // TODO: Use LINQ to filter patients
        return _patients.Values.Where(p => p.Condition.Equals(condition, StringComparison.OrdinalIgnoreCase)).ToList();
    }
}