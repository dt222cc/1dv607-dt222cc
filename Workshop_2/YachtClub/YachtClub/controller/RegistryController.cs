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

        public RegistryController()
        {
            _startView = new view.StartView();
            // Dependency injection
            _list = new model.MemberList();
            _listView = new view.MemberListView(_list);
        }

        // Render the StartMenu and get/do what user wants to do.
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

        // Render MemberListView (compact or verbose view), get user input from the memberlistview
        private void DisplayMemberList(bool pickedCompactList)
        {
            _listView.DisplayMemberListView(pickedCompactList);

            //DisplayMember();
            int memberId = _listView.GetUserInput();
            if (memberId == 0)
            {
                DoWork();
            }
            model.Member member = _list.GetMemberById(memberId);
            DisplayMember(member);
        }

        // Try to create and add a new member to the list
        private void AddMember(string errorMessage = "")
        {
            try
            {
                // Registration view w/o errormessage depending on first try or not
                _startView.DisplayRegistration(errorMessage);

                int memberId = _startView.GetIntegerFromUser("MemberId       : "); //need to think of a way to skip memberId input
                string name = _startView.GetStringFromUser("Name           : ");
                string personalNumber = _startView.GetStringFromUser("Personal number: ");
                model.Member member = new model.Member(memberId, name, personalNumber);

                // Add member to the list of members
                _list.AddMember(member);
                // Go to that members view after a successful registration
                DisplayMember(member);
            }
            catch (Exception ex)
            {
                // Does the user wants to make another try?
                _startView.DisplayRegistration(ex.Message);
                if (_startView.DoesUserWantsToQuit() == true) {
                    DoWork();
                }
                else
                {
                    AddMember();
                }
            }
        }

        public void DisplayMember(model.Member member)
        {
            _memberView = new view.MemberView(member);
            _memberView.DisplayMember();
        }
    }
}
