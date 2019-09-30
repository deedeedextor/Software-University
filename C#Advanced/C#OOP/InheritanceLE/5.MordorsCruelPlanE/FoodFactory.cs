namespace _5.MordorsCruelPlanE
{
    using _5.MordorsCruelPlanE.Foods;

    public class FoodFactory
    {
        public Food GetFood(string food)
        {
            switch (food.ToLower())
            {
                case "cram":
                    return new Cram();
                case "lembas":
                    return new Lembas();
                case "apple":
                    return new Apple();
                case "melon":
                    return new Melon();
                case "honeycake":
                    return new HoneyCake();
                case "mushrooms":
                    return new Mushrooms();
                default:
                    return null;
            }
        }
    }
}
