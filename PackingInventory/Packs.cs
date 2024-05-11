namespace Packs;

public class Pack
{
    public InventoryItem[] Inventory {get;}
    public int ItemLimit {get; init;}
    public decimal WeightLimit {get; init;}
    public decimal VolumeLimit {get; init;}
    public int CurrentItems {get; protected set;}
    public decimal CurrentWeight
    {
        get
        {
            decimal totalWeight = 0;
            if (CurrentItems != 0)
            {
                for (int i = 0; i < CurrentItems; i++)
                {
                    totalWeight += Inventory[i].Weight;
                }
            }
            return totalWeight;
        }
    }
    public decimal CurrentVolume
    {
        get
        {
            decimal totalVolume = 0;
            if (CurrentItems != 0)
            {
                for (int i = 0; i < CurrentItems; i++)
                {
                    totalVolume += Inventory[i].Volume;
                }
            }
            return totalVolume;
        }
    }

    public Pack(int itemLimit, decimal weightLimit, decimal volumeLimit)
    {
        ItemLimit = itemLimit;
        WeightLimit = weightLimit;
        VolumeLimit = volumeLimit;
        Inventory = new InventoryItem[ItemLimit];
        CurrentItems = 0;
    }

    public override string ToString()
    {
        string packString = "Pack containing ";
        for (int i = 0; i < CurrentItems; i++)
        {
            packString += Inventory[i].ToString();
            if (i != CurrentItems - 1)
                packString += " ";
        }
        return packString;
    }

    public void PrintStatus()
    {
        Console.WriteLine(this.ToString());
        // for (int i = 0; i < CurrentItems; i++)
        // {
        //     Console.WriteLine($"{i+1}. {Inventory[i].ToString()}");
        // }
        Console.WriteLine($"Items: {CurrentItems}/{ItemLimit}");
        Console.WriteLine($"Weight: {CurrentWeight}/{WeightLimit}");
        Console.WriteLine($"Volume: {CurrentVolume}/{VolumeLimit}");
    }

    // TODO: Refactor using try-catch
    public bool Add(InventoryItem item)
    {
        bool canAdd;
        canAdd = NotExceedsItemLimit(item);
        canAdd &= NotExceedsWeightLimit(item);
        canAdd &= NotExceedsVolumeLimit(item);

        if (canAdd)
        {
            Inventory[CurrentItems++] = item;
        }

        return canAdd;
    }
    private bool NotExceedsItemLimit(InventoryItem item)
    {
        bool exceedsItemLimit = CurrentItems == ItemLimit;
        if (exceedsItemLimit)
        {
            Console.WriteLine($"Cannot add item {item.ToString()}, adding would overcome item limit of {ItemLimit}.");
        }
        return !exceedsItemLimit;
    }
    private bool NotExceedsWeightLimit(InventoryItem item)
    {
        bool exceedsWeightLimit = CurrentWeight + item.Weight > WeightLimit;
        if (exceedsWeightLimit)
        {
            Console.WriteLine($"Cannot add item {item.ToString()}, adding would overcome weight limit of {WeightLimit}.");
        }
        return !exceedsWeightLimit;
    }
    private bool NotExceedsVolumeLimit(InventoryItem item)
    {
        bool exceedsVolumeLimit = CurrentVolume + item.Volume > VolumeLimit;
        if (exceedsVolumeLimit)
        {
            Console.WriteLine($"Cannot add item {item.ToString()}, adding would overcome volume limit of {VolumeLimit}.");
        }
        return !exceedsVolumeLimit;
    }
}

public class InventoryItem
{
    public decimal Weight { get; init; }
    public decimal Volume { get; init; }

    public InventoryItem(decimal weight, decimal volume)
    {
        Weight = weight;
        Volume = volume;
    }
}

public class Arrow : InventoryItem
{
    public Arrow() : base(0.1m, 0.05m)
    {
    }

    public override string ToString()
    {
        return "Arrow";
    }
}
public class Bow : InventoryItem
{
    public Bow() : base(1m, 4m)
    {
    }

    public override string ToString()
    {
        return "Bow";
    }
}
public class Rope : InventoryItem
{
    public Rope() : base(1m, 1.5m)
    {
    }

    public override string ToString()
    {
        return "Rope";
    }
}
public class Water : InventoryItem
{
    public Water() : base(2m, 3m)
    {
    }

    public override string ToString()
    {
        return "Water";
    }
}
public class FoodRation : InventoryItem
{
    public FoodRation() : base(1m, 0.5m)
    {
    }

    public override string ToString()
    {
        return "Food ration";
    }
}
public class Sword : InventoryItem
{
    public Sword() : base(5m, 3m)
    {
    }

    public override string ToString()
    {
        return "Sword";
    }
}