using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.controller
{
    class RegistryController
    {
        #region MyClasses
        private model.MemberList _list;
        private view.StartView _startView;
        private view.MemberListView _listView;
        private view.MemberView _memberView;
        private view.BoatView _boatView;
        #endregion

        public RegistryController()
        {
            _startView = new view.StartView();
            _memberView = new view.MemberView();
            _boatView = new view.BoatView();
            _list = new model.MemberList();
            _listView = new view.MemberListView(_list);
        }

        // Handle StartMenu related operations
        public void DoStartMenu()
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
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
        private void DoMemberView(model.Member member)
        {
            try
            {
                _memberView.DisplayMember(member);

                switch (_memberView.GetMemberOperation())
                {
                    case view.MemberView.MemberOperation.EditMember:
                        Console.WriteLine("Not yet implemented");
                        EditMember(member);
                        DoMemberView(member);
                        break;
                    case view.MemberView.MemberOperation.DeleteMember:
                        Console.WriteLine("Not yet implemented");
                        DoMemberView(member);
                        break;
                    case view.MemberView.MemberOperation.AddBoat:
                        AddBoatToMember(member);
                        break;
                    case view.MemberView.MemberOperation.HandleBoats:
                        //to boatview get boatoperation
                        Console.WriteLine("Not yet implemented");
                        DoMemberView(member);
                        break;
                    case view.MemberView.MemberOperation.GoBack:
                        DoMemberList(_listView.GetLastView());
                        return;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DoBoatView()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Try to create and add a new member to the list
        private void AddMember()
        {
            try
            {
                _startView.DisplayMemberRegistration(true);

                int memberId = _startView.GetMemberIdFromUser(); //need to think of a way to skip memberId input
                string name = _startView.GetStringFromUser(true);
                string personalNumber = _startView.GetStringFromUser(false);
                model.Member member = new model.Member(memberId, name, personalNumber); //throws exception if fail
                _list.AddMember(member);
                _list.SaveMemberList();
                DoMemberView(member);
            }
            catch (Exception ex)
            {
                _startView.DisplayMemberRegistration(true);
                _startView.DisplayErrorMessage(ex.Message);
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

        private void DeleteMember()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        // Edit what? name? can you change your personal number? just boats?
        private void EditMember(model.Member m)
        {
            try
            {
                string newName = _memberView.ChangeName();
                m.ChangeName(newName);
                _list.SaveMemberList();
            }
            catch (Exception ex)
            {
                _memberView.DisplayMemberRegistration(false);
                _memberView.DisplayErrorMessage(ex.Message);
                if (_memberView.DoesUserWantsToQuit() == true)
                {
                    DoMemberView(m);
                }
                else
                {
                    EditMember(m);
                }
            }
        }

        // Try to create and add a new boat to the member's boatlist
        private void AddBoatToMember(model.Member member)
        {
            try
            {
                _boatView.DisplayMemberRegistration(false);

                model.Boat.BoatType type = _boatView.GetTypeFromUser();
                double length = _boatView.GetLengthFromUser();
                DateTime registrationDate = _boatView.GetRegistrationDate();
                model.Boat boat = new model.Boat(type, length, registrationDate);
                member.AddBoat(boat);
                _list.SaveMemberList();
                DoMemberView(member);
            }
            catch (Exception ex)
            {
                _boatView.DisplayMemberRegistration(false);
                _boatView.DisplayErrorMessage(ex.Message);
                if (_boatView.DoesUserWantsToQuit() == true)
                {
                    DoMemberView(member);
                }
                else
                {
                    AddBoatToMember(member);
                }
            }
        }

        private void DeleteBoatFromMember()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void EditBoat()
        {
            try
            {

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}