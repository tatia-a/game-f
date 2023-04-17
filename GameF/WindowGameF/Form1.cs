using System;
using Board;
using System.Windows.Forms;

namespace WindowGameF
{
    public partial class Game15 : Form
    {
        Game game;
        const int size = 4;

        public Game15()
        {
            InitializeComponent();
            game = new Game(size);
            HideButtons();
        }

        private void buttonClick(object sender, EventArgs e)
        {
            if (game.Solved())
                return;
            Button button = (Button)sender; // b00
            int x = int.Parse(button.Name.Substring(1, 1));
            int y = int.Parse(button.Name.Substring(2, 1));
            game.PressAt(x, y);
            ShowButtons();

            if (game.Solved())
                labelMoves.Text = "Done! Your score:" + game.moves;
        }
        
        
        private void buttonStart_Click(object sender, EventArgs e)
        {
            game.Start(1000 + DateTime.Now.DayOfYear); 
            ShowButtons();
        }

        void HideButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    ShowDijitAt(0, x, y);
                }
        }

        void ShowButtons()
        {
            for (int x = 0; x < size; x++)
                for (int y = 0; y < size; y++)
                {
                    ShowDijitAt(game.GetDijitAt(x, y), x, y);
                }
            labelMoves.Text = "Steps: " + game.moves;
        }

        private void ShowDijitAt(int digit, int x, int y)
        {
            Button button = (Button)Controls["b" + x + y]; // присваивается кнопка по названию
            button.Text = digit.ToString();
            button.Visible = digit > 0; // скрывает кнопку, если она теперь 0
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Game15_Load(object sender, EventArgs e)
        {

        }
    }
}