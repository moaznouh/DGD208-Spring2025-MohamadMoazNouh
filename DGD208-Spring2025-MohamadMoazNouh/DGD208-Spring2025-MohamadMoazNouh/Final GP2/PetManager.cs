using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class PetManager
{
    private List<Pet> pets = new List<Pet>();//gpt

    public void AdoptPet(string name, PetType type)
    {
        var pet = new Pet(name, type);
        pet.OnPetDied += RemovePet;
        pets.Add(pet);
        _ = pet.StartStatDecayAsync();
        Console.WriteLine($"{name} the {type} has been adopted!");
    }
//
    private void RemovePet(Pet pet)//Kerim Soleman helped writing this block of code
    {
        pets.Remove(pet);
        Console.WriteLine($"{pet.Name} has died...");
    }

    public void ShowAllPets()
    {
        if (!pets.Any())
        {
            Console.WriteLine("No pets currently adopted.");
            return;
        }

        foreach (var pet in pets)
        {
            Console.WriteLine(pet);
        }
    }
//
    public Pet? GetPetByName(string name)
    {
        return pets.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
    }

    public List<Pet> GetAllPets() => pets;
} 
