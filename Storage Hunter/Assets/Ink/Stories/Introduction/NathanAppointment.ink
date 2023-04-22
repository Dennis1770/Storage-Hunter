EXTERNAL activateObject(selectedObject)
EXTERNAL deactivateObject(selectedObject)

~deactivateObject(0)
Hey doc, are you ready to see me?
*[Is this Nathan?]->first
*[Come in]->second
==first
That's me
*[Excellent, come in]->second
== second
~activateObject(2)
Hey doc, I wanted to ask you some questions to get your opinion.
*[Go ahead]->third
*[What's up?]->third
==third
I can't really put it in words. 

I guess I'll just ask, is it normal to feel haunted?
*[Haunted?]->fifth
*[Sounds normal to me]->fourth
==fourth
I'm not joking around. It's eerie.
*[Tell me more]->sixth
*[Are you safe?]->fifth
==fifth
I don't really know. 

It's just.. I've been feeling haunted. 

I can't explain it.
*[Did something happen?]->sixth
*[Are you actually being haunted]->sixth
==sixth
I don't know. I've just been getting this feeling. 

It's like when someone's eyes are on you.  

I don't know what's causing it.
*[Does this make you anxious?]->seventh
==seventh
Yeah, it makes me anxious.
*[Do you think someone is actually watching you?]->eighth
==eighth
Well, I've never seen anyone doing it.  

But that doesn't change how it makes me feel!
*[Do you feel watched even now?]->ninth
*[What about in the bathroom? Do you feel watched there too?]->ninthAlt
==ninth
Yeah, a little.
*[It's possible that this goes back to early childhood]->tenth
*[That's not good..] ->ninthAlt
==ninthAlt
Yeah.. wait what?
*[Nevermind.. tell me about your parents]->tenthAlt
==tenth
Like when I was a toddler?
*[Maybe. What were your parents like?]->eleventh
==tenthAlt
There's not much to say. 

They were pretty normal.
*[Tell me about them]->eleventh
*[Were they overprotective?]->eleventh
==eleventh
I guess you could say that my mom was a little overprotective. 

She rarely let me go outside alone.

She worried a lot about me getting kidnapped, or run over.. stuff like that.
*[Tell me more]->twelfth
*[What about your dad?]->twelfthAlt
==twelfth
Yeah, growing up it was mostly just me and my mom. 

What does this have to do with me being haunted though?
*[I think it's unlikely that you're actually being haunted]->thirteenth
*[Many disorders can be traced back to early childhood]->thirteenth
==twelfthAlt
He wasn't around much.
*[You didn’t spend a lot of time with your dad?]->twelfth
==thirteenth
I agree, but I still don't know what's wrong with me.
*[Nothing is wrong with you]->fourteenth
*[Have you been using any strange drugs?]->fourteenthAlt
==fourteenth
Well, something's wrong.
*[Nathan, nothing is wrong]->fifteenth
==fourteenthAlt
Of course not!  

The only drugs I take are prescribed!
*[Okay, that's good]->fifteenth
*[If you say so..]-> fifteenth
==fifteenth
So what should I do?
*[I think you should start a journal. Whenever you feel nervous, write down what is causing you to feel that way]->sixteenth
*[Why would someone be watching you? Your fear isn't rational, just try to relax]->sixteenthAlt
==sixteenth
Ok doc, I'll try the journal. 

I'm not sure how it's going to help me though..
*[Just give it a try. We can talk about whatever you write down next week]->seventeenth
==sixteenthAlt
I don’t think you understand what I’m going through right now. 

How am I supposed to just relax?
*[I’m sorry Nathan, but we’re out of time. Why don’t you come back next week?]->seventeenthAlt
*[Here’s my best advice. Write down whatever causes you to feel haunted and we can talk about it next week.]->seventeenth
==seventeenth
Okay doc, see you next week.
*[Bye Nathan]
~deactivateObject(2)
->DONE
*[See you then]
~deactivateObject(2)
->DONE
==seventeenthAlt
I'm still feeling really stressed..

But I'll see you next week doc, hopefully I can explain it better then.
*[Bye Nathan]
~deactivateObject(2)
->DONE
*[See you next week]
~deactivateObject(2)
->DONE
