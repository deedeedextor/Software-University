namespace P01_HospitalDatabase
{
    using System;
    using System.Globalization;
    using Microsoft.EntityFrameworkCore;
    using P01_HospitalDatabase.Core;
    using P01_HospitalDatabase.Data;
    using P01_HospitalDatabase.Data.Models;

    public class StartUp
    {
        public static void Main(string[] args)
        {
            Validation validator = new Validation();

            using (HospitalContext db = new HospitalContext())
            {
                //Reset(db);

                try
                {
                    var commandUserInterface = new CommandUserInterface();

                    Console.WriteLine("Hello, guest! Do you you have an account?");
                    Console.Write("Please, write Y/N: ");
                    string answer = Console.ReadLine();

                    if (answer.ToUpper() == "Y")
                    {
                        commandUserInterface.Login(db);
                    }

                    else if (answer.ToUpper() == "N")
                    {
                        commandUserInterface.Register(db);
                    }

                    else
                    {
                        validator.ValidateAnswer();
                    }
                }
                catch (ArgumentException ae)
                {
                    throw new ArgumentException(ae.Message);
                }
            }
        }

        private static void Reset(HospitalContext db)
        {
            db.Database.Migrate();

            Seed(db);
        }

        private static void Seed(HospitalContext db)
        {
            Doctor[] doctors = AddDoctors();
            db.Doctors.AddRange(doctors);

            Medicament[] medicaments = AddMedicaments();
            db.Medicaments.AddRange(medicaments);

            Patient[] patients = AddPatients();
            db.Patients.AddRange(patients);

            Diagnose[] diagnoses = AddDiagnoses(patients);
            db.Diagnoses.AddRange(diagnoses);

            Visitation[] visitations = AddVisitations(patients, doctors);
            db.Visitations.AddRange(visitations);

            PatientMedicament[] patientMedicaments = AddPatientMedicaments(patients, medicaments);
            db.PatientsMedicaments.AddRange(patientMedicaments);
            
            db.SaveChanges();

            Console.WriteLine("Sample data inserted successfully!");
        }

        private static PatientMedicament[] AddPatientMedicaments(Patient[] patients, Medicament[] medicaments)
        {
            PatientMedicament[] patientMedicaments = new PatientMedicament[patients.Length];

            for (int i = 0; i < patientMedicaments.Length; i++)
            {
                var patientMedicament = new PatientMedicament()
                {
                    Patient = patients[i],
                    PatientId = patients[i].PatientId,
                    Medicament = medicaments[i],
                    MedicamentId = medicaments[i].MedicamentId,
                };

                patientMedicaments[i] = patientMedicament;
            }

            return patientMedicaments;
        }

        private static Visitation[] AddVisitations(Patient[] patients, Doctor[] doctors)
        {
            string[] visitationInput = new string[]
            {
                "12-11-2017, Ok",
                "03-09-2016, Normal",
                "16-05-2019, Medium",
            };

            Visitation[] visitations = new Visitation[visitationInput.Length];

            for (int i = 0; i < visitationInput.Length; i++)
            {
                string[] visitationProps = visitationInput[i]
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var visitation = new Visitation()
                {
                    Date = DateTime.ParseExact(visitationProps[0], "d-M-yyyy", CultureInfo.InvariantCulture),
                    Comments = visitationProps[1],
                    Patient = patients[i],
                    PatientId = patients[i].PatientId,
                    Doctor = doctors[i],
                    DoctorId = doctors[i].DoctorId,
                };

                visitations[i] = visitation;
            }

            return visitations;
        }

        private static Diagnose[] AddDiagnoses(Patient[] patients)
        {
            string[] diagnoseInput = new string[]
            {
                "Hrema, No",
                "Headache, Yes",
                "Toothache, No",
            };

            Diagnose[] diagnoses = new Diagnose[diagnoseInput.Length];

            for (int i = 0; i < diagnoseInput.Length; i++)
            {
                string[] diagnoseProps = diagnoseInput[i]
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var diagnose = new Diagnose()
                {
                    Name = diagnoseProps[0],
                    Comments = diagnoseProps[1],
                    Patient = patients[i],
                    PatientId = patients[i].PatientId,
                };

                diagnoses[i] = diagnose;
            }

            return diagnoses;
        }

        private static Patient[] AddPatients()
        {
            string[] patientInput = new string[]
            {
                "Dimo, Angelov, Sofiq, qwe@abv.bg, true",
                "Irina, Petrova, Plovdiv, rty@gmail.com, true",
                "Natalia, Qnkova, Varna, uio@abv.bg, true",
            };

            Patient[] patients = new Patient[patientInput.Length];

            for (int i = 0; i < patientInput.Length; i++)
            {
                string[] patientProps = patientInput[i]
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var patient = new Patient()
                {
                    FirstName = patientProps[0],
                    LastName = patientProps[1],
                    Address = patientProps[2],
                    Email = patientProps[3],
                    HasInsurance = bool.Parse(patientProps[4]),
                };

                patients[i] = patient;
            }

            return patients;
        }

        private static Medicament[] AddMedicaments()
        {
            string[] medicamentInput = new string[]
            {
                "Cramolise",
                "Allergosan",
                "Ospamox",
            };

            Medicament[] medicaments = new Medicament[medicamentInput.Length];

            for (int i = 0; i < medicamentInput.Length; i++)
            {
                string[] medicamentProps = medicamentInput[i].Split();

                var doctor = new Medicament()
                {
                    Name = medicamentProps[0]
                };

                medicaments[i] = doctor;
            }

            return medicaments;
        }

        private static Doctor[] AddDoctors()
        {
            string[] doctorInput = new string[]
            {
                "Ivan Ivanov, asd@abv.bg, 123, General Practitioner",
                "Damqn Dimov, asd@gmail.bg, 345, Pediatrician",
                "Ivon Kalinova, zxc@abv.bg, 567, Neurologist",
            };

            Doctor[] doctors = new Doctor[doctorInput.Length];

            for (int i = 0; i < doctorInput.Length; i++)
            {
                string[] doctorProps = doctorInput[i]
                    .Split(", ", StringSplitOptions.RemoveEmptyEntries);

                var doctor = new Doctor()
                {
                    Name = doctorProps[0],
                    Email = doctorProps[1],
                    Password = doctorProps[2],
                    Specialty = doctorProps[3],
                };

                doctors[i] = doctor;
            }

            return doctors;
        }

    }
}
