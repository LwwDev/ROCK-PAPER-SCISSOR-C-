using System;
using System.Drawing;
using System.Windows.Forms;

namespace RPS_GUI
{
    public class GameForm : Form
    {
        Button rockButton, paperButton, scissorButton;
        Label resultLabel, computerLabel, scoreLabel, roundLabel;
        int playerWins = 0, computerWins = 0, draws = 0;
        int round = 1;
        int bestOf = 5; // Change to 3 for best of 3
        Random random = new Random();

        public GameForm()
        {
            this.Text = "Rock Paper Scissors";
            this.Size = new Size(500, 350);
            this.StartPosition = FormStartPosition.CenterScreen;

            Font buttonFont = new Font("Arial", 14, FontStyle.Bold);

            rockButton = new Button() { Text = "🪨 Rock", Location = new Point(50, 250), Size = new Size(120, 50), Font = buttonFont };
            paperButton = new Button() { Text = "📄 Paper", Location = new Point(190, 250), Size = new Size(120, 50), Font = buttonFont };
            scissorButton = new Button() { Text = "✂️ Scissors", Location = new Point(330, 250), Size = new Size(120, 50), Font = buttonFont };

            rockButton.Click += (s, e) => Play(1);
            paperButton.Click += (s, e) => Play(2);
            scissorButton.Click += (s, e) => Play(3);

            resultLabel = new Label() { Text = "", Location = new Point(50, 50), AutoSize = true, Font = new Font("Arial", 14, FontStyle.Bold) };
            computerLabel = new Label() { Text = "", Location = new Point(50, 90), AutoSize = true, Font = new Font("Arial", 14) };
            scoreLabel = new Label() { Text = "Player: 0  CPU: 0  Draws: 0", Location = new Point(50, 130), AutoSize = true, Font = new Font("Arial", 12) };
            roundLabel = new Label() { Text = $"Round: {round}", Location = new Point(50, 170), AutoSize = true, Font = new Font("Arial", 12, FontStyle.Italic) };

            this.Controls.Add(rockButton);
            this.Controls.Add(paperButton);
            this.Controls.Add(scissorButton);
            this.Controls.Add(resultLabel);
            this.Controls.Add(computerLabel);
            this.Controls.Add(scoreLabel);
            this.Controls.Add(roundLabel);
        }

        private void Play(int playerChoice)
        {
            int pcChoice = random.Next(1, 4);
            string[] choices = { "", "🪨 Rock", "📄 Paper", "✂️ Scissors" };
            computerLabel.Text = $"Computer chose: {choices[pcChoice]}";

            // Determine result
            if (playerChoice == pcChoice)
            {
                resultLabel.Text = "It's a DRAW!";
                resultLabel.ForeColor = Color.Goldenrod;
                draws++;
            }
            else if ((playerChoice == 1 && pcChoice == 3) ||
                     (playerChoice == 2 && pcChoice == 1) ||
                     (playerChoice == 3 && pcChoice == 2))
            {
                resultLabel.Text = "You WIN!";
                resultLabel.ForeColor = Color.Green;
                playerWins++;
            }
            else
            {
                resultLabel.Text = "You LOSE!";
                resultLabel.ForeColor = Color.Red;
                computerWins++;
            }

            // Update scoreboard & round
            round++;
            scoreLabel.Text = $"Player: {playerWins}  CPU: {computerWins}  Draws: {draws}";
            roundLabel.Text = $"Round: {round}";

            // Check if best-of is over
            int roundsNeeded = (bestOf / 2) + 1;
            if (playerWins == roundsNeeded || computerWins == roundsNeeded || round > bestOf)
            {
                string winner = playerWins > computerWins ? "PLAYER WINS THE MATCH!" :
                                computerWins > playerWins ? "COMPUTER WINS THE MATCH!" :
                                "MATCH ENDS IN A DRAW!";
                
                MessageBox.Show(winner, "Match Over", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Reset game
                playerWins = 0;
                computerWins = 0;
                draws = 0;
                round = 1;
                scoreLabel.Text = $"Player: {playerWins}  CPU: {computerWins}  Draws: {draws}";
                roundLabel.Text = $"Round: {round}";
                resultLabel.Text = "";
                computerLabel.Text = "";
            }
        }

        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.Run(new GameForm());
        }
    }
}
