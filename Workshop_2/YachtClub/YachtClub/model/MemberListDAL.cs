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
        private enum ReadStatus { Indefinite, Member, Boat };

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
                // 1. Creates a list that can contain references to member object.
                List<Member> members = new List<Member>();

                ReadStatus status = ReadStatus.Indefinite;
                Member member = null;
                Boat boat = null;

                // 2. Opens a textfile for reading.
                using (StreamReader reader = new StreamReader(_path))
                {
                    // 3. Reads the file line by line.
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        // a. If there is an empty line, continue with next line.
                        if (line != "")
                        {
                            // b. If there is a section for new member.
                            if (line == _sectionMember)
                            {
                                status = ReadStatus.Member; // Sets status as Member
                            }
                            // c. Else if there is a section for boat.
                            else if (line == _sectionBoat)
                            {
                                status = ReadStatus.Boat; // Sets status as Boat
                            }
                            // e. Else it's a recipe name, an ingredient or an instruction.
                            else
                            {
                                //string[] values = line.Split(new char[] { ';' });  // Divide the line into parts.
                                string[] values = line.Split(';');  // Divide the line into parts.

                                // ii. If status are set that next line are to be translated as a member.
                                if (status == ReadStatus.Member)
                                {
                                    int memberId = int.Parse(values[0]);
                                    string name = values[1];
                                    string personalNumber = values[2];
                                    member = new Member(memberId, name, personalNumber); // Create new member object with three parts
                                    members.Add(member); // Add the line to the list.
                                }
                                // ii. Else if status are set that next line are to be translated as an boat.
                                else if (status == ReadStatus.Boat)
                                {
                                    string[] boats = line.Split(new char[] { ';' });  // Divide the line into parts.

                                    BoatType type;
                                    Enum.TryParse(boats[0], out type);
                                    double length = double.Parse(boats[1]);
                                    DateTime registrationDate = DateTime.Parse(boats[2]);
                                    boat = new Boat(type, length, registrationDate); // Create new boat object with three parts
                                    member.AddBoat(boat); // Add the line to the member.
                                }
                                // iv. Else, there is something wrong.
                                else
                                {
                                    throw new FileLoadException();
                                }
                            }
                        }
                    }
                }
                // 4. Sort the list of members by the id. 
                // 5. Assign the appropriate fields in the class, _members, a reference to the list.
                _members = members.OrderBy(r => r.MemberId).ToList();
                //_members = members;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                //throw new ArgumentException();
            }
        }

        public void Save()
        {
            try
            {
                // Opens a textfile for editing.
                using (StreamWriter writer = new StreamWriter(_path))
                {
                    foreach (Member m in _members)
                    {
                        // Writes a line with a format for member header
                        writer.Write(_sectionMember);
                        // Writes a line with a format for member details, divided with a semicolon
                        writer.WriteLine(m.MemberId + ";" + m.Name + ";" + m.PersonalNumber + ";");
                        // Writes a line for the boats section with similar format
                        foreach (Boat b in m.Boats)
                        {
                            writer.Write(_sectionBoat);
                            writer.WriteLine(b.Type + ";" + b.Length + ";" + b.RegistrationDate + ";");
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