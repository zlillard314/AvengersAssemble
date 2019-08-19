using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class BadGuy : Character
    {
        //fields
        private byte _minDamage; //we will have a biz rule for this

        //properties
        public string Description { get; set; }
        public byte MaxDamage { get; set; }
        public byte MinDamage
        {
            get { return _minDamage; }
            set
            {
                //can't be greater than MaxDamage or less than 1
                if (value <= MaxDamage && value > 0)
                {
                    _minDamage = value;
                }//end if
                else
                {
                    //this is if the value was greater than max or less than 1
                    _minDamage = 1;
                }//end else
            }//end set
        }//end MinDamage

        //ctors
        //only going to have a fqctor
        public BadGuy(string name, int life, byte maxLife, byte hitChance,
            byte block, byte minDamage, byte maxDamage, string desciption)
        {
            MaxDamage = maxDamage; //doing these first due to biz rules
            MaxLife = maxLife;
            MinDamage = minDamage;
            Life = life;
            Name = name;
            HitChance = hitChance;
            Block = block;
            Description = desciption;
        }//end fqctor

        //methods
        public override string ToString()
        {
            return string.Format("\n********BAD GUY*********\n" +
                "{0}\nLife: {1} of {2}\nDamage: {3} to {4}\n" +
                "Block: {5}\t\tDescription:\n{6}\n",
                Name, Life, MaxLife, MinDamage, MaxDamage,
                Block, Description);
        }//end ToString()

        //don't need to override CalcBlock bc we don't have armor, shield, or agility

        //We have to override CalcDamage, it is zero
        public override int CalcDamage()
        {
            //create a Random number variable
            Random randy = new Random();
            return randy.Next(MinDamage, ++MaxDamage);
            //remember the max value in the .Next() is an exclusive upper bound
            //So if the damage was 2-8, if we put that in the next method
            //we would get 2-7...
        }
    }
}
