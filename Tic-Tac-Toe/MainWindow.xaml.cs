using System.Windows;
using System.Windows.Controls;

namespace Tic_Tac_Toe
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    /// 
    
    //The object is to get three in a row.
    //Rules:
    //Allow placement only on empty spots.
    //X goes first, then O
    //When you get three in a row, you declare a winner.
    //When a winner is declared, you disable any further development.
    //The menu has File | New Game and File | Exit.
    //New Game will erase the board and start with X again.
    public partial class MainWindow : Window
    {
        string[,] values;
        bool xPlay = true;
        bool gameOver = false;
        public MainWindow()
        {
            InitializeComponent();
            ResetGame();
        }
        private void ResetGame()
        {
            values = new string[3, 3];

            foreach (Button tile in uxGrid.Children)
            {
                tile.Content = null;
            }

            //reset game
            gameOver = false;
            xPlay = true;
            uxPlay.Text = "X's Play";
        }
        private void uxNewGame_Click(object sender, RoutedEventArgs e)
        {
            ResetGame();
        }
        private void CheckForWinner()
        {
            for (int row = 0; row < 3; row++)
            {
                string rowValues = $"{values[row, 0]}{values[row, 1]}{values[row, 2]}";
                if (rowValues == "XXX" || rowValues == "OOO")
                {
                    gameOver = true;
                }
            }
            for (int col = 0; col < 3; col++)
            {
                string colValues = $"{values[0, col]}{values[1, col]}{values[2, col]}";
                if (colValues == "XXX" || colValues == "OOO")
                {
                    gameOver = true;
                }
            }
            //check diagonals
            string diag0values = $"{values[0, 0]}{values[1, 1]}{values[2, 2]}";
            string diag2values = $"{values[0, 2]}{values[1, 1]}{values[2, 0]}";
            {
                if (diag0values == "XXX" || diag0values == "OOO" || diag2values == "XXX" || diag2values == "OOO")
                {
                    gameOver = true;
                }
            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button clicked = sender as Button;

            string currentPlayer;

            if (xPlay)
            {
                currentPlayer = "X";
            }
            else
            {
                currentPlayer = "O";
            }

            int row = int.Parse(clicked.Tag.ToString().Split(',')[0]);
            int col = int.Parse(clicked.Tag.ToString().Split(',')[1]);

            if (!gameOver && string.IsNullOrEmpty((string)clicked.Content))
            {
                values[row, col] = currentPlayer;
                clicked.Content = currentPlayer;

                if (xPlay)
                {
                    uxPlay.Text = "O's Play";
                }
                else
                {
                    uxPlay.Text = "X's Play";
                }
                xPlay = !xPlay;

                CheckForWinner();
                if (gameOver)
                {
                    uxPlay.Text = $"{currentPlayer} won the game";
                }
            }
        }
        private void uxExit_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
