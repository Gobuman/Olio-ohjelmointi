namespace Loppupeliprojekti
{
    public class Enemy
    {
        public float enemyHealth { get; set; }

        public float enemyDmg { get; set; }

        public string enemyName { get; set; }

        public Enemy(float enemyHealth, float enemyDmg, string enemyName)
        {
            this.enemyHealth = enemyHealth;
            this.enemyDmg = enemyDmg;
            this.enemyName = enemyName;
        }
    }



    


    class program
    {
        static void Main(string[] args)
        {
            Shop player = new Shop(0);
            Battle battle = new Battle(10f, 0f, 1f);
            Inventory sus = new Inventory(0);
            InventoryW weapon = new InventoryW("Sword", "Hammer", 1f, 3f, false);
            InventoryA armour = new InventoryA("Normal Armour", "Strong Armour", false);


            bool quit = false;
            while (!quit)
            {
                Console.WriteLine("Welcome to the game!");
                Console.WriteLine("1. Fight");
                Console.WriteLine("2. Shop");
                Console.WriteLine("3. Inventory");
                Console.WriteLine("4. Quit");
                string input = Console.ReadLine();
                int convertnum;
                Int32.TryParse(input, out convertnum);

                switch (convertnum)
                {
                    //fight
                    case 1:
                        Console.Clear();
                        battle.Turn(player, sus, weapon, armour, battle);
                        break;
                    //shop
                    case 2:
                        Console.Clear();
                        player.Store(player, sus, armour, weapon);
                        break;
                    //Inventory
                    case 3:
                        Console.Clear();
                        sus.InventoryBag(weapon, armour, battle);
                        break;
                    //quitting 
                    case 4:
                        quit = true;
                        Console.Clear();
                        Console.WriteLine("Thank you for playing!");
                        break;
                    default:
                        Console.Clear();
                        Console.WriteLine("you only need to put numbers 1, 2, 3 or 4");
                        continue;
                }
            }
        }
    }
}
