#### Peer review recieved by Sverker Söderlund (ss223ck)
- Contact:
 - ss223ck@student.lnu.se
- Members:
 - ss223ck	Sverker Söderlund	

At first sight your domain model looks like a use case. The biggest problem is the associations that are not correct. 

Their are som classes that are possibly wrong. I would call "person" "role" instead. It might also be a unnecessary class in the domain model.

Authentication is also unnecessary. It's a requirement and doesnt complement in the domain model.

The classes "All Berth" and "Berths" should only be one class. If you make the associations the right 

way it will explain the association between "Secretary","All Berths" and "Boats".

I think your domain model is good. Even thou there is some excessiv information your diagram is clear and it's easy to get a good view of what you want your program to do. 

If you change the associations your program will pass grade 2.

##### References

- Larman C., Applying UML and Patterns 3rd Ed, 2005, ISBN: 0131489062:
 - 9.14 Associations
 - 9.5 Find Conceptual Classes