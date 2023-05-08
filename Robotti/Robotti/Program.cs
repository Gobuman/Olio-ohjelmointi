

public class Robotti
{
    public int X { get; set; }
    public int Y { get; set; }
    public bool OnKäynnissä { get; set; }
    public  RobottiKasky?[] Käskyt { get; } = new RobottiKasky?[3];

    public void Suorita()
    {
        foreach (RobottiKasky? käsky in Käskyt)
        {
            käsky?.Suorita(this);
            Console.WriteLine($"[{X},{Y} {OnKäynnissä}]");
        }
    }
}


public abstract class RobottiKasky
{
    public abstract void Suorita(Robotti Käskyt);
}

public class Käynnistä : RobottiKasky
{
    public override void Suorita(Robotti käskyt)
    {
        käskyt.OnKäynnissä = true;
    }
}

public class Sammuta : RobottiKasky
{
    public override void Suorita(Robotti käskyt)
    {
        käskyt.OnKäynnissä = false;
    }
}

public class Vasen : RobottiKasky
{
    public override void Suorita(Robotti Käskyt)
    {
        if (Käskyt.OnKäynnissä)
        {
            Käskyt.X -= 1;
        }
    }
}
public class Oikea : RobottiKasky
{
    public override void Suorita(Robotti Käskyt)
    {
        if (Käskyt.OnKäynnissä)
        {
            Käskyt.X += 1;
        }
    }
}
public class Ylös : RobottiKasky
{
    public override void Suorita(Robotti Käskyt)
    {
        if (Käskyt.OnKäynnissä)
        {
            Käskyt.Y -= 1;
        }
    }
}
public class Alas : RobottiKasky
{
    public override void Suorita(Robotti Käskyt)
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
            
            Console.WriteLine("Mitä kommentoa syötetään robotille: käynistä, sammuta, ylös, alas, vasen, oikea.");
            string vastaus = Console.ReadLine();
            
            if(vastaus == "käynistä")
            {
                robotti.Käskyt[i] = new Käynnistä();
            }
            if(vastaus == "sammuta")
            {
                robotti.Käskyt[i] = new Sammuta();
            }
            if(vastaus == "vasen")
            {
                robotti.Käskyt[i] = new Vasen();
            }
            if(vastaus == "oikea")
            {
                robotti.Käskyt[i] = new Oikea();
            }
            if(vastaus == "ylös")
            {
                robotti.Käskyt[i] = new Ylös();
            }
            if(vastaus == "alas")
            {
                robotti.Käskyt[i] = new Alas();
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