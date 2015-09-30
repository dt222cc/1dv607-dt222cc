using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class RegistryController
    {
        private model.MemberList _list;
        private view.StartView _startView;
        private view.MemberListView _listView;
        private view.MemberView _memberView;

        /*
         * Input from MemberListView
         * 0 for Quitting || valid memberId
         */
        private int _result;

        public RegistryController()
        {
            _startView = new view.StartView();
            _memberView = new view.MemberView();
            // Dependency injection
            _list = new model.MemberList();
            _listView = new view.MemberListView(_list);
        }

        /**
         * Render the StartMenu and get/do what user wants to do.
         */
        public void DoWork()
        {
            _startView.DisplayStartMenu();

            switch (_startView.GetStartMenuChoice())
            {
                case view.StartView.Choices.AddMember:
                    AddMember();
                    break;
                case view.StartView.Choices.ListMembersCompact:
                    DisplayMemberList(true);
                    break;
                case view.StartView.Choices.ListMembersVerbose:
                    DisplayMemberList(false);
                    break;
                case view.StartView.Choices.ExitApplication:
                    _startView.GetByeMessage();
                    return;
            }
        }

        // Render MemberListView (compact or verbose view)
        private void DisplayMemberList(bool pickedCompactList)
        {
            _listView.DisplayMemberListView(pickedCompactList);

            DisplayMember();
        }

        // Quit or view a specific member
        private void DisplayMember()
        {
            _result = _listView.GetUserInput();
            if (_result == 0) {
                DoWork();
            }
            else
            {
                _memberView.DisplayMember(_result);
            }
        }

        private void AddMember()
        {

        }
    }
}
