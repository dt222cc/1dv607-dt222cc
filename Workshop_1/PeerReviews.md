# Peer Reviews
## StudentId: dt222cc

### Written to:

------------------------------------------------------
#### 1
- Model:
 - https://github.com/AndreasAnemyrLNU/1dv607/blob/master/WS%201%20-%20Domain%20Modeling.pdf
- Contact:
 - aa223ig@student.lnu.se
- Members:
 - aa223ig	Andréas Anemyr	

##### As a developer would the model help you and why/why not?
- I believe that the model is helpful. It's clear, consistent and understandable so you will get a good idea of the projects content.

##### Do you think a domain expert (for example the Secretary) would understand the model why/why not?
- The secretary should be able to understand the model, he/she should be able to deduct what kind of responsibilities he/she have (BoatRegister & Calendar).

- Have you considered what kind of connection Secretary have with Berth? Like how can he/she know what berths is available? Does the BoatRegister have access to berths or is it perhaps through boats. In that case only the boats "with" a berth is registered in the BoatRegister.

##### What are the strong points of the model, what do you think is really good and why?
1. As mention before, the model is pretty detailed and each association has a description that describes the associations well.

2. Multiplicity is optional but included (note: missing for Event-EventDescription).

##### What are the weaknesses of the model, what do you think should be changed and why?
1. I'm not so sure about the position the description is on (above/under), it took a few moments of thinking to understand it. In this model it's counter-clockwise which is perhaps the correct way but for me, a tiny bit confusing as I tend to think in clockwise direction. In my case i didn't include them but later on I added them when i simplified my model more and yUML didnt really manage them so well :(

##### Do you think the model has passed the grade 2 (passing grade) criteria?
- The model contains the requirements that was needed for the grade so there should be no problems passing.

##### References
1. Larman C., Applying UML and Patterns 3rd Ed, 2005, ISBN: 0131489062

------------------------------------------------------

#### 2
- Model:
 - http://yuml.me/652a5508
![analysis diagram](http://yuml.me/652a5508)
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

------------------------------------------------------

### Feedback from:

#### 1
- Contact:
 - ss223ck@student.lnu.se
- Members:
 - ss223ck	Sverker Söderlund	

------------------------------------------------------

#### 2
- Contact:
 - rn222cx@student.lnu.se
- Members:
 - rn222cx	Roy Nilsson		
 - cs222wa	Carolina Skov Pedersen	
 - aa223gg	Anna Aldenmark

##### What are the strong points of the model 
- The model covers the main conceptual classes in order to get a good idea of what the project contains.

##### What are the weaknesses of the model
1. “Berths” is an extension of the class “All Berths” and should therefore not be written like an individual class. (Larman, fig. 9.5)

2. “Authentication” class is a software aspect and should be removed. According to Larman (section 9.2), the model should be a visualization about things in real life, rather than about software objects.

3. The class “Person” contains no actual information to the model and is redundant since the classes “Member” and “Secretary” already exists.

4. The association lines of the model are cluttering the view as they run through the descriptive text for the different associations; making them unreadable.

5. The view relations between the classes are redundant to the model and should be removed. According to Larman (note [2], section 9.2), the display of conceptual views in a domain have been widely re-interpreted as data models for database design – not for domain models. 

6. It is only optional to have multiplicity expression at each end of an association (Larman, section 9.14), but in this case it would have made the model a lot clearer if they had been included.

7. According to Larman (fig 9.12) you shouldn't use navigation arrows. Good associations will describe which way the arrows should be. Reading direction arrows can be used instead but is often excluded. 

8. The model contains too many associations. Larman’s (section 9.14) recommendation is to avoid this.

9. Class names should be named as singular nouns. (Ambler, section 5.2)

10. The association names includes bad names like “have” instead of names that really show how the classes are connected to each other. (Larman, section 9.14) 

11. The graphical decision of placing the model creator’s name and class inside boxes similar to the ones containing the models class names is confusing and of no immediate purpose. It’s nothing major, but should be mentioned. 

##### As a developer would the model help you and why/why not?

Yes, it gives an overview of the most important information in the model that is needed for the requirements. Although we would most likely spend a lot of time trying to decipher the crisscrossing of the associative lines and the partially covered descriptions.

##### Do you think a domain expert (for example the Secretary) would understand the model why/why not?

We think a domain expert would understand the majority of the model, although not without help. Some things would require explanation and clarifying as to what purpose they serve. 

##### Do you think the model has passed the grade 2 (passing grade) criteria?

Yes, we can understand the model, though it may need some changes.

##### References

1. Larman C., Applying UML and Patterns 3rd Ed, 2005, ISBN: 0131489062

2. Ambler, S., The Elements of UML ™ 2.0 Style, 2005, ISBN: 0521616786