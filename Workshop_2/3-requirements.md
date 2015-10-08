### Requirements for grade 2
- [Course Page](https://coursepress.lnu.se/kurs/objektorienterad-analys-och-design-med-uml/workshops-2/workshop-2-design/)

Design and implement a simple member registry with CRUD (Create, Retrieve, Update, Delete) functionality. Implementation, class- and interaction-diagrams are to be created and presented. The interaction diagrams should show how a model-view separation is achieved and how the different requirements are met. Design and implementation should match. Save models and implementation in your portfolio. The focus is not to create a usable or fancy user interface but to have a robust and well documented design that can handle change and follows the GRASP. My recommendation is that you base your work on a console application.

OBS: It is not permitted to use any type of framework, however class libraries, api:s etc are permitted. Basically you should design and code your own application.

The following requirements are to be met:

1. Create a new member with a name, personal number, a unique member id should be created and assigned to the new member.
2. List all members in two different ways:
 1. “Compact List”; name, member id and number of boats
 2. “Verbose List”; name, personal number, member id and boats with boat information
- Delete a member
- Change a member’s information
- Look at a specific member’s information
- Register a new boat for a member the boat should have a type (Sailboat, Motorsailer, kayak/Canoe, Other) and a length.
- Delete a boat
- Change a boat’s information
- Persistence (the registry should be saved and loaded for example from a text file.)
- Strict Model-View separation (The model should not depend on the view or user interface in any way (direct or indirect) the user interface (view) should not implement domain functionality)
- Good quality of code (for example naming, standards, duplication)
- An object oriented design and implementation. This includes but is not limited to:
 - Objects are connected using associations and not with keys/ids.
 - Classes have high cohesion and are not too large or have too much responsibility.
 - Classes have low coupling and are not too connected to other entities.
 - Avoid the use of static variables or operations as well as global variables.
 - Avoid hidden dependencies.
 - Informations should be encapsulated.
 - Use a natural design, the domain model should inspire the design.
- Simple error handling. The application should not crash but it does not need to be user friendly.
- Participate in the peer review process

#### You should have the following in your portflio and all parts should match.
- A well tested runable version of the application. For example an .exe or .java files, link to website etc. If it is not easy to run the application you must include instructions on how to run it.
- The source code of the application, with possible instructions on how to compile it, external dependencies etc.
- A class diagram for the entire application, focus on relationships of the classes and important details (do not add every single attribute or operation)
- Sequence diagrams that covers one input requirement (create member, register boat or Change Information) and one output requirement (List members or Look at member info)