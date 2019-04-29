using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CardClasses;

namespace BlackJack
{
    public partial class boardFormSimple : Form
    {
        #region Instance Variables
        Deck cards;
        BJHand dealerHand;
        BJHand playerHand;
        #endregion

        public boardFormSimple()
        {
            InitializeComponent();

            // Initializes the instance variables
            cards = new Deck();
            dealerHand = new BJHand();
            playerHand = new BJHand();

            // Shuffles the new deck 10 times
            for(int i = 0; i < 10; i++)
                cards.Shuffle();
        }

        #region Methods
        private void Reset()
        {
            hitButton.Enabled = true;
            standButton.Enabled = true;
            playerWinLabel.Visible = false;
            dealerWinLabel.Visible = false;
            playAgainButton.Enabled = false;

            HideAllCards();

            cards.Shuffle();

            Card c1 = cards.Deal();
            Card c2 = cards.Deal();
            Card c3 = cards.Deal();
            Card c4 = cards.Deal();

            playerHand.AddCard(c1);
            Show(card6, c1);

            dealerHand.AddCard(c2);
            Show(card1, c2);

            playerHand.AddCard(c3);
            Show(card7, c3);

            dealerHand.AddCard(c4);
            Show(card2, c4);
        }

        private bool CheckWinner()
        {
            if (playerHand.IsBusted)
                return false;

            else
            {
                if (!dealerHand.IsBusted)
                {
                    if (playerHand.Score > dealerHand.Score)
                        return true;

                    else
                        return false;
                }

                else
                    return true;
            }
        }

        private void HideAllCards()
        {
            for (int i = 1; i <= 10; i++)
                this.Controls["card" + i].Visible = false;
        }

        private void Show(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\" + c.FileName);
        }

        private void ShowBack(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\black_back.jpg");
        }
        #endregion

        private void frmBoard_Load(object sender, EventArgs e)
        {
            Reset();

            hitButton.Enabled = true;
            standButton.Enabled = true;
            playerWinLabel.Visible = false;
            dealerWinLabel.Visible = false;
            playAgainButton.Enabled = false;
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            playerHand.AddCard(cards.Deal());

            if (CheckWinner())
            {
                playerWinLabel.Visible = true;
                standButton.Enabled = false;
                hitButton.Enabled = false;
                playAgainButton.Enabled = true;
            }
            else
            {
                dealerWinLabel.Visible = true;
                standButton.Enabled = false;
                hitButton.Enabled = false;
                playAgainButton.Enabled = true;
            }
        }

        private void standButton_Click(object sender, EventArgs e)
        {
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            Reset();
        }
    }
}
