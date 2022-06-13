
(Recipe, Ingredient, Seasoning) dish;

Console.WriteLine("Pick a recipe:\n" +
    "0 - Soup\n" +
    "1 - Stew\n" +
    "2 - Gumbo"
);
Recipe recipeChoice = (Recipe)Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Pick a main ingredient:\n" +
    "0 - Mushrooms\n" +
    "1 - Chicken\n" +
    "2 - Carrots\n" +
    "3 - Potatoes"
);
Ingredient ingredientChoice = (Ingredient)Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Pick a seasoning:\n" +
    "0 - Spicy\n" +
    "1 - Salty\n" +
    "2 - Sweet"
);
Seasoning seasoningChoice = (Seasoning)Convert.ToInt32(Console.ReadLine());

dish = (recipeChoice, ingredientChoice, seasoningChoice);

Console.WriteLine($"You made: {dish.Item3} {dish.Item2} {dish.Item1}");

enum Recipe { Soup, Stew, Gumbo }
enum Ingredient { Mushroom, Chicken, Carrot, Potato }
enum Seasoning { Spicy, Salty, Sweet }
