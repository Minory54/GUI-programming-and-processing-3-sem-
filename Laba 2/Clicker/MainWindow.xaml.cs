using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Clicker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        CEnemyList enemyList = new CEnemyList();

        private CEnemy enemy { get; set; }
        public CEnemy Enemy {
            get => enemy;
            set => enemy = value;
        }

        public MainWindow()
        {
            InitializeComponent();

            Enemy = new CEnemy("1", "2", new BigNumber("1"), 1.2, new BigNumber("1"), 1.2, 1.2);
            //l_HP.Content = enemy.GetName();
        }

        private void btn_upgrade_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}