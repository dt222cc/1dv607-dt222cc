using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    /*
     *  Soft 17 means that the dealer has 17 but in a combination of Ace and 6 (for example Ess, tvåa, tvåa, tvåa).
     *  This means that the Dealern can get another card valued at 10 but still have 17 as the value of the ace is reduced to 1.
     *  Using the soft 17 rule the dealer should take another card
     *  (compared to the original rule when the dealer only takes cards on a score of 16 or lower).
     */

    class Soft17HitStrategy: IHitStrategy
    {
        private const int HitLimit = 17;

        public bool DoHit(Player dealer)
        {
            int score = dealer.CalcScore();
            if (score == HitLimit)
            {
                foreach (Card c in dealer.GetHand())
                {
                    if (c.GetValue() == Card.Value.Ace)
                    {
                        return true;
                    }
                }
            }
            return score < HitLimit;
        }
    }
}
