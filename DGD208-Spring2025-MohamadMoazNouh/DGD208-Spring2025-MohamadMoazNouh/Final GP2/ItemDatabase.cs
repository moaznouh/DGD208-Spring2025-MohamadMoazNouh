using System.Collections.Generic;

public static class ItemDatabase
{
    public static List<Item> GetAllItems()
    {
        return new List<Item>
        {
            new Item { Name = "Kibble", Type = ItemType.Food, EffectAmount = 15, DurationInSeconds = 2 },
            new Item { Name = "Ball", Type = ItemType.Toy, EffectAmount = 15, DurationInSeconds = 2 },
            new Item { Name = "Blanket", Type = ItemType.Bed, EffectAmount = 15, DurationInSeconds = 2 }
        };
    }
}
