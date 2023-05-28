namespace Loppupeliprojekti
{
    class Battle
    {
        public float playerHealth { get; set; }

        public float _playerHealth = 10f;

        public float healthTrack;

        public float playerDmg { get; set; }

        public float playerDef { get; set; }

        public Random rand = new Random();

        public Enemy vihollinen = null;

        public Battle(float playerHealth, float playerDmg, float playerDef)
        {
            this.playerHealth = playerHealth;
            this.playerDmg = playerDmg;
            this.playerDef = playerDef;
        }

        

        public void Turn(Shop cash, Inventory stuff, InventoryW weapon, InventoryA armour, Battle player)
        {

            player.playerHealth = _playerHealth;
            Player playerAtk = new Player();
            Enemies enemyAtk = new Enemies();
            Select select = new Select();
            Money money = new Money();

            //picking a dificulty
            while (vihollinen == null)
            {
                Console.WriteLine("Pick a dificulty");
                Console.WriteLine("1. Easy(Gnome)");
                Console.WriteLine("2. Normal(Goblin)");
                Console.WriteLine("3. Hard(Ogre)");
                string picked = Console.ReadLine();
                int convertnum1;
                Int32.TryParse(picked, out convertnum1);
                Console.Clear();

                switch (convertnum1)
                {
                    case 1:
                        vihollinen = new Enemy(10f, 1f, "Gnome");
                        break;
                    case 2:
                        vihollinen = new Enemy(15f, 1f, "Goblin");
                        break;
                    case 3:
                        vihollinen = new Enemy(25f, 2f, "Oger");
                        break;
                    default:
                        Console.WriteLine("you only need to put numbers 1, 2 or 3");
                        continue;
                }
            }
                
            //the battle
            while (true)
            {
                healthTrack = player.playerHealth;
                Console.WriteLine($"{vihollinen.enemyName} Health:{vihollinen.enemyHealth}");
                Console.WriteLine($"Your Health:{player.playerHealth}");
                Console.WriteLine("1. Attack");
                Console.WriteLine("2. Items");
                string action = Console.ReadLine();
                int convertnum2;
                Int32.TryParse(action, out convertnum2);
                Console.Clear();

                switch (convertnum2)
                {
                    //attack
                    case 1:
                        if (weapon.weaponGet)
                        {
                            select.Weapon(player, vihollinen, weapon, playerAtk);
                        }
                        else
                        {
                            player.playerDmg = weapon.swordDmg;
                            //player = new Battle(healthTrack, weapon.swordDmg);
                            playerAtk.Attack(player, vihollinen);
                        }
                        break;
                    //items (the funktion is in inventory.cs line 78
                    case 2:
                        stuff.PotionItems(player);
                        break;

                    default:
                        Console.WriteLine("you only need to put numbers 1 or 2");
                        continue;
                }
                if (stuff.useItem)
                {
                    stuff.useItem = false;
                    continue;
                }
                
                // Enemy attacks
                enemyAtk.Attack(player, vihollinen);

                // if enemy health is 0, you win
                if (vihollinen.enemyHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("you win");

                    //and then you earn money
                    money.Gold(cash);
                    vihollinen = null;
                    break;
                }
                // if player health is 0, you lose
                else if (player.playerHealth <= 0)
                {
                    Console.Clear();
                    Console.WriteLine("you lose");
                    vihollinen = null;
                    break;
                }

            }
        }
    }



    interface IWeapon
    {
        void Weapon(Battle battle,Enemy enemy, InventoryW inventory, Player playerAtk);
    }

    interface IAttack
    {
        void Attack(Battle battle, Enemy enemy);
    }

    interface IGainMoney
    {
        void Gold(Shop money);
    }

    // this will pop up if a player has multiple weapons
    class Select : IWeapon
    {
        public void Weapon(Battle battle,Enemy enemy, InventoryW inventory, Player playerAtk)
        {
            bool select = false;
            while (!select)
            {
                Console.WriteLine("Pick a weapon");
                Console.WriteLine($"1. {inventory.sword}");
                Console.WriteLine($"2. {inventory.hammer}");
                string picked = Console.ReadLine();
                int convertnum1;
                Int32.TryParse(picked, out convertnum1);
                Console.Clear();
                switch (convertnum1)
                {
                    //Sword is selected
                    case 1:
                        battle.playerDmg = inventory.swordDmg;
                        playerAtk.Attack(battle, enemy);
                        select = true;
                        break;

                    //Hammer is selected
                    case 2:
                        int miss = battle.rand.Next(0, 3);
                        //player miss
                        if (miss == 1)
                        {
                            Console.WriteLine("You missed");
                        }

                        else
                        {
                            battle.playerDmg = inventory.hammerDmg;
                            playerAtk.Attack(battle, enemy);
                        }
                        select = true;
                        break;
                    default:
                        {
                            Console.WriteLine("you only need to put numbers 1 or 2");
                            break;
                        }
                }
       
            }
        }
    }

    //player attack
    class Player : IAttack
    {
        public void Attack(Battle battle, Enemy enemy)
        {
            //this is for critical chance
            int crit = battle.rand.Next(0, 10);
            float playerDmg = battle.playerDmg;

            //if a player gets a critical hit
            if (crit == 1)
            {
                playerDmg *= 3f;
                Console.WriteLine("critical hit!");
            }

            enemy.enemyHealth -= playerDmg;
            Console.WriteLine($"You dealt {playerDmg} damage");
        }
        

    }

    //enemy attack
    class Enemies : IAttack
    {
        public void Attack(Battle battle, Enemy enemy)
        {
            //this is for critical chance
            int crit = battle.rand.Next(0, 10);
            float enemyDmg = enemy.enemyDmg;

            //if an enemy 
            if (crit == 1)
            { 
                enemyDmg *= 3f;
                Console.WriteLine("critical hit!");
            }
            

            battle.playerHealth -= enemyDmg / battle.playerDef;
            Console.WriteLine($"{enemy.enemyName} deal {enemyDmg}");
            Console.WriteLine("");
        }
    }

    //When winning you earn money
    class Money : IGainMoney
    {
        public void Gold(Shop money)
        {
            Console.WriteLine("+10G");
            money._money += 10;
        }
    }
}

