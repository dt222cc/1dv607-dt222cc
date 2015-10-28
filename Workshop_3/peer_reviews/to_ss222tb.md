## Reviewed by: Sing Trinh dt222cc@student.lnu.se
- For Sebastian Svensson (ss222tb):
 - https://github.com/sslnustudent/blackjack_csharp

## Peer review
- There where no issues with compling the code and playing the game.

- There's some issues regarding the pause between drawing cards.
 - Requirement: "When the event is handled the user inteface should be redrawn to show the new hand (with the new card) and the game should be briefly paused, to make the game a bit more exciting".
 - My impression was that there should be a delay between cards from start to end and not from just the Hit and Stand. Else it works as intended. There is a delay but perhaps not implemented the intended way. It isnt really "exciting" but feels more sluggish (feedback from input is either fast or slow).

- You are missing the association from the dealer class with the IWinnerStrategy (m_winRule), look at the other two Strategies. Other than that, they seem to show the same thing.

- The dependency between controller and view could be handled better.
    - There is duplication, SimpleView and SwedishView both has the same GetInput() method.
    - Instead of if statements a switch statement could/would look better.
    - Else it was handled well, with enumeration.

- The strategy pattern was used correctly for Soft17 and the same design pattern that was already present was used.
 - The pattern for Equal score win strategy works and used the same design pattern but there is repeated code.
 - Only have the part that decides who wins if the score is the same and the rest in the dealer class.
 - Dealer class: dealerScore > max = loss, playerScore > max = win, else get results from the "equalScoreRule".
 - DealerWin: dealerScore >= playerScore.
 - PlayerWin: dealerScore > playerScore

- The duplication regarding picking a card, showing a card and then dealing a card was not fixed. 7th requirement.

- I'm not sure if the observer pattern was implemented correctly or not, similar but different.
 - The RegisterSubscriber() are put in the hit/stand procedures in the PlayGame controller, I only used one register in the constructor with no remove. I'm not necessaet confident if I implemented it correctly or not so i'll put this statement on hold.
 - As mentioned before the pause only pause when hitting Hit or Stand which means that there is only delays from hit and stand and not play. With my app we can see that first cards are being delt. There's also a delay between flipping the hidden card and the third card.
 - Took some experimentation to get that working for me.

- The class diagram was updated to reflect the changes but had a missing relation, that was perhaps forgotten to be added.

- If the observer pattern was implemented correctly, I believe it would pass the grade 2. It seems that many of us students have some difficulties regarding this pattern, including me.

## References
1. https://coursepress.lnu.se/kurs/objektorienterad-analys-och-design-med-uml/workshops-2/workshop-3-design-using-patterns/