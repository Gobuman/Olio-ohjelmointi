// See https://aka.ms/new-console-template for more information


public class Ovi
{
    public static void Main()
    {
        ovi a = ovi.auki;
        while (true) 
        {
            //ovi b = a;
            Console.Write("Ovi on " + a);
            Console.Write(" Mitä haluat tehdä: ");
            Console.ForegroundColor = ConsoleColor.Blue;
            string vastaus = Console.ReadLine();
            Console.ForegroundColor = ConsoleColor.White;

            if (a == ovi.auki)
            {
                if (vastaus == "sulje")
                {
                    a = (ovi)1;
                }
                else if (vastaus == "lukitse")
                {
                    Console.WriteLine("ovi on silti auki");
                }
                else if (vastaus == "avaa")
                {
                    Console.WriteLine("Ovi on jo auki");
                }
                else if (vastaus == "poista lukitus")
                {
                    Console.WriteLine("Ovi ei ole lukossa");
                }
                else
                {
                    Console.WriteLine("What did you say?");
                }

            }
            else if (a == ovi.kiini)
            {
                if (vastaus == "sulje")
                {
                    Console.WriteLine("Ovi on silti kíini");
                }
                else if (vastaus == "lukitse")
                {
                    a = (ovi)1;
                }
                else if (vastaus == "avaa")
                {
                    a = (ovi)0;
                }
                else if (vastaus == "poista lukitus")
                {
                    Console.WriteLine("Ovi ei ole lukossa");
                }
                else
                {
                    Console.WriteLine("What did you say?");
                }
            }
            else if (a == ovi.lukossa)
            {
                if (vastaus == "sulje" || vastaus == "avaa")
                {
                    Console.WriteLine("Ovi on  jo lukossa");
                }
                else if (vastaus == "lukitse")
                {
                    Console.WriteLine("Ovi on jo lukossa");
                }
                else if (vastaus == "poista lukitus")
                {
                    a = (ovi)2;
                }
                else
                {
                    Console.WriteLine("What did you say?");
                }
            }
        }
    }
    enum ovi { auki, kiini, lukossa }
}