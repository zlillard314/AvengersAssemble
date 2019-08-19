using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class Player : Character
    {
        //Properties
        public Avenger CharacterAvenger { get; set; }
        public SpecialAttack EquippedSpecialAttack { get; set; }

        //ctors
        public Player() { }

        public Player(string name, Avenger characterAvenger, int life, byte maxLife,
            byte hitChance, byte block, SpecialAttack equippedSpecialAttack)
        {
            MaxLife = maxLife;
            Name = name;
            Life = life;
            HitChance = hitChance;
            CharacterAvenger = characterAvenger;
            Block = block;
            EquippedSpecialAttack = equippedSpecialAttack;

            //Buffs
            switch (CharacterAvenger)
            {
                case Avenger.Captain_America:
                    break;
                case Avenger.Black_Widow:
                    break;
                case Avenger.Hulk:
                    break;
                case Avenger.Iron_Man:
                    break;
                case Avenger.Spider_Man:
                    break;
                case Avenger.Thor:
                    break;
                case Avenger.Scarlet_Witch:
                    break;
                case Avenger.Hawkeye:
                    break;
            }//end switch
            

        }//end fqctor

        //Methods
        public override string ToString()
        {
            string avenger = "";
            switch (CharacterAvenger)
            {
                case Avenger.Captain_America:
                    avenger = "Captain America";
                    break;
                case Avenger.Black_Widow:
                    avenger = "Black Widow";
                    break;
                case Avenger.Hulk:
                    avenger = "Hulk";
                    break;
                case Avenger.Iron_Man:
                    avenger = "Iron Man";
                    break;
                case Avenger.Spider_Man:
                    avenger = "Spider-Man";
                    break;
                case Avenger.Thor:
                    avenger = "Thor";
                    break;
                case Avenger.Scarlet_Witch:
                    avenger = "Scarlet Witch";
                    break;
                case Avenger.Hawkeye:
                    avenger = "Hawkeye";
                    break;
            }

            return string.Format("\n***{0}***" +
                "Life: {1} of {2}\nHit Chance: {3}%\n" +
                "Description: {4}\nSpecialAttack: {5}\n",
                Name, Life, MaxLife, HitChance, avenger, EquippedSpecialAttack.Name );
        }//end ToString()

        public override int CalcDamage()
        {
            return new Random().Next(EquippedSpecialAttack.MinDamage, 
                ++EquippedSpecialAttack.MaxDamage);
        }//end CalcDamage

        public override int CalcHitChance()
        {
            return base.CalcHitChance() + EquippedSpecialAttack.BonusHitChance;
        }//end CalcHitChance()

    }//end class
}//end namespace
