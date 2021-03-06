﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.model
{
    class Dealer : Player
    {
        private const int g_maxScore = 21;

        private Deck m_deck = null;
        private List<IBlackJackObserver> m_observers = new List<IBlackJackObserver>();

        private rules.INewGameStrategy m_newGameRule;
        private rules.IHitStrategy m_hitRule;
        private rules.IEqualScoreWinStrategy m_equalScoreRule;

        public Dealer(rules.RulesFactory a_rulesFactory)
        {
            m_newGameRule = a_rulesFactory.GetNewGameRule();
            m_hitRule = a_rulesFactory.GetHitRule();
            m_equalScoreRule = a_rulesFactory.GetEqualScoreRule();
        }

        public bool NewGame(Player a_player)
        {
            if (m_deck == null || IsGameOver())
            {
                m_deck = new Deck();
                ClearHand();
                a_player.ClearHand();
                return m_newGameRule.NewGame(this, a_player);
            }
            return false;
        }

        public bool Hit(Player a_player)
        {
            if (m_deck != null && a_player.CalcScore() < g_maxScore && !IsGameOver())
            {
                //Card c = m_deck.GetCard();
                //c.Show(true);
                //a_player.DealCard(c);

                GetNewCard(a_player);

                return true;
            }
            return false;
        }

        public bool IsDealerWinner(Player a_player)
        {
            if (a_player.CalcScore() > g_maxScore)
            {
                return true;
            }
            else if (CalcScore() > g_maxScore)
            {
                return false;
            }
            return m_equalScoreRule.IsDealerWinner(this, a_player);
        }

        public bool IsGameOver()
        {
            if (m_deck != null && /*CalcScore() >= g_hitLimit*/ m_hitRule.DoHit(this) != true)
            {
                return true;
            }
            return false;
        }

        public bool Stand()
        {
            if (m_deck != null) {
                ShowHand();

                while (m_hitRule.DoHit(this)) {
                    GetNewCard(this);
                }
                return true;
            }
            return false;
        }

        public void GetNewCard(Player a_player, bool a_showCard = true)
        {
            foreach (IBlackJackObserver a_observer in m_observers)
            {
                a_observer.AddCardDelay();
            }
            Card c = m_deck.GetCard();
            c.Show(a_showCard);
            a_player.DealCard(c);
        }

        public void AddObserver(IBlackJackObserver a_observer)
        {
            m_observers.Add(a_observer);
        }
    }
}