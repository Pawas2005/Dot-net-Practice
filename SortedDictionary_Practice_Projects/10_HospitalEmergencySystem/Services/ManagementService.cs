using System.Collections.Generic;
using Domain;
using Exceptions;

namespace Services
{
    public class ManagementService
    {
        private SortedDictionary<int, Queue<Patient>> data = new SortedDictionary<int, Queue<Patient>>();

        public void AddPatient(Patient patient)
        {
            if(patient.SeverityLevel < 1 || patient.SeverityLevel > 5)
            {
                throw new InvalidSeverityLevelException("Severity level must between 1-5");
            }

            if (!data.ContainsKey(patient.SeverityLevel))
            {
                data[patient.SeverityLevel] = new Queue<Patient>();
            }
            
            data[patient.SeverityLevel].Enqueue(patient);
            Console.WriteLine("Patient Added Successfully.");
        }

        public void UpdateSeverity(string id, int level)
        {
            // TODO: Update logic
            if(level < 1 || level > 5)
            {
                throw new InvalidSeverityLevelException("Severity level must between 1-5");
            }

            foreach(var sevkey in data.Keys.ToList())
            {
                var queue = data[sevkey];
                var list = queue.ToList();
                var patient = list.FirstOrDefault(p => p.PatientId == id);

                if(patient != null)
                {
                    if(patient.SeverityLevel == 1)
                    {
                        throw new InvalidSeverityLevelException("Already highest level Priority");
                    }

                    patient.SeverityLevel = level;
                    Console.WriteLine("Updated Patient Severity Level");
                    return;
                }
            }
            throw new PatientNotFoundException("Patient Not found");
        }

        public void DisplayPatientsByPriority()
        {
            if(data.Count() <= 0)
            {
                Console.WriteLine("No patient data found");
                return;
            }

            foreach(var sevkey in data.Keys)
            {
                foreach(var s in data[sevkey])
                {
                    Console.WriteLine($"Details: {s.PatientId} {s.Name} Severity Level: {s.SeverityLevel}");
                }
            }
        }
    }
}
