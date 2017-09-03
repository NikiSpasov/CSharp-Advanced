using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

public class StartUp
{
    public static void Main()
    {
        Printer printer = new Printer();

        string input;

        Dictionary<string, Department> departments = new Dictionary<string, Department>();

        Dictionary<string, Doctor> allDoctors = new Dictionary<string, Doctor>();

        while ((input = Console.ReadLine()) != "Output")
        {
            var tokens = input.Split(new[] { ' ' },
                    StringSplitOptions.RemoveEmptyEntries)
                   .ToList();
            var deptName = tokens[0];
            var doctorsName = tokens[1] + " " + tokens[2];
            var patientName = tokens[3];

            if (!allDoctors.ContainsKey(doctorsName))
            {
                allDoctors.Add(doctorsName, new Doctor(doctorsName));
                allDoctors[doctorsName].Patients.Add(new Patient(patientName));
            }

            else
            {
                allDoctors[doctorsName].Patients.Add(new Patient(patientName));
            }

            if (!departments.ContainsKey(deptName))
            {
                Department currentDept = new Department(deptName);
                currentDept.PatientsInDept.Add(new Patient(patientName));
                departments.Add(deptName, currentDept);
            }
            else
            {
                departments[deptName].PatientsInDept.Add(new Patient(patientName));
            }
        }

        string endCommand;

        while ((endCommand = Console.ReadLine()) != "End")
        {
            printer.Print(endCommand, departments, allDoctors);
        }
    }
}

public class Department
{
    public List<Patient> PatientsInDept;
    public string Name { get; set; }

    public Department(string name)
    {
        this.Name = name;
        this.PatientsInDept = new List<Patient>(60);
    }
}

public class Patient
{
    public Patient(string name)
    {
        this.Name = name;
    }

    public string Name { get; set; }
}

public class Doctor
{
    public string Name;
    public List<Patient> Patients;

    public Doctor(string name)
    {
        this.Name = name;
        this.Patients = new List<Patient>();
    }
}

public class Printer
{
    public void Print(string command, Dictionary<string, Department> departments, Dictionary<string, Doctor> allDoctors)
    {
        string[] tokens = command.Split(new[] { ' ' },
            StringSplitOptions.RemoveEmptyEntries);

        int roomNum;

        string infoToPrint = tokens[0];

        if (tokens.Length == 1)
        {
            if (departments.ContainsKey(infoToPrint))
            {
                departments[infoToPrint].PatientsInDept.ForEach(x => Console.WriteLine(x.Name));
            }
        }

        else if (int.TryParse(tokens[1], out roomNum))
        {
            if (departments.ContainsKey(infoToPrint))
            {
                foreach (var patient in departments[infoToPrint].PatientsInDept
                    .Skip((roomNum - 1) * 3).Take(3).OrderBy(x => x.Name))
                {
                    Console.WriteLine(patient.Name);
                }
            }
        }

        else
        {
            string doctorName = infoToPrint + " " + tokens[1];
            if (allDoctors.ContainsKey(doctorName))
            {
                foreach (var patient in allDoctors[doctorName].Patients.OrderBy(x => x.Name))
                {
                    Console.WriteLine(patient.Name);
                }
            }
        }
    }
}

