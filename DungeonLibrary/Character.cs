using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonLibrary
{
    public abstract class Character
    {
        //fields
        private int _life;

        //properties
        public string Name { get; set; } //brought in from player
        public byte HitChance { get; set; }
        public byte Block { get; set; }
        public byte MaxLife { get; set; }
        public int Life
        {
            get { return _life; }
            set
            {

                if (value <= MaxLife)
                {
                    _life = value;
                }
                else
                {
                    _life = MaxLife;
                }
            }
        }//end Life

        public virtual int CalcBlock()
        {
            return Block;
        }//end CalcBlock

        public virtual int CalcHitChance()
        {
            return HitChance;
        }//end CalcHitChance

        public virtual int CalcDamage ()
        {
            return 0;
        }//end CalcDamage
    }
}
