using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public class SpecialAttack
    {
        //fields
        private string _name;
        private byte _minDamage;
        private byte _maxDamage;
        private byte _bonusHitChance;
        private bool _isTwoHanded;

        //properties
        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }//end Name
        public byte MaxDamage
        {
            get { return _maxDamage; }
            set { _maxDamage = value; }
        }//MaxDamage
        public byte MinDamage
        {
            get { return _minDamage; }
            set
            {
                if (value <= MaxDamage && value > 0)
                {
                    _minDamage = value;
                }
                else
                {
                    _minDamage = 1;
                }
            }
        }//end MinDamage
        public byte BonusHitChance
        {
            get { return _bonusHitChance; }
            set { _bonusHitChance = value; }
        }//end BonusHitChance
        public bool IsTwoHanded
        {
            get { return _isTwoHanded; }
            set { _isTwoHanded = value; }
        }//end IsTwoHanded

        //ctors
        public SpecialAttack() { }

        public SpecialAttack(string name, byte minDamage, byte maxDamage, 
            bool isTwoHanded, byte bonusHitChance)
        {
            MaxDamage = maxDamage;
            MinDamage = minDamage;
            Name = name;
            IsTwoHanded = isTwoHanded;
            BonusHitChance = bonusHitChance;
        }//end ctors

        //methods
        public override string ToString()
        {
            return string.Format($"{Name}\n{MinDamage} to {MaxDamage} Damage\n" +
                "Bonus Hit Chance: {3}\n{4}", BonusHitChance,
                (IsTwoHanded ? "Two Handed" : "One Handed"));
        }

    }
}
