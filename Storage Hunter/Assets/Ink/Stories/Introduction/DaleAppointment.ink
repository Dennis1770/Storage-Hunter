EXTERNAL activateObject(selectedObject)
EXTERNAL deactivateObject(selectedObject)

DARN IT!
Does Hannah think I'm a fool?
I didn't come al'thuway out out here for some shrink!
She said I was gonna see an expert!
Looks like I just wasted a bunch of time..
*[Excuse me, are you Dale?]->first
*[You know I can hear you, right..]->first

==first
~deactivateObject(0)
~activateObject(3)
Ughh, listen there's been a misunderstanding.
I don't need your services, mister.
I'll just be on my way..
*[Wait!]->second

==second
What do you want!?
*[I can help you!]->third
*[Who's this expert you're looking for?]->thirdAlt

==third
Sorry bud, you can't help me.
*[That's not true!]->fourth

==thirdAlt
I'm looking for someone who's experienced in fieldwork.
*[What kind of fieldwork?]->fourth

==fourth
I'm gonna stop you right there.
What I'm dealing with?
Trust me..
You don't know wanna know nothin' about it.
*[Tell me anyways.]->fifth

==fifth
Hah. Fine.
I'll only tell you because you're persistent.
A week ago I saw a monster.
It was stalking me along one of the park trails near here.
*[You saw a monster?]->sixth
*[How big was it?]->sixth

==sixth
Was a large beast with freakish eyes.
Damned thing nearly gave me a heart attack.
Luckily, Montana is open carry.
*[Oh my god.  You killed it?]->seventh
*[You're full of shit, aren't you.]->seventh

==seventh
I wish.
Anyway I shot at the damned thing but all I did was scare it off.
I've got 'low vision' you see.
Happens when you get older.
It means I'm not as good a shot as I used to be.
And that means this monster is out there putting people in danger!
That's why I'm looking for an expert, understand?
*[Yeah, I understand.] Great.
->eighth
*[Wait, how'd you drive here with impaired vision?]->eighthAlt

==eighthAlt
Don't worry about it sonny.
So anyways, if you're done being a pest..
->eighth

==eighth
I've got places to be.
Someone needs to do something about this.
Might as well be me.
*[Haven't you talked to the park rangers?] Yeah.
->ninth
*[You should go to the police!] Already did.
->ninth

==ninth
They don't believe me though.
Told me I saw a bear.
They also revoked my license to carry a firearm. What a joke.
I know what I saw.
*[I believe you.]->tenth
*[I don't believe you.]->tenth

==tenth
It don't matter to me.
All I care about is that my wife thinks I'm crazy.
She sent me here! What the hell..
You're not even a real doctor are you?
What a sick world.
*[Let me help]->eleventh


==eleventh
You want to help me?
As in 'find the monster' help me?
*[Let's show that monster who's boss!] Is that so?
Well, ->twelfth
*[As in 'find the psych ward' help you.] To be completely honest, I don't care what you think.
->twelfth

==twelfth
I'm leaving.
You can come with or stay here, it's all the same to me.
~deactivateObject(3)
~activateObject(4)
->DONE