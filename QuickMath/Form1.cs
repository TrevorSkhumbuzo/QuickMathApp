using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuickMath
{
    
    public partial class CfrmQuickMath : Form
    {
        //Declare global variables
        Random Single = new Random();
        int correctAnswer;
        int score = 0;
        int timeLeft = 25;
        

        public CfrmQuickMath()
        {
            InitializeComponent();
           
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            //Display remaining time, start timer, and generate a question
            int score = 0;
            timeLeft = 25;
            lblScore.Text = "Score: 0";
            lblTimeRemaining.Text = "Time Remaining: " + timer1;
            lblResult.Text = "";
            timer1.Start();
            GenerateQuestion();
        }

    
        private void btnAnswer_Click(object sender, EventArgs e)
        {
            //save answer of the user into an int variable variable
            int answer = int.Parse(txtAnswer.Text);
            //If answer is the same as the correct answer, increment score by one and change color of text to green
            if(answer == correctAnswer)
            {
                score++;
                lblScore.Text = string.Format("{0}", score);
                lblResult.ForeColor = Color.Green;
                lblResult.Text = "Correct!\n+2 Sec";
                timeLeft += 2;

            }
            //If answer is not the same as the correct answer, decrement score by five and change color of text to red
            else
            {
                lblResult.ForeColor = Color.Red;
                lblResult.Text = "Wrong!\n-5 Sec";
                timeLeft -= 5;
            }
            //clear the answer and generate a question
            txtAnswer.Clear();
            GenerateQuestion();
        }
        private void GenerateQuestion()
        {
            //Variables with random nnumbers from 1 to 10
            int num1 = Single.Next(1, 11);
            int num2 = Single.Next(1, 11);
            int RandomOperation = Single.Next(1, 4);
            
            switch (RandomOperation)
            {
                //Operations for every case
                case 1:
                    correctAnswer = num1 + num2;
                    lblQuestion.Text = string.Format("{0} + {1} = ?", num1, num2);
                    break;
                case 2:
                    correctAnswer = num1 - num2;
                    lblQuestion.Text = string.Format("{0} - {1} = ?", num1, num2);
                    break;
                case 3:
                    correctAnswer = num1 * num2;
                    lblQuestion.Text = string.Format("{0} x {1} = ?", num1, num2);
                    break;
                default:
                    
                    break;

            }
         
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            //Decrementing the score by 1 everytime the time clicks
            timeLeft--;
            lblTimeRemaining.Text = string.Format("{0}", timeLeft);
            //if time is less or equal to zero, stop the timer and display a message box with the score
            if (timeLeft <= 0)
            {
                timer1.Stop();
                lblTimeRemaining.Text = "Time Remaining: 0";
                MessageBox.Show(string.Format("Time’s Up!Final Score: {0}\nGame Over",score));
            }
        }
    }
}
