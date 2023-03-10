using System;

string karkitilaus = "a";
string peratilaus = "b";
string vas = "c";
int pituustilaus = 0;
string haluttupituus;
Nuoli tilattuNuoli;

while (true)
{
    Console.WriteLine("Haluaisitko tehdä sinun oma nuoli (oma)");
    Console.WriteLine("Tai haluaisitko valita valmiina tehty nuoli (valitse)");
    vas = Console.ReadLine();

    if (vas == "oma" || vas == "valitse")
    {
        break;
    }
}
    
if (vas == "oma")
{
    Console.WriteLine("Minkälainen kärki (puu, teräs, timantti) :");
    while (karkitilaus != "puu" || karkitilaus != "teräs" || karkitilaus != "timantti")
    {
        karkitilaus = Console.ReadLine();
        if (karkitilaus == "puu" || karkitilaus == "timantti" || karkitilaus == "teräs")
        {
            break;
        }
    }
    Console.WriteLine("Minkälainen perä (lehti, kanansulka, kotkansulka) :");
    while (peratilaus != "lehti" || peratilaus != "kanansulka" || peratilaus != "kotkansulka")
    {
        peratilaus = Console.ReadLine();
        if (peratilaus == "lehti" || peratilaus == "kanansulka" || peratilaus == "kotkansulka")
        {
            break;
        }
    }
    Console.WriteLine("Nuolen pituus (60-100cm) :");
    while (pituustilaus < 60 || pituustilaus > 100)
    {
        haluttupituus = Console.ReadLine();

        if (int.TryParse(haluttupituus, out pituustilaus) == true && pituustilaus < 100 && pituustilaus > 60)
        {
            break;
        }
    }
    tilattuNuoli = new Nuoli(karkitilaus, peratilaus, pituustilaus);
    Console.WriteLine($"Nuoli maksaa {tilattuNuoli.PalautaHinta} kultaa");

}

else if (vas == "valitse")
{
    while (true)
    {
        Console.WriteLine("Minkälainen nuoli haluaisit ostaa (aloittelija, perus, eliitti)");
        vas = Console.ReadLine();

        if (vas == "aloittelija")
        {
            tilattuNuoli = Nuoli.LuoAloittelijaNuoli();
            break;
        }
        else if (vas == "perus")
        {
            tilattuNuoli = Nuoli.LuoPerusNuoli();
            break;
        }
        else if (vas == "eliitti")
        {
            tilattuNuoli = Nuoli.LuoEliittiNuoli();
            break;
        }
    }
    Console.WriteLine($"{vas} nuoli maksaa {tilattuNuoli.PalautaHinta} kultaa");

}




public class Nuoli
{
    private string _karki;
    private string _pera;
    private double _pituus;
    private double nuolenhinta;

    public static Nuoli LuoEliittiNuoli()
    {
        return new Nuoli("timantti", "kotkansulka", 100);
    }
    public static Nuoli LuoPerusNuoli()
    {
        return new Nuoli("teräs", "kanansulka", 85);
    }
    public static Nuoli LuoAloittelijaNuoli()
    {
        return new Nuoli("puu", "kanansulka", 70);
    }
    public Nuoli(string karki, string pera, int pituus)
    {
        _karki = karki;
        _pera = pera;
        _pituus = pituus;

        if (_karki == "puu")
        {
            nuolenhinta += 3;
        }
        if (_karki == "teräs")
        {
            nuolenhinta += 5;
        }
        if (_karki == "timantti")
        {
            nuolenhinta += 50;
        }
        if (_pera == "kanansulka")
        {
            nuolenhinta += 1;
        }
        if (_pera == "kotkansulka")
        {
            nuolenhinta += 5;
        }



        nuolenhinta = nuolenhinta + _pituus * 0.05;
        return;
    }

    public double PalautaHinta
    {
        get { return nuolenhinta; }
        set { nuolenhinta = value; }
    }
    public string Karki
    {
        get { return _karki; }
        set { _karki = value; }
    }
    public string Pera
    {
        get { return _pera; }
        set { _pera = value; }   
    }
    public double Pituus
    {
        get { return _pituus; }
        set { _pituus = value; }
    }
}