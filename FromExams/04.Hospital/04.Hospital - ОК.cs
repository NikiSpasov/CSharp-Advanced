namespace _04.Hospital
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    public class Hospital
    {
        public static void Main()
        {
            string input = Console.ReadLine();

            Dictionary<string, List<string>> doctorPatients = new Dictionary<string, List<string>>();

            Dictionary<string, Queue<string>> deptPatients = new Dictionary<string, Queue<string>>();

            while (input != "Output")
            {
                var info = input
                    .Split(' ')
                    .ToList();

                string dept = info[0];
                string doc = $"{info[1]} {info[2]}";
                string patient = info[3];

                Queue<string> patientsQueue = new Queue<string>();


                if (!doctorPatients.ContainsKey(doc))
                {
                    List<string> patients = new List<string>();
                    doctorPatients.Add(doc, patients);
                }
                doctorPatients[doc].Add(patient);

                if (!deptPatients.ContainsKey(dept))
                {
                    deptPatients.Add(dept, patientsQueue);
                }
                if (patientsQueue.Count < 21)
                {
                deptPatients[dept].Enqueue(patient);
                }

                input = Console.ReadLine();
            }
            string command = Console.ReadLine();

            while (command != "End")
            {
                string[] output = command
                    .Split(' ')
                    .ToArray();
                if (output.Length > 1)
                {
                    string doctorsNameOrDeptRoom = $"{output[0]} {output[1]}";

                    if (doctorPatients.ContainsKey(doctorsNameOrDeptRoom))
                    {
                        foreach (var patient in doctorPatients[doctorsNameOrDeptRoom].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        string currentDept = output[0];
                        int room = int.Parse(output[1]);
                        Console.WriteLine
                            (String.Join(Environment.NewLine,
                             deptPatients[currentDept]
                            .Skip((room - 1) * 3)
                            .Take(3)
                            .OrderBy(x => x)));
                    }
                }
                else
                {
                    foreach (var patient in deptPatients[output[0]])
                    {
                        Console.WriteLine(patient);
                    }
                }
                command = Console.ReadLine();
            }
        }
    }
}