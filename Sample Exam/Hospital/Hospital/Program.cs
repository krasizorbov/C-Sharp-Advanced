using System;
using System.Collections.Generic;
using System.Linq;

namespace _06.Hospital
{
    class Hospital
    {
        static void Main(string[] args)
        {
            // department.Key and patient.Value
            var departments = new Dictionary<string, List<string>>();
            // doctor.Key and patient.Value
            var doctors = new Dictionary<string, List<string>>();
            var line = Console.ReadLine();

            while (line != "Output")
            {
                var input = line.Split().ToArray();
                var department = input[0];
                var doctor = input[1] + " " + input[2];
                var patient = input[3];

                if (!departments.ContainsKey(department))
                {
                    departments[department] = new List<string>();
                }

                departments[department].Add(patient);

                if (!doctors.ContainsKey(doctor))
                {
                    doctors[doctor] = new List<string>();
                }

                doctors[doctor].Add(patient);

                line = Console.ReadLine();
            }

            line = Console.ReadLine().Trim();

            while (line != "End")
            {
                var input = line.Split().ToArray();

                if (input.Length == 1)
                {
                    foreach (var patients in departments[line])
                    {
                        Console.WriteLine(patients);
                    }
                }
                else if (int.TryParse(input[1], out int result))
                {
                    if (int.Parse(input[1]) > 20)
                    {
                        continue;
                    }

                    var patients = departments[input[0]];

                    var room = patients.Skip(3 * (int.Parse(input[1]) - 1)).Take(3).OrderBy(p => p);

                    foreach (var patient in room)
                    {
                        Console.WriteLine(patient);
                    }
                }
                else
                {
                    var patients = doctors[line];
                    patients.Sort();
                    foreach (var patient in patients)
                    {
                        Console.WriteLine(patient);
                    }
                }
                line = Console.ReadLine();
            }
        }
    }
}