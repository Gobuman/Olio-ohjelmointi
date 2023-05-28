namespace Loppupeliprojekti
{
    class Inventory
    {
        public int potions { get; set; }

        public bool useItem = false;

        public string armourEquip = null;

        public Inventory(int potions)
        {
            this.potions = potions;
        }

        public void InventoryBag(InventoryW weapon, InventoryA armour, Battle def)
        {
            bool closeInv = false;

            while (!closeInv)
            {
                Console.WriteLine($"Potions: {potions}");
                Console.WriteLine("");
                Console.WriteLine(weapon.ToString());
                Console.WriteLine("");
                Console.WriteLine(armour.ToString());

                if (armourEquip == null)
                {
                    armourEquip = armour.normArmour;
                }

                Console.WriteLine($"Armour equiped: {armourEquip}");
                Console.WriteLine("");
                Console.WriteLine("1. Switch armours");
                Console.WriteLine("2. Back");
                string action = Console.ReadLine();
                int convertnum;
                Int32.TryParse(action, out convertnum);
                Console.Clear();
                switch (convertnum)
                {
                    case 1:
                        if (armourEquip == armour.normArmour)
                        {
                            if (armour.armourGet)
                            {
                                armourEquip = armour.stroArmour;
                                def.playerDef = 2f;
                            }

                            else
                            {
                                Console.WriteLine("you only have one type of armour");
                            }
                            
                        }
                        else if (armourEquip == armour.stroArmour)
                        {
                            armourEquip = armour.normArmour;
                            def.playerDef = 1f;
                        }          
                        break;
                    case 2:
                        closeInv = true;
                        break;
                    default:
                        Console.WriteLine("you only need to put numbers 1 or 2");
                        break;

                }
            }
            

        }

        //While in battle, you can use potions to heal yourself
        public void PotionItems(Battle heal)
        {
            while (!useItem)
            {
                Console.WriteLine("Items:");
                Console.WriteLine($"1. Potions: {potions}");
                Console.WriteLine("2. Back");
                string picked = Console.ReadLine();
                int convertnum1;
                Int32.TryParse(picked, out convertnum1);
                switch (convertnum1)
                {
                    case 1:
                        if (potions == 0)
                        {
                            Console.Clear();
                            Console.WriteLine("You have no potions");
                            break;
                        }
                        else
                        {
                            potions -= 1;
                            heal.playerHealth += 10;
                            //if healing goes over your max health, then your health is 10
                            if (heal.playerHealth > 10)
                            {
                                heal.playerHealth = 10;
                            }
                            useItem = true;
                            Console.Clear();
                            Console.WriteLine("You healed all of your health");

                            break;
                        }
                    case 2:
                        useItem = true;
                        break;
                    default:
                        Console.WriteLine("You only need to put 1 or 2");
                        break;
                }
            }
            
        }
    }

    //weapon function
    class InventoryW
    {
        public string sword;

        public string hammer;

        public float swordDmg;

        public float hammerDmg;

        public bool weaponGet;

        public InventoryW(string sword, string hammer, float swordDmg, float hammerDmg, bool weaponGet)
        {
            this.sword = sword;
            this.hammer = hammer;
            this.weaponGet = weaponGet;
            this.swordDmg = swordDmg;
            this.hammerDmg = hammerDmg;
        }

        public override string ToString()
        {
            //Console.WriteLine(weapon.Count);
            string weaponStuff = $"Weapons: {sword}";

            if (weaponGet)
            {
                weaponStuff += ", " + hammer;
            }

            return weaponStuff;
        }
    }

    //armour function
    class InventoryA
    {
        public string normArmour;

        public string stroArmour;

        public bool armourGet { get; set; }

        //Inventory stuffy;

        public InventoryA(string normArmour, string stroArmour, bool armourGet)
        {
            this.normArmour = normArmour;
            this.stroArmour = stroArmour;
            this.armourGet = armourGet;
        }

        public override string ToString()
        {
            string armourStuff = $"Armours: {normArmour}";

            if (armourGet)
            {
                armourStuff += ", " + stroArmour;
            }

            return armourStuff;
        }
    }
}
