using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tic_Tac_toe
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool turn = true; //是否開始回合
        int turn_count = 0; //回合次數

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)//作者介紹
        {
            MessageBox.Show("Hi , I am Spideregg .");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)//離開
        {
            Application.Exit();
        }

        private void button_click(object sender, EventArgs e)//按下按鈕比賽
        {
            Button b = (Button)sender;
            if (turn)
            {
                b.Text = "X";
            }
            else
            {
                b.Text = "O";
            }

            turn = !turn;
            b.Enabled = false;
            turn_count++;
            CheckForWinner();
        }

        private void CheckForWinner()//確認勝負
        {
            bool there_is_the_winner = false;

            //check horizontal
            if (A1.Text == A2.Text && A2.Text == A3.Text && (!A1.Enabled))
            {
                there_is_the_winner = true;
            }
            if (B1.Text == B2.Text && B2.Text == B3.Text && (!B1.Enabled))
            {
                there_is_the_winner = true;
            }
            if (C1.Text == C2.Text && C2.Text == C3.Text && (!C1.Enabled))
            {
                there_is_the_winner = true;
            }

            //check vertical
            if (A1.Text == B1.Text && B1.Text == C1.Text && (!A1.Enabled))
            {
                there_is_the_winner = true;
            }
            if (A2.Text == B2.Text && B2.Text == C2.Text && (!A2.Enabled))
            {
                there_is_the_winner = true;
            }
            if (A3.Text == B3.Text && B3.Text == C3.Text && (!A3.Enabled))
            {
                there_is_the_winner = true;
            }

            //check oblique
            if (A1.Text == B2.Text && B2.Text == C3.Text && (!A1.Enabled))
            {
                there_is_the_winner = true;
            }
            if (C1.Text == B2.Text && B2.Text == A3.Text && (!C1.Enabled))
            {
                there_is_the_winner = true;
            }


            //判斷是否勝利
            if (there_is_the_winner)
            {
                disableButtons();
                String winner = "";
                if (turn)
                    winner = "O";
                else
                    winner = "X";
                MessageBox.Show("Winner is " + winner);
            }
            else
            {
                if (turn_count == 9)
                    MessageBox.Show("Draw");
            }
        }
        //按鈕按過不能在按
        private void disableButtons()
        {
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = false;
                }
            }
            catch
            {

            }
        }

        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)//新場加開
        {
            turn_count = 0;
            turn = true;
            try
            {
                foreach (Control c in Controls)
                {
                    Button b = (Button)c;
                    b.Enabled = true;
                    b.Text = "";
                }
            }
            catch
            {

            }
        }
    }
}

