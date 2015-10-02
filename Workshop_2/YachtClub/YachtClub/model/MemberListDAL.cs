using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace YachtClub.model
{
    class MemberListDAL
    {
        private const string _sectionMember = "[Member]";
        private const string _sectionBoat = "[Boat]";
        private const string _path = @"..\..\App_Data\memberlist.txt";

        private List<Member> _members = new List<Member>();

        public List<Member> GetAll()
        {
            Load();
            return _members;
        }

        private void Load()
        {
            try
            {
                // Creates a list that can contain references to member object.
                List<Member> members = new List<Member>();
                
                Member member = null;
                Boat boat = null;

                using (StreamReader reader = new StreamReader(_path))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        if (line != "")
                        {
                            // Divide the line into parts.
                            string[] values = line.Split(';');

                            // If there is a section for new member. (status,memberid,name,personalnumber)
                            if (values[0] == _sectionMember)
                            {
                                int memberId = int.Parse(values[1]);
                                string name = values[2];
                                string personalNumber = values[3];
                                member = new Member(memberId, name, personalNumber);
                                members.Add(member);
                            }
                            // If there is a section for boat. (status,type,length,registrationdate)
                            else if (values[0] == _sectionBoat)
                            {
                                BoatType type;
                                Enum.TryParse(values[1], out type);
                                double length = double.Parse(values[2]);
                                DateTime registrationDate = DateTime.Parse(values[3]);
                                boat = new Boat(type, length, registrationDate);
                                member.AddBoat(boat);
                            }
                            else
                            {
                                throw new FileLoadException();
                            }
                        }
                    }
                }
                //_members = members.OrderBy(r => r.MemberId).ToList();
                _members = members;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void Save()
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(_path))
                {
                    Console.WriteLine("Using StreamWriter");

                    foreach (Member m in _members)
                    {
                        // Writes a line with a format ([Member];MemberId;Name;PersonalNumber)
                        writer.WriteLine("{0};{1};{2};{3};",_sectionMember, m.MemberId, m.Name, m.PersonalNumber);
                        // Writes a line with a format ([Boat];Type;Length;RegistrationDate)
                        foreach (Boat b in m.Boats)
                        {
                            writer.WriteLine("{0};{1};{2};{3};", _sectionBoat, b.Type, b.Length, b.RegistrationDate);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}