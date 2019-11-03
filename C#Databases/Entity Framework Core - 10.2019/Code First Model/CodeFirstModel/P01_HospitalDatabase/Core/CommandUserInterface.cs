namespace P01_HospitalDatabase.Core
{
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class CommandUserInterface
    {
        Validation validator = new Validation();

        public void Register(HospitalContext context)
        {
            Console.WriteLine("Please, register!");

            List<string> doctorData = this.InputDoctorData();

            Doctor doctor = new Doctor
            {
                Name = doctorData[0],
                Specialty = doctorData[1],
                Email = doctorData[2],
                Password = doctorData[3]
            };

            context.Doctors.Add(doctor);
            context.SaveChanges();

            this.Login(context);
        }

        public void Login(HospitalContext context)
        {
            Console.WriteLine("Please, login!");
            Console.Write("Please, enter your email: ");
            string emailLogin = Console.ReadLine();

            var email = context
                .Doctors
                .Where(e => e.Email == emailLogin)
                .Select(d => d.Email)
                .ToList();

            if (email.Any())
            {
                Console.WriteLine("Please, enter your password: ");
                string passwordLogin = Console.ReadLine();

                var password = context
                    .Doctors
                    .Where(p => p.Password == passwordLogin)
                    .Select(p => p.Password)
                    .ToList();

                if (password.Any())
                {
                    var doctor = context
                        .Doctors
                        .Select(d => new
                        {
                            d.Name,
                            d.Specialty,
                            d.Email
                        })
                        .FirstOrDefault(d => d.Email == emailLogin);

                    Console.WriteLine($"Welcome, Dr. {doctor.Name} with {doctor.Specialty}");
                    Console.Write($"Please, choose C to Create Patient, S to Select Patient or E to Edit Patient: ");
                    string answer = Console.ReadLine();

                    if (answer.ToUpper() == "C")
                    {
                        this.CreatePatient(context);
                    }

                    else if (answer.ToUpper() == "S")
                    {
                        this.SelectPatient(context);
                    }

                    else if (answer.ToUpper() == "E")
                    {
                        this.EditPatient(context);
                    }

                    else
                    {
                        validator.ValidateAnswer();
                    }
                }

                else
                {
                    validator.ValidatePassword();
                }
            }

            else
            {
                validator.ValidateEmail();
            }
        }

        private void EditPatient(HospitalContext context)
        {
            //TO DO
            throw new NotImplementedException();
        }

        private void SelectPatient(HospitalContext context)
        {
            //TO DO
            throw new NotImplementedException();
        }

        private void CreatePatient(HospitalContext context)
        {
            //TO DO
            throw new NotImplementedException();
        }

        private List<string> InputDoctorData()
        {
            List<string> data = new List<string>();

            Console.Write("Please, enter your names: ");
            string name = Console.ReadLine();
            data.Add(name);

            Console.Write("Please, enter your specialty: ");
            string specialty = Console.ReadLine();
            data.Add(specialty);

            Console.Write("Please, enter your email: ");
            string email = Console.ReadLine();
            data.Add(email);

            Console.Write("Please, enter your password: ");
            string password = Console.ReadLine();
            data.Add(password);

            return data;
        }

        private List<string> InputPatientData()
        {
            //TO DO
            throw new NotImplementedException();
        }
    }
}
