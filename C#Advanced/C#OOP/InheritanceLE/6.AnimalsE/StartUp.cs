namespace Animals
{
    using System;

    public class StartUp
    {
        static void Main(string[] args)
        {
            string type = Console.ReadLine();

            while (type != "Beast!")
            {
                try
                {
                    string[] animalTokens = Console.ReadLine()
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                    string name = animalTokens[0];
                    int age = int.Parse(animalTokens[1]);
                    string gender = animalTokens[2];

                    switch (type.ToLower())
                    {
                        case "cat":
                            Cat cat = new Cat(name, age, gender);
                            Console.WriteLine(type);
                            Console.WriteLine(cat);
                            break;
                        case "dog":
                            Dog dog = new Dog(name, age, gender);
                            Console.WriteLine(type);
                            Console.WriteLine(dog);
                            break;
                        case "frog":
                            Frog frog = new Frog(name, age, gender);
                            Console.WriteLine(type);
                            Console.WriteLine(frog);
                            break;
                        case "kitten":
                            Kitten kitten = new Kitten(name, age);
                            Console.WriteLine(type);
                            Console.WriteLine(kitten);
                            break;
                        case "tomcat":
                            Tomcat tomcat = new Tomcat(name, age);
                            Console.WriteLine(type);
                            Console.WriteLine(tomcat);
                            break;
                        default:
                            Animal animal = new Animal(name, age, gender);
                            Console.WriteLine(type);
                            Console.WriteLine(animal);
                            break;
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }

                type = Console.ReadLine();
            }
        }
    }
}
