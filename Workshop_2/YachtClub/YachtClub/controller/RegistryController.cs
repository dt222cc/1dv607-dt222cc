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

        // Handle StartMenu related operations
        public void DoStartMenu()
        {
            _startView.DisplayStartMenu();

            switch (_startView.GetStartMenuChoice())
            {
                case view.StartView.StartMenuOperation.AddMember:
                    AddMember();
                    break;
                case view.StartView.StartMenuOperation.ListMembersCompact:
                    DoMemberList(true);
                    break;
                case view.StartView.StartMenuOperation.ListMembersVerbose:
                    DoMemberList(false);
                    break;
                case view.StartView.StartMenuOperation.ExitApplication:
                    _startView.GetByeMessage();
                    return;
            }
        }

        // Handle MemberListView related operations
        private void DoMemberList(bool pickedCompactList)
        {
            try
            {
                _listView.DisplayMemberListView(pickedCompactList);

                int memberId = _listView.GetUserInput();
                if (memberId == 0)
                {
                    DoStartMenu();
                }
                else
                {
                    DoMemberView(_list.GetMemberById(memberId));
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Handle MemberView related operations
        public void DoMemberView(model.Member member)
        {
            _memberView = new view.MemberView(member);
            _memberView.DisplayMember();

            switch (_memberView.GetMemberOperation())
            {
                case view.MemberView.MemberOperation.EditMember:
                    Console.WriteLine("Not yet implemented!");
                    break;
                case view.MemberView.MemberOperation.DeleteMember:
                    Console.WriteLine("Not yet implemented!");
                    break;
                case view.MemberView.MemberOperation.AddBoat:
                    Console.WriteLine("Not yet implemented!");
                    break;
                case view.MemberView.MemberOperation.HandleBoats:
                    Console.WriteLine("Not yet implemented!");
                    break;
                case view.MemberView.MemberOperation.GoBack:
                    DoMemberList(_listView.GetLastView());
                    return;
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
                // Try to create a member with valid/invalid data
                model.Member member = new model.Member(memberId, name, personalNumber); //throws exception if fail
                _list.AddMember(member);

                // After a successful registration
                DoMemberView(member);
            }
            catch (Exception ex)
            {
                // Does the user wants to make another try?
                _startView.DisplayRegistration(ex.Message);
                if (_startView.DoesUserWantsToQuit() == true)
                {
                    DoStartMenu();
                }
                else
                {
                    AddMember();
                }
            }
        }
    }
}