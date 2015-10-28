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
        private view.BoatView _boatView;

        public RegistryController()
        {
            _startView = new view.StartView();
            _memberView = new view.MemberView();
            _boatView = new view.BoatView();
            _list = new model.MemberList();
            _listView = new view.MemberListView(_list);
        }

        // Handle StartMenu related operations (Display startmenu, register member)
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

        // Handle MemberListView related operations (Display list view, get specific member)
        private void DoMemberList(bool pickedCompactList)
        {
            _list.GetMemberList(); // optional
            _listView.DisplayMemberListView(pickedCompactList);

            // Display memberview or go back to startmenu
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

        // Handle MemberView related operations (Display member, member/boat operations)
        private void DoMemberView(model.Member member)
        {
            _memberView.DisplayMember(member);

            try
            {
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
            catch (Exception)
            {
                DoMemberView(member);
            }
        }

        #region MemberOperations
        // Display views, get inputs to create/save member to list
        private void AddMember()
        {
            try
            {
                _startView.DisplayStartMenu();
                int memberId = _list.GetUniqueMemberId();
                string name = _startView.GetStringFromUser(true);
                string personalNumber = _startView.GetStringFromUser(false);
                model.Member member = new model.Member(memberId, name, personalNumber); // Throws exception if fail
                _list.AddMember(member);
                _list.SaveMemberList();
                DoMemberView(member);
            }
            // Using catch do display error messages to user
            catch (Exception ex)
            {
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

        // Display view to change name, get new name and do the change
        private void EditMember(model.Member member)
        {
            try
            {
                _memberView.DisplayMember(member);
                member.Name = _memberView.GetNewName();
                _list.SaveMemberList();
                DoMemberView(member);
            }
            catch (Exception ex)
            {
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

        // Display view to delete a member (confirmation window), delete the member
        private void DeleteMember(model.Member member)
        {
            try
            {
                if (_memberView.ConfirmDelete(member) == true)
                {
                    _list.DeleteMember(member);
                    _list.SaveMemberList();
                    DoMemberList(_listView.GetLastView());
                }
                else
                {
                    DoMemberView(member);
                }
            }
            catch (Exception ex)
            {
                _memberView.DisplayErrorMessage(ex.Message);
                _memberView.PressKeyToContinue();
                DoMemberView(member);
            }
        }
        #endregion

        #region BoatOperations
        // Display views, get inputs to create/save boat to a member
        private void AddBoat(model.Member member) // Which member to add the boat to
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

        // Display view to change a boat's lenght, get new length and do the change
        // Note: Edit boat? isn't more correct to remove a boat and register a new? or is it when you "remodel" an existing boat
        private void EditBoat(model.Member member)
        {
            // Only able to edit and delete boats if you own a boat
            if(member.Boats.Count() == 0) {
                DoMemberView(member);
            }
            else
            {
                try
                {
                    model.Boat boatToEdit = _boatView.GetBoatToEditOrDelete(member, "edit");
                    boatToEdit.Length = _boatView.GetLengthFromUser();
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
                        EditBoat(member);
                    }
                }
            }
        }

        // Display view to delete a boat (pick boat, confirmation window), delete the boat from the member
        private void DeleteBoat(model.Member member)
        {
            if (member.Boats.Count() == 0)
            {
                DoMemberView(member);
            }
            else
            {
                try
                {
                    model.Boat boatToDelete = _boatView.GetBoatToEditOrDelete(member, "delete");
                    if (_boatView.ConfirmDelete() == true)
                    {
                        member.DeleteBoat(boatToDelete);
                        _list.SaveMemberList();
                    }

                    DoMemberView(member);
                }
                catch (Exception ex)
                {
                    _boatView.DisplayErrorMessage(ex.Message);
                    _boatView.PressKeyToContinue();
                    DoMemberView(member);
                }
            }
        }
        #endregion
    }
}