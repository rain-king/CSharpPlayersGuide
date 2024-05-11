Sword basicSword = new(SwordMaterial.Iron, SwordGemstone.None, 1.2m, 0.3m);
Sword emeraldSteelSword = basicSword with {Material = SwordMaterial.Steel, Gemstone = SwordGemstone.Emerald};
Sword bitstoneBinariumSword = basicSword with {Material = SwordMaterial.Binarium, Gemstone = SwordGemstone.Bitstone};
Console.WriteLine(basicSword);
Console.WriteLine(emeraldSteelSword);
Console.WriteLine(bitstoneBinariumSword);
public record Sword(SwordMaterial Material, SwordGemstone Gemstone, decimal Length, decimal CrossguardWidth);
public enum SwordGemstone {Emerald, Amber, Sapphire, Diamond, Bitstone, None}
public enum SwordMaterial {Wood, Bronze, Iron, Steel, Binarium}