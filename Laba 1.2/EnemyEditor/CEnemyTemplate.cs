using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace EnemyEditor
{
    internal class CEnemyTemplate
    {
        [JsonInclude]
        private string name;
        [JsonInclude]
        private string iconName;
        [JsonInclude]
        private int baseLife;
        [JsonInclude]
        private double lifeModifier;
        [JsonInclude]
        private int baseGold;
        [JsonInclude]
        private double goldModifier;
        [JsonInclude]
        private double spawnChance;

        public CEnemyTemplate(string name, string iconName, int baseLife, double lifeModifier, int baseGold, double goldModifier, double spawnChance)
        {
            this.name = name;
            this.iconName = iconName;
            this.baseLife = baseLife;
            this.lifeModifier = lifeModifier;
            this.baseGold = baseGold;
            this.goldModifier = goldModifier;
            this.spawnChance = spawnChance;
        }

        public string getName() { return name; }
        public string getIconName() { return iconName; }
        public int getBaseLife() { return baseLife; }
        public double getLifeModifier() { return lifeModifier; }
        public int getBaseGold() { return baseGold; }
        public double getGoldModifier() { return goldModifier; }
        public double getSpawnChance() { return spawnChance; }
    }
}
