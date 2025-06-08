using System;

public class Game
{
    private Menu mainMenu;
    private PetManager petManager;

    public Game()
    {
        petManager = new PetManager();
        mainMenu = new Menu(petManager);
    }

    public void Run()
    {
        Console.WriteLine("Welcome to the Interactive Pet Simulator!");
        while (true)
        {
            mainMenu.Display();
        }
    }
}