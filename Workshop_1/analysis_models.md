## StudentId: dt222cc

## Grade 2 (passing grade)
- Analysis (Inital model):
	![first_model](http://yuml.me/f3fe770d)
- Analysis: (Final model)
	![final_model](http://yuml.me/d2f68f00)
- Note:
 - [Secretary]create[Booking]consistOf[Berth] can perhaps be changed to: [Secretary]reserve[Berth], because the berth probably have an attribute which determinate what boat/boat's owner it belongs to/reserved to.
 - Or I need to change it to [Secretay]Approves[ProposalOfAllocation]Assigns[Berth], which now makes more sense as i re-read the requirement (8 Assign Berths).
 - I opted out to not include attributes as it seemed to make stuff more cluttered for this design with yUML.