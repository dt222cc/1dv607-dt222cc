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
            _list = new model.MemberList();
            _listView = new view.MemberListView(_list);
        }

        // Render the StartMenu and get/do what user wants to do. Note: thinking of a name change
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

        // Render MemberListView (compact or verbose view), get user input to view member or go back
        private void DisplayMemberList(bool pickedCompactList)
        {
            try
            {
                // Display the ListView
                _listView.DisplayMemberListView(pickedCompactList);

                // Get user input (display memberId or go back)
                int memberId = _listView.GetUserInput();
                if (memberId == 0)
                {
                    DoWork();
                }
                else
                {
                    DisplayMember(_list.GetMemberById(memberId));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
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
                // Try to create a member with valid "or" invalid data
                model.Member member = new model.Member(memberId, name, personalNumber); //throws exception if fail

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

        // Render MemberView with specified Member / TODO Expand?
        public void DisplayMember(model.Member member)
        {
            _memberView = new view.MemberView(member);
            _memberView.DisplayMember();

            DoWork();
        }
    }
}