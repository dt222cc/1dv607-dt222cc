using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame : IBlackJackObserver
    {
        private model.Game m_game;
        private view.IView m_view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            m_game = a_game;
            m_view = a_view;

            m_game.AddObserver(this);
        }

        public void AddCardDelay()
        {
            DisplayGame();
            System.Threading.Thread.Sleep(1000);
        }

        public bool Play()
        {
            DisplayGame();

            view.Event e = m_view.GetEvent();

            switch(e) {
                case view.Event.Start:
                    m_game.NewGame();
                    break;
                case view.Event.Hit:
                    m_game.Hit();
                    break;
                case view.Event.Stand:
                    m_game.Stand();
                    break;
                case view.Event.Quit:
                    return false;
            }
            return true;
        }

        private void DisplayGame()
        {
            m_view.DisplayWelcomeMessage();

            m_view.DisplayDealerHand(m_game.GetDealerHand(), m_game.GetDealerScore());
            m_view.DisplayPlayerHand(m_game.GetPlayerHand(), m_game.GetPlayerScore());

            if (m_game.IsGameOver())
            {
                m_view.DisplayGameOver(m_game.IsDealerWinner());
            }
        }
    }
}