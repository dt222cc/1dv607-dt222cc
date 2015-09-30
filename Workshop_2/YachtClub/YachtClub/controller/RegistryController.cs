using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class RegistryController
    {
        private view.StartView _view;
        private model.MemberList _memberList;

        public RegistryController()
        {
            _view = new view.StartView();
            _memberList = new model.MemberList();
        }

        /**
         * Render the StartMenu and get/do what user wants to do.
         */
        public void DoWork()
        {
            _view.DisplayStartMenu();

            switch (_view.GetStartMenuChoice())
            {
                case view.StartView.Choices.ExitApplication:
                    _view.GetByeMessage();
                    break;
                case view.StartView.Choices.ListMembersCompact:
                    DoWork();
                    break;
                case view.StartView.Choices.ListMembersVerbose:
                    DoWork();
                    break;
                case view.StartView.Choices.AddMember:
                    DoWork();
                    return;
            }
        }
    }
}
