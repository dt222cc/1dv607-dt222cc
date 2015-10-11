using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model.rules
{
    interface IEqualScoreWinStrategy
    {
        bool IsDealerWinner(Player a_dealer, Player a_player);
    }
}
