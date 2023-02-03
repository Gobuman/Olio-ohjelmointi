using System;
public class Ruokaannos
{
    
    public static void Main()
    {
        (pääraakaaine pää2, lisuke lisuk2, kastike kasti2) lista = (pääraakaaine.nautaa, lisuke.perunaa, kastike.curry);

        pääraakaaine pää = pääraakaaine.nautaa;
        lisuke lisuk = lisuke.perunaa;
        kastike kasti = kastike.curry;

        while (true)
        {
            Console.Write("Pääraaka-aine (" + pääraakaaine.nautaa + ", " + pääraakaaine.kanaa + ", " + pääraakaaine.kasviksia + "): ");
            string pääruoka = Console.ReadLine();

            if (pääruoka == "nautaa")
            {
                pää = pääraakaaine.nautaa;
                break;
            }
            else if (pääruoka == "kanaa")
            {
                pää = pääraakaaine.kanaa;
                break;
            }
            else if (pääruoka == "kasviksia")
            {
                pää = pääraakaaine.kasviksia;
                break;
            }
            else
            {
                continue;
            }
        }

        while (true)
        {
            Console.Write("lisuke (" + lisuke.perunaa + ", " + lisuke.riisiä + ", " + lisuke.pastaa + "): ");
            string lisu = Console.ReadLine();

            if (lisu == "perunaa")
            {
                lisuk = lisuke.perunaa;
                break;
            }
            else if (lisu == "riisiä")
            {
                lisuk = lisuke.riisiä;
                break;
            }
            else if (lisu == "pastaa")
            {
                lisuk = lisuke.pastaa;
                break;
            }
            else
            {
                continue;
            }

        }

        while (true)
        {
            Console.Write("kastike (" + kastike.curry + ", " + kastike.hapanimelä + ", " + kastike.pippuri + ", " + kastike.chili + "): ");
            string kas = Console.ReadLine();

            if (kas == "curry")
            {
                kasti = kastike.curry;
                break;
            }
            else if (kas == "hapanimelä")
            {
                kasti = kastike.hapanimelä;
                break;
            }
            else if (kas == "pippuri")
            {
                kasti = kastike.pippuri;
                break;
            }
            else if (kas == "chili")
            {
                kasti = kastike.chili;
                break;
            }
            else
            {
                continue;
            }
        }
        

        Console.WriteLine(pää + " ja " + lisuk + " " + kasti + "-kastikkeella");
        
        
    }
    enum pääraakaaine { nautaa, kanaa, kasviksia };
    enum lisuke { perunaa, riisiä, pastaa };
    enum kastike { curry, hapanimelä, pippuri, chili };
}