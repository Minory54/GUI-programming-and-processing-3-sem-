using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    internal class CPlayer
    {
        private int lvl;
        private BigNumber gold;
        private BigNumber damage;
        private double damageModifier;
        private BigNumber upgradeCost;
        private double upgradeCostModifier;

        public CPlayer(BigNumber gold, BigNumber damage, double damageModifier, BigNumber upgradeCost, double upgradeCostModifier, int lvl)
        {
            this.gold = gold;
            this.damage = damage;
            this.damageModifier = damageModifier;
            this.upgradeCost = upgradeCost;
            this.upgradeCostModifier = upgradeCostModifier;

            this.lvl = lvl;
        }

        public BigNumber GetGold() { return gold; }
        public BigNumber GetDamage() { return damage; }
        public double GetDamageModifier() { return damageModifier; }
        public BigNumber GetUpgradeCost() { return upgradeCost; }
        public double GetUpgradeCostModifier() { return upgradeCostModifier; }
        public int GetLvl() { return lvl; }

        public bool GainGold(BigNumber gold)
        {
            this.gold.Add(gold);
            return true;
        }

        public bool Upgrade()
        {
            if (Convert.ToInt32(gold.GetStringNumber()) > Convert.ToInt32(upgradeCost.GetStringNumber()))
            {
                gold.Subtract(upgradeCost);

                upgradeCost.Multiply(new BigNumber(Convert.ToString(upgradeCostModifier)));
                damage.Multiply(new BigNumber(Convert.ToString(damageModifier)));

                lvl++;

                return true;
            }

            return false;
        }
    }
}
