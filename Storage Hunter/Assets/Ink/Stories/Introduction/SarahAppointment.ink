EXTERNAL activateObject(selectedObject)
EXTERNAL deactivateObject(selectedObject)

Not many psychologists practice in rural areas.

That's why you always do your best to help your clients!

Small towns need licensed therapists as much as anywhere else does.

You’ve got a few appointments today so don’t slack off.

*[Start the day]-> start

== start
You hear a knock on the door.
*[Please, come in.] 
-> fourth
*[Who's there?] -> first

== first
I'm here for my appointment.
*[Come on in.] 
-> fourth
*[Who are you again?] -> second

== second
It's Sarah. 

I had an appointment with you last week.

Can I come in?
*[Yes, of course! Come in Sarah.] -> fourth
*[Give me a few minutes. I'll call you in when I'm ready.] -> third

== third
{Um, okay.. | }
*[Clear off desk.] Your desk is nice and clean. -> third
*[Check the news.] You read the local paper.  Apparently a hiker went missing last week. -> third
*[Stare at the ceiling.] You should probably call Sarah in soon. -> third
*[Call Sarah in.] -> fourth
== fourth
~deactivateObject(0)
~activateObject(1)
Hey Dr. Montana.
*[Good morning. How're you feeling today?] -> fifth

== fifth
I don't know. I'm kinda tired.
*[Have you been getting enough sleep?] No, I haven't. -> sixth
*[That’s unfortunate.] Yeah, it is. -> sixth

== sixth
*[What's causing you to feel stressed?] -> seventh

== seventh
I have a midterm exam next week. 

The class is really difficult and I don't think I'm going to do well.
*[It sounds like you're a good student.] That doesn't mean I'm going to do well on this test. -> eighth
*[Are you worried?] I am. -> eighth

== eighth
*[How would failing make you feel?] ->tenth
*[How would getting an A make you feel?] -> ninth

== ninth
I'd feel relieved.

This exam has been stressing me out for a whole week.

I don't want to think about it, but I can't NOT think about it.

Do you know what I mean Dr. Montana?
*[Let's come up with a goal to help you succeed.] -> eleventh
*[Let's talk about some ways we can deal with stress.] ->eleventh

== tenth
I'd feel terrible!

And I'd be angry.

I've worked hard to maintain my GPA.

I can't just throw that away.
*[I think I know how to help.] -> eleventh

== eleventh
Okay Dr. Montana, I'm listening.
*[Your mental health is very important.] ->twelfth
*[Give the exam your best effort..] ->twelfth

== twelfth
I'm not so sure Dr. Montana.

I know that mental health is important.

But my grades are super important!

I can’t allow myself to get a bad grade.

Even if it means sacrificing a little sleep to study more.

*[You shouldn't sacrifice your sleep!] -> thirteenth
*[You should study less.] -> thirteenth

== thirteenth
I’m not a very good student Dr. Montana. 

I have to spend a lot of time studying!

I'm not like other kids, who can just memorize things and do well.

Studying hard is the only way for me to maintain my grades!

*[You can do both.] -> fourteenth
*[It's okay not to have perfect grades...] ->fifteenth

==fourteenth
Can I really?

It feels like I never have enough time to do everything I want to do.

That's why I've been sleeping only four hours each night.

But I guess that might be harming me too.

Sometimes I can't focus because I'm so tired.

And I fell asleep in class yesterday..

That was really embarrassing.

So maybe I should start taking better care of my health.

*[That's great to hear Sarah!] -> sixteenth
*[Maybe you should go home and take a nap, you don't look so good.] -> twentyThirdAlt

== fifteenth
No, it’s important to me. 

Besides you went to medical school right?  

How were your grades?
*[I got a few A's...] -> sixteenth
*[Let's not talk about that.] -> sixteenth

== sixteenth
Mhm. So what should I do?
*[Do whatever makes you feel better.] -> seventeenth
*[Sleep.] -> seventeenth

== seventeenth
I'm still worried about this exam though.
*[Let's do some breathing exercises. Next time you feel stressed out, I want you to use them.] -> eighteenth

== eighteenth
Okay, I'll try it.
*[Breathe in..] -> nineteenth

==nineteenth
*[Breathe out..] -> twentieth

==twentieth
I'm still stressed.

But I think I understand.

Taking care of myself is just as important as taking care of this exam.

*[Don't think about your exam. Just focus on your breathing. How do you feel?] -> twentyfirst

==twentyfirst
I feel a little better.
*[It's important to slow down and breathe, especially when things get stressful.] -> twentysecond

==twentysecond
Thanks Dr. Montana.
*[Let's end this session here.] -> twentythird
*[Looks like we're out of time.] -> twentythird

== twentythird
Okay, bye Dr. Montana.
~ deactivateObject(1)
*[Good luck on your exam!]
~ activateObject(0)
->DONE
*[Get some sleep, okay!] 
~ activateObject(0)
->DONE

==twentyThirdAlt
Yeah, maybe you're right.  I feel terrible.

Bye Dr. Montana.
~ deactivateObject(1)
*[Good luck on your exam!]
~ activateObject(0)
->DONE
*[Take it easy Sarah.] 
~ activateObject(0)
->DONE