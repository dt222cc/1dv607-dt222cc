using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    /*
     * If score is 21 or below
     * 
     * Dealer wins if the dealer's score is greater or equal to the player's score
     */
    class EqualScoreDealerWinStrategy : IEqualScoreWinStrategy
    {
        public bool IsDealerWinner(Player a_dealer, Player a_player)
        {
            return a_dealer.CalcScore() >= a_player.CalcScore();
        }
    }
}
