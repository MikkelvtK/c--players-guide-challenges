
Sword basicSword = new(Material.Iron, Gemstone.None, 67f, 23f);
Sword variant1 = basicSword with { Material = Material.Steel, Gemstone = Gemstone.Emerald };
Sword variant2 = basicSword with { Material = Material.Binarium, Gemstone = Gemstone.Bitstone };

Console.WriteLine(basicSword);
Console.WriteLine(variant1);
Console.WriteLine(variant2);

public enum Material { Wood, Bronze, Iron, Steel, Binarium }
public enum Gemstone { Emerald, Amber, Sapphire, Diamond, Bitstone, None }

public record Sword(Material Material, Gemstone Gemstone, float Length, float CrossguardWidth);
