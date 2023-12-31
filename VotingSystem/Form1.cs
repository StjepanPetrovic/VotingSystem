﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VotingSystem
{
    public partial class FormVoting : Form
    {
        public FormVoting()
        {
            InitializeComponent();
            VoteRepository voteRepository = new VoteRepository();
        }

        private void btnVote_Click(object sender, EventArgs e)
        {
            Voter voter = new Voter();

            voter.OIB = txtOIB.Text;
            voter.Option = cbBoxOption.Text;

            int NumChar = 0;
            bool OibIsFalse = false;

            foreach (char character in voter.OIB)
            {
                NumChar++;

                if (Char.IsLetter(character))
                {
                    OibIsFalse = true;
                    break;
                }
            }

            if (voter.OIB == "")
            {
                MessageBox.Show("Please, enter OIB");
            }
            else if (OibIsFalse || NumChar != 11)
            {
                MessageBox.Show("Please, enter correct OIB (11 digits)");
            }
            else if (VoteRepository.AlreadyVote(voter.OIB))
            {
                MessageBox.Show("OIB is already used.");
            }
            else
            {
                if (voter.Option == "FOR")
                {
                    lblForSum.Text = (++VoteRepository.SumFor).ToString();
                    VoteRepository.NewVoter(voter);
                }
                else if (voter.Option == "AGAINST")
                {
                    lblAgainstSum.Text = (++VoteRepository.SumAgainst).ToString();
                    VoteRepository.NewVoter(voter);
                }
                else if (voter.Option == "ABSTAINED")
                {
                    lblAbstainedSum.Text = (++VoteRepository.SumAbstained).ToString();
                    VoteRepository.NewVoter(voter);
                }
                else
                {
                    MessageBox.Show("Please, choose option.");
                }
            }
        }
    }
}
