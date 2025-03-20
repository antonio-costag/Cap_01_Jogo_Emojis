using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
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

namespace MatchGame
{
    /// <summary>
    /// Interação lógica para MainWindow.xam
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            SetUpGame();
        }
        private void SetUpGame()
        {
            List<String> animalEmoji = new List<String>()
            {
                "🐷", "🐷",
                "🦍", "🦍",
                "🦐", "🦐",
                "🐈‍", "🐈‍",
                "🐮", "🐮",
                "🐸", "🐸",
                "🐟", "🐟",
                "🐼", "🐼",
            };
            Random random = new Random(); //criando um objeto da classe Random
            foreach(TextBlock textBlock in mainGrid.Children.OfType<TextBlock>()) //Percorrendo todas as minhas TextBlock
            {
                int index = random.Next(0, animalEmoji.Count); //Gera um numero aleatorio entre 0 e o numero de elementos da minha list
                string nextEmoji = animalEmoji[index];
                textBlock.Text = nextEmoji;
                animalEmoji.RemoveAt(index); // Remove o Emoji da lista pra ele não repetir
            }
        }

        TextBlock lastTextBlockClicked;
        bool findingMatch = false;
        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            TextBlock textBlock = sender as TextBlock; //Estou acessando o objeto clicado como uma TextBlock
            if (findingMatch == false)
            {
                textBlock.Visibility = Visibility.Hidden; //deixa essa TextBlock invisivel
                lastTextBlockClicked = textBlock; //diz que a proxima Textblock tem que ser essa
                findingMatch = true; //permite o evento continuar
            }
            else if (textBlock.Text == lastTextBlockClicked.Text)
            {
                textBlock.Visibility = Visibility.Hidden; //deixa a nova TextBlock invisivel
                findingMatch = false; //termina o processo e inicia um novo
            }
            else
            {
                lastTextBlockClicked.Visibility = Visibility.Visible; //deixa a TextBlock anterior visivel novamente
                findingMatch = false; //...
            }
        }
    }
}
