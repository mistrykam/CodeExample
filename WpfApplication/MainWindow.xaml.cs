using System.Threading;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApplication
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private async Task<string> GetIt()
        {
            ushort z1 = 0;
            ushort z2 = 10;

            z1++;
            z2++;

            return await GetNextItemAsync();
        }

        private Task<string> GetNextItemAsync()
        {
            return Task.Factory.StartNew(() => GetNextItem());
        }

        private string GetNextItem()
        {
            Thread.Sleep(3000);
            return "Added the second item";            
        }
        
        private void button_Click(object sender, RoutedEventArgs e)
        {
            listBox.Items.Add("Added the first item.");          
            listBox.Items.Add(GetNextItemAsync().Result);
            listBox.Items.Add("Added third item.");
        }
    }
}