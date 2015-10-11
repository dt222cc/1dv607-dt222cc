using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlackJack.controller
{
    class PlayGame
    {
        private model.Game _game;
        private view.IView _view;

        public PlayGame(model.Game a_game, view.IView a_view)
        {
            _game = a_game;
            _view = a_view;
        }

        public bool Play()
        {
            _view.DisplayWelcomeMessage();

            _view.DisplayDealerHand(_game.GetDealerHand(), _game.GetDealerScore());
            _view.DisplayPlayerHand(_game.GetPlayerHand(), _game.GetPlayerScore());

            if (_game.IsGameOver())
            {
                _view.DisplayGameOver(_game.IsDealerWinner());
            }

            view.Event e = _view.GetEvent();

            switch(e) {
                case view.Event.Start:
                    _game.NewGame();
                    break;
                case view.Event.Hit:
                    _game.Hit();
                    break;
                case view.Event.Stand:
                    _game.Stand();
                    break;
                case view.Event.Quit:
                    return false;
            }
            return true;
        }
    }
}
