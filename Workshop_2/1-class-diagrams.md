# Class Diagrams
#### StudentId: dt222cc

## Notes:
- The relation with BoatView is a bit tricky, it presents boattypes (so i'm probably missing a dependency to the BoatType enum). It recieves a Member object and picks a Boat to return "from" the Member object, which is why I chose to have a dependeny with the Member class.

## Class diagram:
![class-diagram](http://yuml.me/aaf4ea35)
<!-- ![class-diagram](diagrams/class-diagram-151022.png) -->