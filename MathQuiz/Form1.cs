using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MathQuiz
{
    public partial class Form1 : Form
    {
        // creates random object called randomizer to create random numbers.
        Random randomizer = new Random();

        // integers to store numbers for addition problem
        int addEnd1;
        int addEnd2;

        // integers to store numbers for subtraction problem
        int minusEnd1;
        int minusEnd2;

        // integers to store numbers for multiplication problem
        int multEnd1;
        int multEnd2;

        // integers to store numbers for division problem
        int divEnd1;
        int divEnd2;

        // integer to keep track of time left
        int timeLeft;

        public void StartTheQuiz()
        {
            // Generate two random numbers to add
            // Store values in 'addEnd1' and 'addEnd2'
            addEnd1 = randomizer.Next(51);
            addEnd2 = randomizer.Next(51);

            // This do-while makes sure that the answer will be greater than zero
            do
            {
                // Generate two random numbers to subtract
                // Store values in 'subtractEnd1' and 'subtractEnd2'
                minusEnd1 = randomizer.Next(51);
                minusEnd2 = randomizer.Next(51);
            } while (minusEnd1 - minusEnd2 < 0);

            // This do-while makes sure that the answer won't be greater than 100
            do
            {
                // Generate two random numbers to multiply
                // Store values in 'multEnd1' and 'multEnd2'
                multEnd1 = randomizer.Next(51);
                multEnd2 = randomizer.Next(51);
            } while (multEnd1 * multEnd2 > 100);
            
            // This do-while statement makes sure that the numbers are easily divided with no remainer or decimals
            do
            {
                // Generate two random numbers to divide
                // Store values in 'divEnd1' and 'divEnd2'
                divEnd1 = randomizer.Next(51);
                divEnd2 = randomizer.Next(51);
                // Can't divide by zero, so this changes it to a one
                if (divEnd2 == 0)
                {
                    divEnd2 = 1;
                }
            } while (divEnd1 % divEnd2 != 0);

            // Convert random numbers to strings
            plusLeftLabel.Text = addEnd1.ToString();
            plusRightLabel.Text = addEnd2.ToString();
            minusLeftLabel.Text = minusEnd1.ToString();
            minusRightLabel.Text = minusEnd2.ToString();
            timesLeftLabel.Text = multEnd1.ToString();
            timesRightLabel.Text = multEnd2.ToString();
            dividedLeftLabel.Text = divEnd1.ToString();
            dividedRightLabel.Text = divEnd2.ToString();

            // Sets sum to zero
            sum.Value = 0;
            // Sets difference to zero
            difference.Value = 0;
            // Sets product to zero
            product.Value = 0;
            // Sets quotient to zero
            quotient.Value = 0;

            // Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
        }

        // Checks answers, returns true if answers are correct
        public bool CheckTheAnswer()
        {
            if ((addEnd1 + addEnd2 == sum.Value) && (minusEnd1 - minusEnd2 == difference.Value) && (multEnd1 * multEnd2 == product.Value) && (divEnd1 / divEnd2 == quotient.Value))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void timeLabel_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private void label10_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label15_Click(object sender, EventArgs e)
        {

        }

        private void label14_Click(object sender, EventArgs e)
        {

        }

        private void label13_Click(object sender, EventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void startButton_Click(object sender, EventArgs e)
        {
            StartTheQuiz();
            startButton.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (CheckTheAnswer())
            {
                // if CheckTheAnswer() returns true, the user got all answers right.  Stop the timer and show a MessageBox
                timer1.Stop();
                MessageBox.Show("You got all the answers right! Congratulations!");
                startButton.Enabled = true;
            }
            if (timeLeft > 0)
            {
                // Display new time left by updating Time Left label
                timeLeft -= 1;
                timeLabel.Text = timeLeft + " seconds";
            }
            else
            {
                // If user ran out of time, stop timer, show a MessageBox, and fill in answers
                timer1.Stop();
                timeLabel.Text = "Time's up!";
                MessageBox.Show("You didn't finish in Time. Sorry!");
                sum.Value = addEnd1 + addEnd2;
                startButton.Enabled = true;
            }
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            // Select the whole answer in the NumericUpDown control.
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
