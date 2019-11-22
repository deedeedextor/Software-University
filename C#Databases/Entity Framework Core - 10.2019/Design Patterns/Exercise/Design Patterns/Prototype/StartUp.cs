using Prototype.Models;
using System;

namespace Prototype
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            SandwichMenu sandwichMenu = new SandwichMenu();

            //default sandwiches
            sandwichMenu["BLT"] = new Sandwich("Wheat", "Bacon", "", "Lettuce, Tomato");

            sandwichMenu["PB&J"] = new Sandwich("White", "", "", "Peanut Butter, Jelly");

            sandwichMenu["Turkey"] = new Sandwich("Rye", "Turkey", "Swiss", "Lettuce, Onion, Tomato");

            //custom sandwiches
            sandwichMenu["LoadedBLT"] = new Sandwich("Wheat","Turkey, Bacon", "American", "Lettuce, Tomato, Onion, Olives");

            sandwichMenu["ThreeMeatCombo"] = new Sandwich("Rye", "Turkey, Ham, Salami", "Provolone", "Lettuce, Onion");

            sandwichMenu["Vegetarian"] = new Sandwich("Wheat", "", "", "Lettuce, Onion, Tomato, Olives, Spinach");

            //cloned sandwiches
            Sandwich sandwichOne = sandwichMenu["BLT"].Clone() as Sandwich;

            Sandwich sandwichTwo = sandwichMenu["ThreeMeatCombo"].Clone() as Sandwich;

            Sandwich sandwichThree = sandwichMenu["Vegeterian"].Clone() as Sandwich;
        }
    }
}
