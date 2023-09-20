namespace NumberGuessingGame1
{
    public partial class Form1 : Form
    {
        private int secretNumber;
        private int minRange;
        private int maxRange;
        private int guessesNeeded;
        private Random rand;

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
            InitializeGame();
        }

        private void InitializeGame()
        {
            minRange = 1;
            maxRange = 2000;
            secretNumber = rand.Next(minRange, maxRange + 1);
            guessesNeeded = 0;
            MessageBox.Show($"Загадайте число от {minRange} до {maxRange} и позвольте мне его угадать!", "Guessing Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
            MakeComputerGuess();
        }

        private void MakeComputerGuess()
        {
            int guess = rand.Next(minRange, maxRange + 1);
            guessesNeeded++;
            DialogResult result = MessageBox.Show($"Ваше число {guess}?", "Guessing Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                MessageBox.Show($"Я угадал ваше число с {guessesNeeded} попытки!", "Guessing Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PlayAgain();
            }
            else
            {
                DialogResult higherLowerResult = MessageBox.Show("Ваше число больше или меньше?", "Guessing Game", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (higherLowerResult == DialogResult.Yes)
                {
                    minRange = guess + 1;
                }
                else if (higherLowerResult == DialogResult.No)
                {
                    maxRange = guess - 1;
                }

                if (minRange <= maxRange)
                {
                    MakeComputerGuess();
                }
                else
                {
                    MessageBox.Show("Больше нет возможных чисел. Вы выиграли!", "Guessing Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    PlayAgain();
                }
            }
        }

        private void PlayAgain()
        {
            DialogResult result = MessageBox.Show("Хотите сыграть еще раз?", "Guessing Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                InitializeGame();
            }
            else
            {
                Close();
            }
        }
    }
}
