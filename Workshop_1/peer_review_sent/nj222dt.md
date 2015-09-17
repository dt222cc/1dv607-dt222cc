#### Peer review sent to Niklas Johannesson	(nj222dt)

![analysis diagram](http://yuml.me/652a5508)
- Model:
 - http://yuml.me/652a5508
- Contact:
 - nj222dt@student.lnu.se
- Members:
 - nj222dt	Niklas Johannesson	
 - ad222kr	Alex Driaguine	
 - wk222as	Wictor Kihlbaum	

##### As a developer would the model help you and why/why not?
 - I believe it was not required to add attributes for the classes but I do think it helps with the understanding of the system better, which in turn can be helpful. 

##### Do you think a domain expert (for example the Secretary) would understand the model why/why not?
- The secretary should be able to understand the model, he/she should be able to deduct what kind of responsibilities he/she have (CalendarEvent & Berth).

##### What are the strong points of the model, what do you think is really good and why?
1. Attributes for some classes are set, which gives a bit more indepth but optional. Larman (9.16 Attributes)

2. Association multiplicity are being used which gives a better understanding, also optional. Larman (9.14 Associations)

3. The model manages the requirements without being too cluttered.

##### What are the weaknesses of the model, what do you think should be changed and why?
1. There could be more consistency on the model regarding use of association multiplicity.

2. Some associations have no names which helps with understanding the model better. Larman (9.14 Associations)

3. It might be because of yUML now that i think of it.

4. According to Larman (9.16 Attributes) the usage of data types. Not necessary go too deep with the attributes. Instead of "type: string" and such go for just "type". Still it's considered OK I believe according to fig 9.24 but notice fig 9.26 usage of money then. Notice fig 9.27 which becomes less cluttered with the more simpler data.

##### Do you think the model has passed the grade 2 (passing grade) criteria?
1. There's no reason for the model to not pass, I think.
- All requirements are met except the #1 Authenticate part which I'm abit confused of.
- There is some minor details that can be improved a bit but not totally necessary.

##### References
1. Larman C., Applying UML and Patterns 3rd Ed, 2005, ISBN: 0131489062