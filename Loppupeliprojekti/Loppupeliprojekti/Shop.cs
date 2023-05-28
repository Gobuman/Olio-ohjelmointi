namespace Loppupeliprojekti
{    
    class Shop
    {
        public int money { get; set; }

        public int _money = 0;

        public Potion buy = new Potion();

        public Armour armour = new Armour();

        public Weapon weapon = new Weapon();

        public Shop(int money)
        {
            this.money = money;

        }

        public void Store(Shop player, Inventory inventory, InventoryA _armour, InventoryW _weapon)
        {
  
            bool exitStore = false;
            while (true)
            {
                Console.WriteLine("G'day mate, Welcome to me shop");
                Console.WriteLine($"Money: {player._money}");
                Console.WriteLine("1. 5G Health potion");
                Console.WriteLine("2. 30G Strong armour (Def 1+)");
                Console.WriteLine("3. 40G Hammer (Atk 3+ but a chance of missing an attack)");
                Console.WriteLine("4. Back");
                string action = Console.ReadLine();
                int convertnum;
                Int32.TryParse(action, out convertnum);
                Console.Clear();
                switch (convertnum)
                {
                    case 1:
                        buy.Buy(player, inventory, _armour, _weapon);
                        break;
                    case 2:
                        armour.Buy(player, inventory, _armour, _weapon);
                        break;
                    case 3:
                        weapon.Buy(player, inventory, _armour, _weapon);
                        break;
                    case 4:
                        exitStore = true;
                        break;
                    default:
                        Console.WriteLine("You only need to put 1, 2, 3 ja 4");
                        Console.WriteLine("");
                        break;
                }
                if (exitStore)
                {
                    break;
                }

            }

        }
    }
    abstract class BuyStuff
    {
        public abstract void Buy(Shop player, Inventory stuff, InventoryA armourTrue, InventoryW weaponTrue);
    }

    class Potion : BuyStuff
    {
        public override void Buy(Shop player, Inventory stuff, InventoryA armourTrue, InventoryW weaponTrue)
        {
            if (player._money >= 5)
            {
                player._money -= 5;
                stuff.potions += 1;
                Console.WriteLine("Potion is added to your inventory");
            }
            else
            {
                Console.WriteLine("You don have enough money to buy this");
                Console.WriteLine("");
            }
        }
    }
    class Armour : BuyStuff 
    {
        public override void Buy(Shop player, Inventory stuff, InventoryA armourTrue, InventoryW weaponTrue)
        {
            if (armourTrue.armourGet == true)
            {

            }
            else if (player._money >= 30)
            {
                player._money -= 30;

                armourTrue.armourGet = true;

                Console.Clear();
                Console.WriteLine($"{armourTrue.stroArmour} is added to your inventory");
                Console.WriteLine("Make sure to equip it in the inventory");
                Console.WriteLine("");
            }
        }
    }
    class Weapon : BuyStuff 
    {
        public override void Buy(Shop player, Inventory stuff, InventoryA armourTrue, InventoryW weaponTrue)
        {

            if (player._money >= 40)
            {
                player._money -= 40;

                weaponTrue.weaponGet = true;

                Console.Clear();
                Console.WriteLine($"{weaponTrue.hammer} is added to your inventory");
                Console.WriteLine("You can use this item in combat");
                Console.WriteLine("");
            }
        }
    }
}
