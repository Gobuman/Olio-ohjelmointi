

public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKäynnissä { get; set; }
    public  IRobottiKasky?[] Käskyt { get; } = new IRobottiKasky?[3];

    public void Suorita()
    {
        foreach (IRobottiKasky? käsky in Käskyt)
        {
            käsky?.Suorita(this);
            Console.WriteLine($"[{X},{Y} {OnKäynnissä}]");
        }
    }
}
public interface IRobottiKasky
{
    void Suorita(Robotti käskyt);
}

public class Käynnistä : IRobottiKasky
{
    public void Suorita(Robotti käskyt)
    {
        käskyt.OnKäynnissä = true;
    }
}

public class Sammuta : IRobottiKasky
{
    public void Suorita(Robotti käskyt)
    {
        käskyt.OnKäynnissä = false;
    }
}

public class Vasen : IRobottiKasky
{
    public void Suorita(Robotti Käskyt)
    {
        if (Käskyt.OnKäynnissä)
        {
            Käskyt.X -= 1;
        }
    }
}
public class Oikea : IRobottiKasky
{
    public void Suorita(Robotti Käskyt)
    {
        if (Käskyt.OnKäynnissä)
        {
            Käskyt.X += 1;
        }
    }
}
public class Ylös : IRobottiKasky
{
    public void Suorita(Robotti Käskyt)
    {
        if (Käskyt.OnKäynnissä)
        {
            Käskyt.Y -= 1;
        }
    }
}
public class Alas : IRobottiKasky
{
    public void Suorita(Robotti Käskyt)
    {
        if (Käskyt.OnKäynnissä)
        {
            Käskyt.Y += 1;
        }
    }
}

class program
{
    static void Main(string[] args)
    {   
        Robotti robotti = new Robotti();
        for (int i = 0; i < 3; i++)
        {
            
            Console.WriteLine("Mitä kommentoa syötetään robotille: käynistä, sammuta, ylos, alas, vasen, oikea.");
            string vastaus = Console.ReadLine();
            
            if(vastaus == "käynistä")
            {
                robotti.Käskyt[i] = new Käynnistä();
                continue;
            }
            if(vastaus == "sammuta")
            {
                robotti.Käskyt[i] = new Sammuta();
                continue;
            }
            if(vastaus == "vasen")
            {
                robotti.Käskyt[i] = new Vasen();
                continue;
            }
            if(vastaus == "oikea")
            {
                robotti.Käskyt[i] = new Oikea();
                continue;
            }
            if(vastaus == "ylös")
            {
                robotti.Käskyt[i] = new Ylös();
                continue;
            }
            if(vastaus == "alas")
            {
                robotti.Käskyt[i] = new Alas();
                continue;
            }
            else
            {
                Console.WriteLine("Error!");
                i--;
            }
        }
        robotti.Suorita();
    }
}