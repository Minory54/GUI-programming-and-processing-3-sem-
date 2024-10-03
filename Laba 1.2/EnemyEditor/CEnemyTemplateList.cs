using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.IO;

namespace EnemyEditor
{
    internal class CEnemyTemplateList
    {
        List<CEnemyTemplate> enemies;

        public CEnemyTemplateList()
        {
            enemies = new List<CEnemyTemplate>();
        }

        public void addEnemy (CEnemyTemplate enemy)
        {
            enemies.Add(enemy);
        }

        public CEnemyTemplate getEnemyByName(string name)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].getName() == name)
                {
                    return enemies[i];
                }
            }

            return null;
        }

        public CEnemyTemplate getEnemyByIndex(int id) 
        { 
            return enemies[id];
        }

        public void deleteEnemyByName(string name)
        {
            for (int i = 0; i < enemies.Count; i++)
            {
                if (enemies[i].getName() == name)
                {
                    enemies.Remove(enemies[i]);
                }
            }
        }

        public void deleteEnemyByIndex(int id)
        {
            enemies.Remove(enemies[id]);
        }

        public List<CEnemyTemplate> GetCEnemyTemplatesList() 
        {
            return enemies;
        }

        public void saveToJson(string path)
        {
            File.WriteAllText("CEnemyTemplateList.json", JsonSerializer.Serialize(enemies));
        }

        public void loadFromJson(string path)
        {
            enemies.Clear();
            JsonDocument doc = JsonDocument.Parse(File.ReadAllText("CEnemyTemplateList.json"));

            foreach (JsonElement element in doc.RootElement.EnumerateArray())
            {
                string name = element.GetProperty("name").GetString();
                string iconName = element.GetProperty("iconName").GetString();
                int baseLife = element.GetProperty("baseLife").GetInt32();
                double lifeModifier = element.GetProperty("lifeModifier").GetDouble();
                int baseGold = element.GetProperty("baseGold").GetInt32();
                double goldModifier = element.GetProperty("goldModifier").GetDouble();
                double spawnChance = element.GetProperty("spawnChance").GetDouble();

                CEnemyTemplate enemy = new CEnemyTemplate(name, iconName, baseLife, lifeModifier, baseGold, goldModifier, spawnChance);
                enemies.Add(enemy);
            }
        }

        public List<string> GetListOfEnemyNames()
        {
            List<string> enemyNames = new List<string>();
            loadFromJson("CEnemyTemplateList.json");

            for (int i = 0; i < enemies.Count; i++)
            {
                enemyNames[i] = enemies[i].getName();
            }

            return enemyNames;
        }
    }
}
