#### Peer review recieved from Roy Nilsson (rn222cx)

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