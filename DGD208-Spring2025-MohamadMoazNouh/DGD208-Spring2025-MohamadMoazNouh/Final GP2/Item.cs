using System;
using System.Threading.Tasks;

public class Item
{
    public string? Name { get; set; }
    public ItemType Type { get; set; }
    public int EffectAmount { get; set; }
    public int DurationInSeconds { get; set; }

    public async Task UseAsync(Pet pet)//gpt
    {
        Console.WriteLine($"Using {Name} on {pet.Name}...");
        await Task.Delay(DurationInSeconds * 1000);

        switch (Type)
        {
            case ItemType.Food:
                pet.Feed(EffectAmount);
                break;
            case ItemType.Toy:
                pet.Play(EffectAmount);
                break;
            case ItemType.Bed:
                pet.Rest(EffectAmount);
                break;
        }

        Console.WriteLine($"{Name} used on {pet.Name}.");
    }
}
//