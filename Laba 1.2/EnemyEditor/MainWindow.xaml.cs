using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EnemyEditor
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CEnemyTemplateList enemyList = new CEnemyTemplateList();
        CEnemyTemplate enemy;

        CIconList iconList;
        CIcon icon;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void btn_save_Click(object sender, RoutedEventArgs e)
        {
            enemyList.saveToJson("");
        }

        private void btn_load_Click(object sender, RoutedEventArgs e)
        {
            enemyList.loadFromJson("CEnemyTemplateList.json");
            lb_listEnimes.Items.Clear();

            lb_listEnimes.ItemsSource = enemyList.GetListOfEnemyNames();
        }

        private void btn_add_Click(object sender, RoutedEventArgs e)
        {
            try 
            { 
                string iconName = tb_iconName.Text;
                string name = tb_enemyName.Text;
                int baseLife = Convert.ToInt32(tb_baseLife.Text);
                double lifeModifire = Convert.ToDouble(tb_lifeModifire.Text);
                int baseGold = Convert.ToInt32(tb_baseGold.Text);
                double goldModifire = Convert.ToDouble(tb_goldModifire.Text);
                double spawnChance = Convert.ToDouble(tb_spawnChance.Text);

                CEnemyTemplate enemy = new CEnemyTemplate(name, iconName, baseLife, lifeModifire, baseGold, goldModifire, spawnChance);
                enemyList.addEnemy(enemy);

                lb_listEnimes.Items.Add(enemy.getName());
            }         
            catch (Exception ex) { }
        }

        private void btn_remove_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                enemyList.deleteEnemyByName(lb_listEnimes.SelectedValue.ToString());
                lb_listEnimes.Items.RemoveAt(lb_listEnimes.SelectedIndex);
            }
            catch (Exception ex) { }
        }
    }
}