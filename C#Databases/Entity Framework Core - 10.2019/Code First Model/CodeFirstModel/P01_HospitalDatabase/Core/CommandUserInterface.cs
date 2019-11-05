namespace P01_HospitalDatabase.Core
{
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;

    internal class CommandUserInterface
    {
        private readonly Validation validator = new Validation();

        public void Register(HospitalContext context)
        {
            Console.WriteLine("Hello, guest!");

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
                        .Select(d => new DoctorResultModel
                        {
                            Name = d.Name,
                            Email = d.Email,
                            Password = d.Password
                        })
                        .SingleOrDefault(d => d.Email == emailLogin && d.Password == passwordLogin);

                    Console.WriteLine($"Welcome, Dr. {doctor.Name}!");
                    Console.WriteLine($"Please, choose C to Create, S to Select or D to Delete Patient: ");
                    string answer = Console.ReadLine();

                    if (answer.ToUpper() == "C")
                    {
                        this.CreatePatient(doctor, context);
                    }

                    else if (answer.ToUpper() == "S")
                    {
                        this.SelectPatient(doctor, context);
                    }

                    else if (answer.ToUpper() == "D")
                    {
                        this.DeletePatient(context);
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
                Console.WriteLine("You are not registered!");
                this.Register(context);
            }
        }

        private void DeletePatient(HospitalContext context)
        {
            //TO DO
            throw new NotImplementedException();
        }

        private void EditPatient(Patient patient, HospitalContext context)
        {
            //TO DO
            throw new NotImplementedException();
        }

        private void SelectPatient(DoctorResultModel doctor, HospitalContext context)
        {
            Console.Write("Please, enter patient's Id Number: ");
            int patientId = int.Parse(Console.ReadLine());

            var patient = context.Patients.Find(patientId);

            if (patient != null)
            {
                Console.Write($"Please, enter R to read or E to edit patient {patient.FirstName} {patient.LastName}: ");
                string answer = Console.ReadLine();

                if (answer == "R")
                {
                    ReadPatient(patient, context);
                }

                else if (answer == "E")
                {
                    EditPatient(patient, context);
                }

                else
                {
                    validator.ValidateAnswer();
                }
            }

            else
            {
                validator.ValidatePatient();
            }
        }

        private void ReadPatient(Patient patient, HospitalContext context)
        {
            Console.WriteLine($"Name: {patient.FirstName} {patient.LastName}");
            Console.WriteLine($"Address: {patient.Address}");
            Console.WriteLine($"Email: {patient.Email}");

            if (patient.HasInsurance)
            {
                Console.WriteLine("Insurance: Yes");
            }
            else
            {
                Console.WriteLine("Insurance: No");
            }

            Console.WriteLine();

            foreach (var visitation in patient.Visitations)
            {
                var doctor = context.Doctors.FirstOrDefault(d => d.DoctorId == visitation.DoctorId);

                Console.WriteLine($"Date: {visitation.Date}");
                Console.WriteLine($"Comments: {visitation.Comments}");
                Console.WriteLine($"Doctor: {doctor.Name} - {doctor.Specialty}");
                Console.WriteLine();
            }

            foreach (var diagnose in patient.Diagnoses)
            {
                Console.WriteLine($"Name: {diagnose.Name}");
                Console.WriteLine($"Comments: {diagnose.Comments}");
                Console.WriteLine();
            }

            Console.WriteLine("Prescription list: ");
            foreach (var prescription in patient.Prescriptions)
            {
                var medicament = context.Medicaments.FirstOrDefault(m => m.MedicamentId == prescription.MedicamentId);

                Console.WriteLine($"---{medicament.Name}");
            }
        }

        private void CreatePatient(DoctorResultModel doctor,HospitalContext context)
        {
            List<string> patientData = InputPatientData();

            var patient = new Patient();
            patient.FirstName = patientData[0];
            patient.LastName = patientData[1];
            patient.Address = patientData[2];
            patient.Email = patientData[3];

            if (patientData[4] == "Y")
            {
                patient.HasInsurance = true;
            }

            else if (patientData[4] == "N")
            {
                patient.HasInsurance = false;
            }

            else
            {
                validator.ValidateAnswer();
            }

            context.Patients.Add(patient);
            context.SaveChanges();

            this.SelectPatient(doctor, context);
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
            List<string> data = new List<string>();

            Console.Write("Please, enter patient's first name: ");
            string firstName = Console.ReadLine();
            data.Add(firstName);

            Console.Write("Please, enter patient's last name: ");
            string lastName = Console.ReadLine();
            data.Add(lastName);

            Console.Write("Please, enter patient's address: ");
            string address = Console.ReadLine();
            data.Add(address);

            Console.Write("Please, enter patient's email: ");
            string email = Console.ReadLine();
            data.Add(email);

            Console.Write("Please, enter Y if patient has insurance or N if he does not: ");
            string insurance = Console.ReadLine();
            data.Add(insurance);

            return data;
        }
    }
}
