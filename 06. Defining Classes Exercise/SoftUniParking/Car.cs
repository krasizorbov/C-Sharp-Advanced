using System;
using System.Collections.Generic;
using System.Text;

namespace SoftUniParking
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public int HorsePower { get; set; }
        public string RegistrationNumber { get; set; }

        public Car(string make, string model, int horsePower, string registrationNumber)
        {
            Make = make;
            Model = model;
            HorsePower = horsePower;
            RegistrationNumber = registrationNumber;
        }

        public override string ToString()
        {
            string result = $"Make: {Make}" +
                Environment.NewLine +
                $"Model: {Model}" +
                Environment.NewLine +
                $"HorsePower: {HorsePower}" +
                Environment.NewLine +
                $"RegistrationNumber: {RegistrationNumber}";
            return result;
        }
    }
}
