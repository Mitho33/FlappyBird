using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WpfFormsFlappy
{
    public partial class Form1 : Form
    {

       // bool jumping = false;
        int pipeSpeed = 5;
        int gravity = 5;
        int Inscore = 0;

        public Form1()
        {

            InitializeComponent();
            endText1.Text = "Game Over";
            endText2.Text = "Your final score is:" + Inscore;
            gameDesign.Text = "Game Designe by TOM";

            endText1.Visible = false;
            endText2.Visible = false;
            gameDesign.Visible = false;

        }

        private void gameTimer_Tick(object sender, EventArgs e)
        {
            pipeBottom.Left -= pipeSpeed;// pipeBottom.Left = pipeBottom.Left-pipeSpeed, mit jedem Tick wird die unter Säule um 5 nach links gehen
            pipeTop.Left -= pipeSpeed;
            flappyBird.Top += gravity;//flappyBird.Top = flappyBird.Top + gravity, der Vogel senkt sich mit jedem Tick um 5
            scoreText.Text = "" + Inscore;

            if (pipeBottom.Left < -60)
            {
                pipeBottom.Left = 500;
                Inscore += 1;
            }
            else if (pipeTop.Left < -95)
            {
                pipeTop.Left = 600;
                Inscore += 1;
            }
            if (flappyBird.Bounds.IntersectsWith(ground.Bounds))
            {
                endGame();//Methode wird aufgerufen
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeBottom.Bounds))
            {
                endGame();
            }
            else if (flappyBird.Bounds.IntersectsWith(pipeTop.Bounds))
            {
                endGame();
            }
        }
        private void GameKeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)//Leertaste
            {
                //jumping = true;
                gravity = -5;
            }
        }
        private void GameKeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Space)
            {
                //jumping = false;
                gravity = 5;
            }

        }


        private void endGame()
        {
            gameTimer.Stop();
            endText1.Visible = true;
            endText2.Visible = true;
            gameDesign.Visible = true;

        }


    }

    }

