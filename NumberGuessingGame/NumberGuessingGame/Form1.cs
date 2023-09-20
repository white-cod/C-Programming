namespace NumberGuessingGame
{
    public partial class Form1 : Form
    {
        private int guessesNeeded;
        private Random rand;

        public Form1()
        {
            InitializeComponent();
            rand = new Random();
        }

        private void label1_Click(object sender, EventArgs e)
        {
            int secretNumber = rand.Next(1, 2001);
            int guess;
            guessesNeeded = 0;

            do
            {
                string input = Microsoft.VisualBasic.Interaction.InputBox("Guess the number from 1 to 2000", "Guessing Game");
                if (int.TryParse(input, out guess))
                {
                    guessesNeeded++;
                    if (guess < secretNumber)
                    {
                        MessageBox.Show("The guessed number is bigger!", "Guessing Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else if (guess > secretNumber)
                    {
                        MessageBox.Show("The guessed number is less!", "Guessing Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show($"You guessed with {guessesNeeded} attempts!", "Guessing Game", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else if (input != "")
                {
                    MessageBox.Show("Invalid input - please enter a number", "Guessing Game", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            } while (guess != secretNumber);

            DialogResult result = MessageBox.Show("Would you like to play again?", "Guessing Game", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                label1_Click(sender, e);
            }
            else
            {
                Close();
            }
        }
    }
}