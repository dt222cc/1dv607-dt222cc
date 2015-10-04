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
                _list.UpdateList();
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
        #region //MemberOperations

        private void DoMemberView(model.Member member)
        {
            try
            {
                _memberView.DisplayMember(member);

                switch (_memberView.GetMemberOperation())
                {
                    case view.MemberView.MemberOperation.EditMember:
                        EditMember(member);
                        break;
                    case view.MemberView.MemberOperation.DeleteMember:
                        DeleteMember(member);
                        break;
                    case view.MemberView.MemberOperation.AddBoat:
                        AddBoat(member);
                        break;
                    case view.MemberView.MemberOperation.EditBoat:
                        EditBoat(member);
                        break;
                    case view.MemberView.MemberOperation.DeleteBoat:
                        DeleteBoat(member);
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

        private void AddMember()
        {
            try
            {
                _startView.DisplayStartMenu();
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
                _startView.DisplayStartMenu();
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

        // Just member name for the moment
        private void EditMember(model.Member member)
        {
            try
            {
                _memberView.DisplayMember(member);
                string newName = _memberView.ChangeName();
                member.ChangeName(newName);
                _list.SaveMemberList();
                DoMemberView(member);
            }
            catch (Exception ex)
            {
                _memberView.DisplayMember(member);
                _memberView.DisplayErrorMessage(ex.Message);
                if (_memberView.DoesUserWantsToQuit() == true)
                {
                    DoMemberView(member);
                }
                else
                {
                    EditMember(member);
                }
            }
        }

        private void DeleteMember(model.Member member)
        {
            try
            {
                if (_memberView.ConfirmDelete(member) == true)
                {
                    _list.DeleteMember(member);
                    _list.SaveMemberList();
                    DoStartMenu();
                }
                else
                {
                    DoMemberView(member);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #endregion
        #region //MemberOperations
        // Try to create and add a new boat to the member's boatlist
        private void AddBoat(model.Member member)
        {
            try
            {
                _memberView.DisplayMember(member);
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
                _memberView.DisplayMember(member);
                _boatView.DisplayErrorMessage(ex.Message);
                if (_boatView.DoesUserWantsToQuit() == true)
                {
                    DoMemberView(member);
                }
                else
                {
                    AddBoat(member);
                }
            }
        }

        private void EditBoat(model.Member member)
        {
            Console.WriteLine("Not yet implemented");
            try
            {
                //display boats similar to add boat
                //get input
                //change boat info(length?)
                //redirect to memberview
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void DeleteBoat(model.Member member)
        {
            Console.WriteLine("Not yet implemented");
            try
            {
                //display boats similar to add boat
                //get input
                //try to delete boat
                //redirect to memberview
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        #endregion
    }
}