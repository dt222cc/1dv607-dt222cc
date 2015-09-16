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

- As a developer would the model help you and why/why not?
 - I believe that the model is helpful. It's clear, consistent and understandable. It gave me a different perspective, which is good. 
- Do you think a domain expert (for example the Secretary) would understand the model why/why not?
 - The secretary should be able to understand the model, he/she should be able to deduct what kind of responsibilities he/she have (BoatRegister & Calendar). Have you considered what kind of connection Secretary have with Berth? Like how can he/she know what berths is available? Does the BoatRegister have access to berths or is it perhaps through boats. In that case only the boats "with" a berth is registered in the BoatRegister.
- What are the strong points of the model, what do you think is really good and why?
 - As mention before, the model is pretty detailed and each association has a description that describes the associations well. The number thingy 1-1/1-* (cannot remember the term) is included+ (note: missing for Event-EventDescription).
- What are the weaknesses of the model, what do you think should be changed and why?
 - I'm not so sure about the position the description is on (above/under), it took a few moments of thinking to understand it. In this model it's counter-clockwise which is perhaps the correct way but for me, a tiny bit confusing as I tend to think in clockwise direction. In my case i didn't include them but later on I added them when i simplified my model more and yUML didnt really manage them so well :(
- Do you think the model has passed the grade 2 (passing grade) criteria?
 - The model contains the requirements that was needed for the grade so there should be no problems passing.

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

- As a developer would the model help you and why/why not?
 - I believe it was not required to add attributes for the classes but I do think it helps with the understanding of the system better, which in turn can be helpful. It made me reflect on keeping the model more simple as I missed the word "only" in the instructions... It was perhaps required to have those details, I had it in my mind but I did not commit to it. 
- Do you think a domain expert (for example the Secretary) would understand the model why/why not?
 - In a way the secretary should be able to understand the model, he/she should be able to deduct what kind of responsibilities he/she have (CalendarEvent & Berth).
- What are the strong points of the model, what do you think is really good and why?
 - Attributes for some classes are set, which gives a bit more indepth. The single/multiple thingy are being used. The model manages the requirements without being too cluttered.
- What are the weaknesses of the model, what do you think should be changed and why?
 - There could be more consistency on the model, for example the 1-1 / 1-* or the descriptions (some have and some does not have). Some associations have no description which might make the person look at the model think of what purpose that association have. It might be because of yUML now that i think of it.
- Do you think the model has passed the grade 2 (passing grade) criteria?
 - There's no reason for the model to not pass, I think. All requirements/associations are met except the #1 Authenticate and some minor descriptions for the requirements (for example Secretary-Calendar/Berth= manages/administrates).

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

------------------------------------------------------