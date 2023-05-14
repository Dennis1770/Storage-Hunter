Oh, hi.
 * [Nice afternoon for a run.]-> Fitness
 * [Did you see the police officer?]-> Details
    
    = Goodbye
I'm gonna finish my run. 

Bye.->END

== Details
Police officer?
*[I think he's investigating a missing child.]
-> TheCrime
*[It's probably nothing.]
Yeah, I don't want to get involved.
-> Goodbye


== Fitness
Yeah, it is.
*[Did you see the police officer?]->Details
*[Have you seen anything unusual?] ->Toy

==Toy
Are you looking for your kid's toy?
*[Yeah, my daughter dropped something.] Ok, I can help you. 
I saw a small toy next to the slide.
->Goodbye
*[No, that's not what I meant.] 
Sorry, I don't understand what you're looking for.
->Goodbye

==TheCrime
Oh, I didn't know a kid was missing.
I'm sorry to hear that.
*[I'm hoping to find out more info.]
Sorry but I don't know anything.
->Goodbye