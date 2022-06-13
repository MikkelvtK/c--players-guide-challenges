
// Retrieve size of the base and height of the triangle
Console.WriteLine("Size of base:");
float triangleBase = Convert.ToSingle(Console.ReadLine());

Console.WriteLine("Height of triangle:");
float triangleHeight = Convert.ToSingle(Console.ReadLine());

// Calculate area of triangle
float triangleArea = triangleBase * triangleHeight / 2.0f;
Console.WriteLine("Area of triangle: " + triangleArea);