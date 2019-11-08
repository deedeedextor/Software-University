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

            Console.WriteLine("You registered successfully! Now you can login!");
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
                Console.Write("Please, enter your password: ");
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
                        .FirstOrDefault(d => d.Email == emailLogin && d.Password == passwordLogin);

                    Console.WriteLine($"Welcome, Dr. {doctor.Name}!");
                    Console.Write($"Please, choose C to Create or S to Select patient: ");

                    string answer = Console.ReadLine();

                    if (answer.ToUpper() == "C")
                    {
                        this.CreatePatient(doctor, context);
                    }

                    else if (answer.ToUpper() == "S")
                    {
                        this.SelectPatient(doctor, context);
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

        private void EditPatient(Patient patient, Doctor doctor, HospitalContext context)
        {
            Console.WriteLine($"If you would like to Edit Visitation type Y/N: ");
            string answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                EditVisitation(patient, doctor, context);
            }

            Console.WriteLine($"If you would like to Edit Diagnose type Y/N: ");
            answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                EditDiagnose(patient, doctor, context);
            }

            Console.WriteLine($"If you would like to Edit Prescriptions type Y/N: ");
            answer = Console.ReadLine();

            if (answer.ToUpper() == "Y")
            {
                EditPrescriptions(patient, doctor, context);
            }

            Console.WriteLine("Here are all the changes: ");
            this.ReadPatient(patient, context);
        }

        private void EditPrescriptions(Patient patient, Doctor doctor, HospitalContext context)
        {
            Console.WriteLine("Please, write medicament name:");
            var medicament = string.Empty;

            while ((medicament = Console.ReadLine()) != string.Empty)
            {
                var currentMedicament = context
                    .Medicaments
                    .FirstOrDefault(m => m.Name == medicament);

                if (currentMedicament == null)
                {
                    currentMedicament = GenerateMedicament(medicament, context);
                }

                PatientMedicament patientMedicament = context
                    .PatientsMedicaments
                    .FirstOrDefault(pm => pm.PatientId == patient.PatientId && pm.MedicamentId == currentMedicament.MedicamentId);

                if (patientMedicament == null)
                {
                    patientMedicament = GeneratePatientMedicament(currentMedicament, patient, context);
                }

                currentMedicament.Prescriptions.Add(patientMedicament);
                patient.Prescriptions.Add(patientMedicament);
                context.SaveChanges();
            }
        }

        private PatientMedicament GeneratePatientMedicament(Medicament currentMedicament, Patient patient, HospitalContext context)
        {
            var patientMedicament = new PatientMedicament()
            {
                PatientId = patient.PatientId,
                Patient = patient,
                MedicamentId = currentMedicament.MedicamentId,
                Medicament = currentMedicament
            };

            context.PatientsMedicaments.Add(patientMedicament);
            context.SaveChanges();

            return context.PatientsMedicaments.Last();
        }

        private Medicament GenerateMedicament(string medicament, HospitalContext context)
        {
            var newMedicament = new Medicament()
            {
                Name = medicament
            };

            context.Medicaments.Add(newMedicament);
            context.SaveChanges();

            return context.Medicaments.Last();
        }

        private void EditDiagnose(Patient patient, Doctor doctor, HospitalContext context)
        {
            Console.Write("Please, write diagnose name: ");
            string DiagnoseName = Console.ReadLine();

            var diagnose = context.Diagnoses.FirstOrDefault(d => d.Name == DiagnoseName);

            if (diagnose == null)
            {
                diagnose = GenerateDiagnose(DiagnoseName, patient, context);
            }

            patient.Diagnoses.Add(diagnose);
            context.SaveChanges();


            Console.Write("Please, add comments to diagnose: ");
            string comments = Console.ReadLine();

            diagnose.Comments = comments;
            context.SaveChanges();
        }

        private Diagnose GenerateDiagnose(string answer, Patient patient, HospitalContext context)
        {
            Diagnose diagnose = new Diagnose()
            {
                Name = answer,
                PatientId = patient.PatientId,
                Patient = patient
            };

            context.Diagnoses.Add(diagnose);
            context.SaveChanges();

            return context.Diagnoses.Last();
        }

        private void EditVisitation(Patient patient, Doctor doctor, HospitalContext context)
        {
            var visitationId = GenerateVisitations(patient, doctor, context);
            var patientVisitation = context
                .Visitations
                .FirstOrDefault(v => v.VisitationId == visitationId);

            patient.Visitations.Add(patientVisitation);
            context.SaveChanges();

            Console.WriteLine("Please, add Comments to the visitation!");
            string comments = Console.ReadLine();

            patientVisitation.Comments = comments;
            context.SaveChanges();
        }

        private int GenerateVisitations(Patient patient, Doctor doctor, HospitalContext context)
        {
            Visitation visitation = new Visitation();
            visitation.Date = DateTime.UtcNow;
            visitation.PatientId = patient.PatientId;
            visitation.Patient = visitation.Patient;
            visitation.DoctorId = doctor.DoctorId;
            visitation.Doctor = doctor;

            context.Visitations.Add(visitation);
            context.SaveChanges();

            return context.Visitations.Last().VisitationId;
        }

        private void SelectPatient(Doctor doctor, HospitalContext context)
        {
            Console.Write("Please, enter patient's Id Number in order to see or edit a patient profile: ");
            int patientId = int.Parse(Console.ReadLine());

            var patient = context.Patients.Find(patientId);

            if (patient != null)
            {
                Console.Write($"Please, enter R to Read or E to Edit patient {patient.FirstName} {patient.LastName}: ");
                string answer = Console.ReadLine();

                if (answer.ToUpper() == "R")
                {
                    ReadPatient(patient, context);
                }

                else if (answer.ToUpper() == "E")
                {
                    EditPatient(patient, doctor, context);
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

        private void CreatePatient(Doctor doctor,HospitalContext context)
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

            Console.WriteLine($"Patient {patient.FirstName} {patient.LastName} with Id {patient.PatientId} successfully created!");
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
