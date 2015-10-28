## Reviewed by: Sing Trinh dt222cc@student.lnu.se
- For Frida Holmström (fh222dt):
 - https://github.com/fh222dt/OOAD/tree/master/workshop%203

## Peer review
- There where no issues with compling the code and playing the game.

- There's some issues regarding that there is no pause between drawing cards. Requirement: "When the event is handled the user inteface should be redrawn to show the new hand (with the new card) and the game should be briefly paused, to make the game a bit more exciting".

- You are missing the association from the dealer class with the IWinnerRule (m_winnerRule).

- The dependency between controller and view are handled good, with enumeration.

- The strategy pattern was used correctly for both Soft17 and same score win strategy and the same design pattern that already was present was used.
 - The pattern for Equal score win strategy works but there is repeated code.
 - Consider only have the part that decides who wins if the score is the same in these strategies and the rest (score over max) in the dealer class.
 - Dealer class: dealerScore > max = loss, playerScore > max = win, else get results from the "equalScoreRule".
 - DealerWin: dealerScore >= playerScore.
 - PlayerWin: dealerScore > playerScore

- The duplication was fixed by refactoring into a new method which is a good solution.

- The observer pattern was not implemented correctly. There is a list of subscribers(observers) but they are not being used. There is no pause that are being add for each observer in that list.

- The class diagram was updated to reflect the changes but had some missing relations, that was perhaps forgotten to be added.

- If the observer pattern was implemented correctly, I believe it would pass the grade 2.

## References
1. https://coursepress.lnu.se/kurs/objektorienterad-analys-och-design-med-uml/workshops-2/workshop-3-design-using-patterns/