using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Clicker
{
    public class CEnemy
    {
        public string name { get; }
        private string iconName;
        private BigNumber hitPoints;
        private double hitPointsModifier;
        private BigNumber gold;
        private double goldModifier;
        private double spawnChance;

        public CEnemy(string name, string iconName, BigNumber hitPoints, double hitPointsModifier, BigNumber gold, double goldModifier, double spawnChance)
        {
            this.name = name;
            this.iconName = iconName;
            this.hitPoints = hitPoints;
            this.hitPointsModifier = hitPointsModifier;
            this.gold = gold;
            this.goldModifier = goldModifier;
            this.spawnChance = spawnChance;
        }

        public string GetName() { return name; }
        public string getIconName() { return iconName; }
        public BigNumber GetHitPoints() { return hitPoints; }
        public double getHitPointsModifier() { return hitPointsModifier; }
        public BigNumber GetGold() { return gold; }
        public string GetIconName() { return iconName; }
        public double getGoldModifier() { return goldModifier; }
        public double GetSpawnChance() { return spawnChance; }
        
        public void SetHitPoints(BigNumber inDamage)
        {
            hitPoints.Subtract(inDamage);
        }

        public void SetSpawnChance(double SpawnChance)
        {
            spawnChance = SpawnChance;
        }
    }
}
