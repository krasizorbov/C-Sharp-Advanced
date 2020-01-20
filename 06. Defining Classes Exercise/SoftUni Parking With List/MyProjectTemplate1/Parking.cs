using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Reflection.Metadata.Ecma335;

namespace SoftUniParking
{
    public class Parking
    {
        private List<Car> cars;
        private int capacity;

        public int Count
        {
            get => cars.Count;
        }
        public string AddCar(Car car)
        {
            if (this.cars.Any(x => x.RegistrationNumber == car.RegistrationNumber))
            {
                return $"Car with that registration number, already exists!";
            }

            else if (this.cars.Count >= this.capacity)
            {
                return $"Parking is full!";
            }
            else
            {
                this.cars.Add(car);
                return $"Successfully added new car {car.Make} {car.RegistrationNumber}";

            }
        }

        public string RemoveCar(string registrationNumber)
        {
            if (cars.All(c => c.RegistrationNumber != registrationNumber))
            {
                return "Car with that registration number, doesn't exist!";
            }
            else
            {
                Car carToRemove = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

                cars.Remove(carToRemove);
                return $"Successfully removed {registrationNumber}";
            }
        }

        public Car GetCar(string registrationNumber)
        {
            Car car = cars.Where(x => x.RegistrationNumber == registrationNumber).FirstOrDefault();

            return car;
        }

        public void RemoveSetOfRegistrationNumber(List<string> registrationNumbers)
        {
            foreach (string registrationNumber in registrationNumbers)
            {
                if (cars.Any(c => c.RegistrationNumber == registrationNumber))
                {
                    Car carToRemove = cars.FirstOrDefault(c => c.RegistrationNumber == registrationNumber);

                    cars.Remove(carToRemove);
                }
            }
        }

        public Parking(int capacity)
        {
            cars = new List<Car>();
            this.capacity = capacity;
        }
    }
}