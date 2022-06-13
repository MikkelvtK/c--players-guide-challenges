
int points;

Console.WriteLine("Enter amount of estates:");
int numberOfEstates = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter amount of duchies:");
int numberOfDuchies = Convert.ToInt32(Console.ReadLine());

Console.WriteLine("Enter amount of provinces:");
int numberOfProvinces = Convert.ToInt32(Console.ReadLine());

points = numberOfEstates * 1 + numberOfDuchies * 3 + numberOfProvinces * 6;
Console.WriteLine("Your amount of points: " + points);
