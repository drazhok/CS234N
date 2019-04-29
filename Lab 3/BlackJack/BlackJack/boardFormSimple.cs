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

        public void HideAllCards()
        {
            for (int i = 1; i <= 10; i++)
                this.Controls["card" + i].Visible = false;
        }

        public void Show(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\" + c.FileName);
        }

        public void ShowBack(PictureBox p, Card c)
        {
            p.Image = Image.FromFile(System.Environment.CurrentDirectory + "\\Cards\\black_back.jpg");
        }
        #endregion

        private void frmBoard_Load(object sender, EventArgs e)
        {
            HideAllCards();

            hitButton.Enabled = true;
            standButton.Enabled = true;
            playerWinLabel.Visible = false;
            dealerWinLabel.Visible = false;
            playAgainButton.Enabled = false;
        }

        private void hitButton_Click(object sender, EventArgs e)
        {
            playerHand.AddCard(cards.Deal());


        }

        private void standButton_Click(object sender, EventArgs e)
        {
        }

        private void playAgainButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}
