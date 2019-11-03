namespace P01_HospitalDatabase
{
    using System;

    public class Validation
    {
        public string ValidateAnswer()
        {
            throw new ArgumentException("Incorrect answer!");
        }

        public string ValidatePassword()
        {
            throw new ArgumentException("Incorrect password!");
        }

        public string ValidateEmail()
        {
            throw new ArgumentException("Incorrect email!");
        }

        public string ValidateName()
        {
            throw new ArgumentException("Incorrect name!");
        }
    }
}
