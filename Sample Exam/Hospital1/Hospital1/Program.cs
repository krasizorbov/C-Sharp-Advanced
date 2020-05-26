using System;
using System.Collections.Generic;
using System.Linq;

namespace Hospital
{
    class Program
    {
        static void Main(string[] args)
        {
            var hospital = new Dictionary<string, Dictionary<int, List<string>>>();
            var doctorPatients = new Dictionary<string, List<string>>();

            string text = string.Empty;

            while ((text = Console.ReadLine()) != "Output")
            {
                string[] info = text.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                string department = info[0];
                string doctor = info[1] + " " + info[2];
                string patient = info[3];

                if (!doctorPatients.ContainsKey(doctor))
                {
                    doctorPatients.Add(doctor, new List<string>());
                }

                doctorPatients[doctor].Add(patient);

                if (hospital.ContainsKey(department))
                {
                    if (hospital[department].Values.Count > 20)
                    {
                        continue;
                    }
                    else
                    {
                        if (hospital[department][hospital[department].Values.Count].Count == 3)
                        {
                            hospital[department].Add(hospital[department].Values.Count + 1, new List<string>());
                            hospital[department][hospital[department].Values.Count].Add(patient);
                        }
                        else
                        {
                            hospital[department][hospital[department].Values.Count].Add(patient);
                        }
                    }
                }
                else
                {
                    hospital.Add(department, new Dictionary<int, List<string>>());
                    hospital[department].Add(1, new List<string>());
                    hospital[department][1].Add(patient);
                }
            }

            string command = string.Empty;

            while ((command = Console.ReadLine().Trim()) != "End")
            {
                string[] input = command.Split(" ", StringSplitOptions.RemoveEmptyEntries).ToArray();

                if (input.Length == 1)
                {
                    string department = input[0];

                    if (hospital.ContainsKey(department))
                    {
                        foreach (var dep in hospital[department])
                        {
                            foreach (var patient in dep.Value)
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
                else
                {
                    string doctorsFirstName = input[0];
                    string doctorsSecondName = input[1];

                    if (doctorPatients.ContainsKey(doctorsFirstName + " " + doctorsSecondName))
                    {
                        foreach (var patient in doctorPatients[doctorsFirstName + " " + doctorsSecondName].OrderBy(x => x))
                        {
                            Console.WriteLine(patient);
                        }
                    }
                    else
                    {
                        string department = input[0];
                        int roomNumber = int.Parse(input[1]);

                        if (hospital.ContainsKey(department) && hospital[department].ContainsKey(roomNumber))
                        {
                            foreach (var patient in hospital[department][roomNumber].OrderBy(x => x))
                            {
                                Console.WriteLine(patient);
                            }
                        }
                    }
                }
            }
        }
    }
}