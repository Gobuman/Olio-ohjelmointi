
using System.Security.Cryptography.X509Certificates;

class laukku
{
    public int Tavarat { get; set; }
    public double Paino { get; set; }

    public double Tilavuus { get; set; }

    public laukku(double x, double y)
    {

        Paino = x;
        Tilavuus = y;
    }

    
}


class nuoli : laukku
{
    public nuoli() : base(0.1, 0.05) { }

    public override string ToString()
    {
        return "Nuoli";
    }
}
class jousi : laukku
{
    public jousi() : base(1, 4) { }

    public override string ToString()
    {
        return "Jousi";
    }
}
class köysi : laukku
{
    public köysi() : base(1, 1.5) { }

    public override string ToString()
    {
        return "Köysi";
    }
}
class vesi : laukku
{
    public vesi() : base(2, 2) { }

    public override string ToString()
    {
        return "Vettä";
    }
}
class Ruokaannos : laukku
{
    public Ruokaannos() : base(1, 0.5) { }

    public override string ToString()
    {
        return "Ruokaannos";
    }
}
class miekka : laukku
{
    public miekka() : base(5, 3) { }

    public override string ToString()
    {
        return "Miekka";
    }

}
class Reppu
{
    private List<laukku> tavarat;
    public int MaxTavarat { get; }
    public double MaxTilavuus { get; }
    public double MaxPaino { get; }

    public int tavaroidenMaara => tavarat.Count;
    public double tavaroidenPaino { get; private set; }
    public double tavaroidenTilavuus { get; private set; }

    public Reppu(int maxTavarat, double maxPaino, double maxTilavuus)
    {
        tavarat = new List<laukku>();
        MaxTavarat = maxTavarat;
        MaxPaino = maxPaino;
        MaxTilavuus = maxTilavuus;


    }

    public bool Lisaa(laukku tavara)
    {
        if (tavaroidenMaara < MaxTavarat && tavaroidenPaino + tavara.Paino <= MaxPaino && tavaroidenTilavuus + tavara.Tilavuus <= MaxPaino)
        {
            tavarat.Add(tavara);
            tavaroidenPaino += tavara.Paino;
            tavaroidenTilavuus += tavara.Tilavuus;
            return true;

        }
        return false;
    }
    public override string ToString()
    {
        if (tavarat.Count == 0)
        {
            Console.WriteLine("Repussa on tyhjä");
        }

        string sisalto = "Reppussa on seuraavat tavarat: ";
        
        for (int i = 0; i < tavarat.Count; i++)
        {
            sisalto += tavarat[i].ToString();
            if (i <tavarat.Count - 1)
            {
                sisalto += ", ";
            }
        }
        return sisalto;
    }

}

class program
{
    static void Main(string[] args)
    {
        Reppu reppu = new Reppu(10, 30, 20);

       
        
        while (true)
        {
            
            laukku tavara = null;
            Console.WriteLine(reppu.ToString());
            Console.WriteLine(" ");
            Console.WriteLine($"Repussa on tällä hetkellä {reppu.tavaroidenMaara}/10 tavaraa, {reppu.tavaroidenPaino}/30 paino, ja {reppu.tavaroidenTilavuus}/20 tilavuus");
            Console.WriteLine("mitä haluat lisätä");
            Console.WriteLine("1 - Nuoli");
            Console.WriteLine("2 - Jousi");
            Console.WriteLine("3 - Köysi");
            Console.WriteLine("4 - Vettä");
            Console.WriteLine("5 - Ruokaannos");
            Console.WriteLine("6 - Miekka");
            int vastaus = Convert.ToInt32(Console.ReadLine());
            
            switch (vastaus)
            {
                case 1:
                    tavara = new nuoli();
                    break;
                case 2:
                    tavara = new jousi();
                    break;
                case 3:
                    tavara = new köysi();
                    break;
                case 4:
                    tavara = new vesi();
                    break;
                case 5:
                    tavara = new Ruokaannos();
                    break;
                case 6:
                    tavara = new miekka();
                    break;
                default:
                    Console.WriteLine("kirjoita vain numerolla 1-6");
                    continue;
            }
            
            if (reppu.Lisaa(tavara))
            {
                Console.WriteLine("Tavara lisätty");
            }
            else
            {
                Console.WriteLine("ei voi lisätä");
                break;
            }
           
        }
    }
}