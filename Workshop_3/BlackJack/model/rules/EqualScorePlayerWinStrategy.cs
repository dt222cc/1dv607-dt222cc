using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    /*
     * If score is 21 or below
     *
     * Player wins if the player's score is equal to the dealer's score
     */
    class EqualScorePlayerWinStrategy: IEqualScoreWinStrategy
    {
        public bool IsDealerWinner(Player a_dealer, Player a_player)
        {
            return a_dealer.CalcScore() > a_player.CalcScore();
        }
    }
}
