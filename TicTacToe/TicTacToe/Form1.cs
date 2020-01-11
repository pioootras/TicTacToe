using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
    {
    public partial class Form1 : Form
        {
        public Form1()
            {
            InitializeComponent();
            }
        private void Form1_Load(object sender, EventArgs e)
            {
            foreach (Control c in panel2.Controls)
                {
                if (c is Button)
                    {
                    c.Click += new System.EventHandler(Click_on_button); // delegat EventHandler, który identyfikuje metodę click_on_button dostarczająca odpowiedź na zdarzenie naciśnięcia na button 
                    }
                }
            }
        int xo = 0;
        public void Click_on_button(object sender, EventArgs e)
            {
            Button btn = (Button)sender;
            if (btn.Text.Equals("")) // 
                {
                if (xo % 2 == 0) // przy kazdym wybraniu przycisku rośnie wartość zmiennej xo, dzięki modulo zmienia się wyświetlany znak 
                    {
                    btn.Text = "X"; // zmiennej btn przypisany znak X
                    label1.Text = "Kolej na ruch O"; // wyświetlanie w label1 inofrmacji o kolejności ruchu gracza
                    getTheWinner();
                    }
                else
                    {
                    btn.Text = "O"; // zmiennej btn przypisany znak O
                    label1.Text = "Kolej na ruch X";
                    getTheWinner();
                    }
                xo++;
                }
            }
        bool win = false;
        public void getTheWinner()
            {
            if (!button1.Text.Equals("") && button1.Text.Equals(button2.Text) && button1.Text.Equals(button3.Text)) // 1 2 3 
                {
                WinEffect(button1, button2, button3);
                win = true;
                }
            if (!button4.Text.Equals("") && button4.Text.Equals(button5.Text) && button4.Text.Equals(button6.Text)) // 4 5 6
                {
                WinEffect(button4, button5, button6);
                win = true;
                }
            if (!button7.Text.Equals("") && button7.Text.Equals(button8.Text) && button7.Text.Equals(button9.Text)) // 7 8 9
                {
                WinEffect(button7, button8, button9);
                win = true;
                }
            if (!button1.Text.Equals("") && button1.Text.Equals(button4.Text) && button1.Text.Equals(button7.Text)) // 1 4 7
                {
                WinEffect(button1, button4, button7);
                win = true;
                }
            if (!button2.Text.Equals("") && button2.Text.Equals(button5.Text) && button2.Text.Equals(button8.Text)) // 2 5 8 
                {
                WinEffect(button2, button5, button8);
                win = true;
                }
            if (!button3.Text.Equals("") && button3.Text.Equals(button6.Text) && button3.Text.Equals(button9.Text)) // 3 6 9 
                {
                WinEffect(button3, button6, button9);
                win = true;
                }
            if (!button1.Text.Equals("") && button1.Text.Equals(button5.Text) && button1.Text.Equals(button9.Text)) // 1 5 9 
                {
                WinEffect(button1, button5, button9);
                win = true;
                }
            if (!button3.Text.Equals("") && button3.Text.Equals(button5.Text) && button3.Text.Equals(button7.Text)) // 3 5 7 
                {
                WinEffect(button3, button5, button7);
                win = true;
                }

            if (ButtonsLenght() == 9 && win == false)
                {
                label1.Text = "Nikt nie wygrał";
                }
            }
        public int ButtonsLenght()
            {
            int buttonsLenght = 0;
            foreach (Control c in panel2.Controls)
                {
                if (c is Button)
                    {
                    buttonsLenght += c.Text.Length;
                    }
                }
            return buttonsLenght;
            }
        public void WinEffect(Button b1, Button b2, Button b3)
            {
            b1.BackColor = Color.Blue;
            b2.BackColor = Color.Blue;
            b3.BackColor = Color.Blue;
            label1.Text = b1.Text + " Wygrał";
            }

        private void NewPartie_Click(object sender, EventArgs e)
            {
            xo = 0;
            win = false;
            label1.Text = "Graj";
            foreach (Control c in panel2.Controls)
                {
                if (c is Button)
                    {
                    c.Text = "";
                    c.BackColor = Color.White;
                    }
                }
            }   
        }
    }
