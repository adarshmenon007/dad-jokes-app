using DadJokesApp.Common;
using DadJokesLibrary;
using System.Threading.Tasks;
using System.Windows;

namespace DadJokesApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            APIHelper.InitializeClient();
        }

        private async Task LoadRandomJoke()
        {
            var joke = await DadJokesProcessor.LoadRandomJoke();

            displayRandomJoke.Visibility = Visibility.Visible;
            displaySearchedJokes.Visibility = Visibility.Hidden;        

            displayRandomJoke.Content = joke.Joke;
        }

        private async void Window_Loaded(object sender, RoutedEventArgs e)
        {
            await LoadRandomJoke();            
        }

        private async Task SearchJokes()
        {
            var searchTerm = searchTextBox.Text;

            var jokes = await DadJokesProcessor.SearchJokes(searchTerm);            

            displayRandomJoke.Visibility = Visibility.Hidden;
            displaySearchedJokes.Visibility = Visibility.Visible;

            var contents = Utilities.SetSearchContent(jokes, searchTerm);
            displaySearchedJokes.Content = contents;   
                                          
        }

        private async void searchJokesButton_Click(object sender, RoutedEventArgs e)
        {            
            await SearchJokes();
        }        
    }
}
