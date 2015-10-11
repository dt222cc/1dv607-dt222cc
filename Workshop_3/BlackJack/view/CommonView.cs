using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.view
{
    class CommonView
    {
        /// <summary>
        /// Using ReadKey.KeyChar and extra buttons 'a' and 'd' for faster gameplay
        /// </summary>
        /// <returns>enum Blackjack.view.Event</returns>
        public Event GetEvent()
        {
            char c = System.Console.ReadKey().KeyChar;
            if (c == 'p' || c == 'd')
            {
                return Event.Start;
            }
            if (c == 'h' || c == 'a')
            {
                return Event.Hit;
            }
            if (c == 's')
            {
                return Event.Stand;
            }
            if (c == 'q')
            {
                return Event.Quit;
            }
            return Event.None;
        }
    }
}
