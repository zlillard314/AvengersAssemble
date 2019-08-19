using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Combat
    {
        public static void DoAttack(Character attacker, Character defender)
        {
            Random randy = new Random();
            int diceRoll = randy.Next(1, 101);
            System.Threading.Thread.Sleep(33);

            if (diceRoll <= (attacker.CalcHitChance() - defender.CalcBlock()))
            {
                int damageDealt = attacker.CalcDamage();
                defender.Life -= damageDealt;


                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("{0} hit {1} for {2} damage!!!",
                    attacker.Name, defender.Name, damageDealt);
                Console.ResetColor();

            }//End If attack
            else
            {
                Console.WriteLine($"{attacker.Name} missed...");
            }//End Else
        }//End DoAttack

        public static void DoBattle(Player avenger, BadGuy badGuy)
        {
            DoAttack(avenger, badGuy);

            if (badGuy.Life > 0)
            {
                DoAttack(badGuy, avenger);
            }

        }//End DoBattle

    }
}
