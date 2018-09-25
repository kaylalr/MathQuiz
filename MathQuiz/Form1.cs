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

        // integer to keep track of time left
        int timeLeft;

        public void StartTheQuiz()
        {
            // Fill in addition problem
            // Generate two random numbers to add
            // Store values in 'addEnd1' and 'addEnd2'
            addEnd1 = randomizer.Next(51);
            addEnd2 = randomizer.Next(51);

            // Convert random numbers to strings
            plusLeftLabel.Text = addEnd1.ToString();
            plusRightLabel.Text = addEnd2.ToString();

            // Sets sum to zero
            sum.Value = 0;

            // Start the timer
            timeLeft = 30;
            timeLabel.Text = "30 seconds";
            timer1.Start();
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
            if (timeLeft > 0)
            {
                // Display new time left by updating Time Left label
                timeLeft -= timeLeft;
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

    }
}
