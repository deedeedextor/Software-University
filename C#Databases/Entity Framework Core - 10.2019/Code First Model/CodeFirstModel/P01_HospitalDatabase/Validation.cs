namespace P01_HospitalDatabase
{
    using System;

    internal class Validation
    {
        public string ValidateAnswer()
        {
            throw new ArgumentException("Incorrect answer!");
        }

        public string ValidatePassword()
        {
            throw new ArgumentException("Incorrect password!");
        }

        public string ValidatePatient()
        {
            throw new ArgumentException("There is no such patient in the system!");
        }
    }
}
