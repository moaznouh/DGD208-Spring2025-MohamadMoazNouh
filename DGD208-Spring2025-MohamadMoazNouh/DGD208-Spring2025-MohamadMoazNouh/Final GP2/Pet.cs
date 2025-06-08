public class Pet
{
    public string Name { get; private set; }
    public PetType Type { get; private set; }
    public int Hunger { get; private set; } = 50;
    public int Sleep { get; private set; } = 50;
    public int Fun { get; private set; } = 50;
    public bool IsAlive { get; private set; } = true;

    // 
    public event Action<Pet> OnPetDied = delegate { };

    public Pet(string name, PetType type)
    {
        Name = name;
        Type = type;
    }

    public async Task StartStatDecayAsync() //GPT
    {
        while (IsAlive)
        {
            await Task.Delay(5000);
            Hunger = Math.Max(0, Hunger - 1);
            Sleep = Math.Max(0, Sleep - 1);
            Fun = Math.Max(0, Fun - 1);

            if (Hunger == 0 || Sleep == 0 || Fun == 0)
            {
                IsAlive = false;
                OnPetDied?.Invoke(this);
            }
        }
    }
//
    public void Feed(int amount) => Hunger = Math.Min(100, Hunger + amount);
    public void Rest(int amount) => Sleep = Math.Min(100, Sleep + amount);
    public void Play(int amount) => Fun = Math.Min(100, Fun + amount);

    public override string ToString()
    {
        return $"{Name} ({Type}) - Hunger: {Hunger}, Sleep: {Sleep}, Fun: {Fun}";
    }
} 
