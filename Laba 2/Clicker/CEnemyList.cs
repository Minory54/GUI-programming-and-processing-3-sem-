using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Documents;

namespace Clicker
{
    internal class CEnemyList
    {
        List<CEnemy> enemiesList;

        public CEnemyList()
        {
            enemiesList = new List<CEnemy>();
        }

        public void loadFromJson(string path)
        {
            enemiesList.Clear();
            JsonDocument doc = JsonDocument.Parse(File.ReadAllText("CEnemyTemplateList.json"));

            foreach (JsonElement element in doc.RootElement.EnumerateArray())
            {
                string name = element.GetProperty("name").GetString();
                string iconName = element.GetProperty("iconName").GetString();
                string hitPoints = element.GetProperty("baseLife").GetString();
                double lifeModifier = element.GetProperty("lifeModifier").GetDouble();
                string gold = element.GetProperty("baseGold").GetString();
                double goldModifier = element.GetProperty("goldModifier").GetDouble();
                double spawnChance = element.GetProperty("spawnChance").GetDouble();

                CEnemy enemy = new CEnemy(name, iconName, new BigNumber(hitPoints), lifeModifier, new BigNumber(gold), goldModifier, spawnChance);
                enemiesList.Add(enemy);
            }
        }

        public void NormalizeChances()
        {
            var sumValue = enemiesList.Sum(enemy => enemy.GetSpawnChance());

            foreach (var valueEnemy in enemiesList)
            {
                valueEnemy.SetSpawnChance(valueEnemy.GetSpawnChance() / sumValue);
            }
        }

        public CEnemy GetRandomCEnemy()
        {
            var sumValue = enemiesList.Sum(enemy => enemy.GetSpawnChance());

            return enemiesList[new Random().Next(Convert.ToInt32(sumValue))];
        }
    }
}
