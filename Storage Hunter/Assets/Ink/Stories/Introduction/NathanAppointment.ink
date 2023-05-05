EXTERNAL activateObject(selectedObject)
EXTERNAL deactivateObject(selectedObject)

~deactivateObject(0)
Hey doc, are you ready to see me?
*[Is this Nathan?]->first
*[Come in.]->second
==first
That's me.
*[Excellent, come in.]->second
== second
~activateObject(2)
Hey doc, I wanted to ask you some questions to get your opinion.
*[Go ahead.]->third
*[What's up?]->third
==third
I can't really put it in words. 

I guess I'll just ask, is it normal to feel haunted?
*[Haunted?]->fifth
*[Sounds normal to me.]->fourth
==fourth
I'm not joking around. It's eerie.
*[Tell me more.]->sixth
*[Are you safe?]->fifth
==fifth
I don't really know. 

It's just.. a feeling I get sometimes.

Like someone's got their eyes on me.
*[Did something happen?]->sixth
*[Are you actually being haunted..?]->sixth
==sixth
No.
Atleast, I don't think so.
Look, it's not like I believe in the supernatural or anything.
But something's been off recently..

*[Does this make you anxious?]->seventh
==seventh
Yeah, it does.
*[Do you think someone is actually watching you?]->eighth
==eighth
Well, I've never caught anyone watching me.

*[Do you feel watched even now?]->ninth
*[What about in the bathroom? Do you feel watched there too?]->ninthAlt
==ninth
Yeah, a little.
*[It's possible that this goes back to early childhood.]->tenth
*[That's not good..] ->ninthAlt
==ninthAlt
Yeah.. wait what?
*[Nevermind.. tell me about your parents.]->tenthAlt
==tenth
Like when I was a toddler?
*[Maybe. What were your parents like?]->eleventh
==tenthAlt
There's not much to say. 

They were pretty normal.
*[Tell me about them.]->eleventh
*[Were they overprotective?]->eleventh
==eleventh
I guess you could say that my mom was a little overprotective. 

She rarely let me go outside alone.

She worried a lot about me getting kidnapped, or run over.. stuff like that.

She's a really nice person though. I don't visit her as much as I should.

*[Tell me more.]->twelfth
*[What about your dad?]->twelfthAlt
==twelfth
Yeah, growing up it was mostly just me and my mom.

She was always really into knitting.

She used to make me a new pair of mittens every winter.

Actually she sent me a pair last year too..

What does this have to do with me being haunted though?

*[I think it's unlikely that you're actually being haunted.]->thirteenth
*[Many disorders can be traced back to early childhood.] ->thirteenthAlt
==twelfthAlt
He wasn't around much.
*[You didn’t spend a lot of time with your dad?]->twelfth
==thirteenth
I agree, but I still don't know what's wrong with me.
*[Nothing is wrong with you.]->fourteenth
*[Have you been using any strange drugs?]->fourteenthAlt

==thirteenthAlt
But I don't think I have a disorder.. atleast, not one from childhood.
*[That's what I think too.]->fifteenth
*[Well, have you been using any strange drugs?]->fourteenthAlt

==fourteenth
Well, something's wrong.
*[Nathan, nothing is wrong.]->fifteenth
==fourteenthAlt
Of course not!  

The only drugs I take are prescribed!
*[Okay, that's good.]->fifteenth
*[If you say so..]-> fifteenth
==fifteenth
So what should I do?
*[I think you should start a journal.]->sixteenth
*[Just don't think about it so much.]->sixteenthAlt

==sixteenth
How is a journal going to help me?
*[ Whenever you feel nervous, write down what is causing you to feel that way.]-> eighteenth
*[Just give it a try. We can talk about whatever you write down next week.] ->eighteenth

==sixteenthAlt
What? What does that mean?

Are you saying that I should just pretend I don't feel watched?
*[You said it's not real. Why overeact?]->seventeenthAlt
*[Mhm.] ->seventeenthAlt

==seventeenthAlt
What kind of advice are you giving me?

My brain! 

Thinks I'm in danger!

I can't just ignore that feeling!

Is there really nothing else I can do!?

*[You could try writing in a journal.] -> eighteenth
*[It's an interesting predicament.] ->eighteenthAlt

==eighteenth
Well, I guess I'll try that.

I'd rather do something than nothing.

Hopefully I can better explain how I feel next week..

Bye Doc.
*[Bye Nathan.]
~deactivateObject(2)
 -> DONE
 *[See ya Nate.]
~deactivateObject(2)
 -> DONE

==eighteenthAlt
GAAAH!  

This feels terrible.

Sorry for the outburst doc, but I don't think you've helped me much today.
*[It's fine Nathan.] -> nineteenth
*[Yikes. Just take it easy, okay?] ->nineteenth

==nineteenth
I just wanted to know why my brain is doing this to me.

I'll see you next week.

Bye.
~deactivateObject(2)
->DONE
