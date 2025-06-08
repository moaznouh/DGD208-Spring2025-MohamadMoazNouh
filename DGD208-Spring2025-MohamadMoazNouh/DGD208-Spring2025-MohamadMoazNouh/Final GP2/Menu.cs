using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;

public class Menu
{
    private PetManager petManager;

    public Menu(PetManager manager)
    {
        petManager = manager;
    }

    public void Display()
    {
        Console.WriteLine("\nMain Menu:");
        Console.WriteLine("1. Adopt a pet");
        Console.WriteLine("2. Show pets and Stats");
        Console.WriteLine("3. Interact with a pet");
        Console.WriteLine("4. Use item on a pet");
        Console.WriteLine("5. Credits");
        Console.WriteLine("6. Exit");
        Console.Write("Choose an option: ");

        var input = Console.ReadLine();
        Console.WriteLine();

        switch (input)
        {
            case "1":
                AdoptPet();
                break;
            case "2":
                petManager.ShowAllPets();
                break;
            case "3":
                InteractWithPet();
                break;
            case "4":
                UseItemOnPet();
                break;
            case "5":
                Console.WriteLine("Created by: Mohamad Moaz Nouh - 225040114");
                break;
            case "6":
                Environment.Exit(0);
                break;
            default:
                Console.WriteLine("Invalid input. Try again.");
                break;
        }
    }

    private void AdoptPet()
    {
        Console.Write("Enter a name for your pet: ");
        string petName = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Choose a pet type:");
        foreach (var t in Enum.GetValues(typeof(PetType)))//gpt
        {
            Console.WriteLine($"- {t}");
        }

        Console.Write("Enter pet type: ");
        string typeInput = Console.ReadLine() ?? string.Empty;

        if (Enum.TryParse(typeInput, true, out PetType selectedType))
        {
            petManager.AdoptPet(petName, selectedType);
        }
        else
        {
            Console.WriteLine("Invalid pet type.");
        }
    }

    private void InteractWithPet()
    {
        Console.Write("Enter pet name to interact with: ");
        string petName = Console.ReadLine() ?? string.Empty;
        var pet = petManager.GetPetByName(petName);

        if (pet == null)
        {
            Console.WriteLine("Pet not found.");
            return;
        }

        Console.WriteLine("Choose interaction:");
        Console.WriteLine("1. Feed");
        Console.WriteLine("2. Let Sleep");
        Console.WriteLine("3. Play");
        Console.Write("Your choice: ");
        string action = Console.ReadLine() ?? string.Empty;

        switch (action)
        {
            case "1":
                pet.Feed(10);
                Console.WriteLine($"Fed {pet.Name}.");
                break;
            case "2":
                pet.Rest(10);
                Console.WriteLine($"{pet.Name} took a nap.");
                break;
            case "3":
                pet.Play(10);
                Console.WriteLine($"Played with {pet.Name}.");
                break;
            default:
                Console.WriteLine("Invalid action.");
                break;
        }
    }

    private async void UseItemOnPet()//Mohammad Amin Hojabran helped writing this block of code
    {
        Console.Write("Enter pet name to use an item on: ");
        string petName = Console.ReadLine() ?? string.Empty;
        var pet = petManager.GetPetByName(petName);

        if (pet == null)
        {
            Console.WriteLine("Pet not found.");
            return;
        }

        var items = ItemDatabase.GetAllItems();
        Console.WriteLine("Available items:");
        for (int i = 0; i < items.Count; i++)
        {
            Console.WriteLine($"{i + 1}. {items[i].Name} ({items[i].Type}) - Effect: {items[i].EffectAmount}, Duration: {items[i].DurationInSeconds}s");
        }

        Console.Write("Select item number: ");
        if (int.TryParse(Console.ReadLine(), out int choice) && choice >= 1 && choice <= items.Count)
        {
            var item = items[choice - 1];
            await item.UseAsync(pet);
        }
        else
        {
            Console.WriteLine("Invalid item choice.");
        }
    }
} 
//