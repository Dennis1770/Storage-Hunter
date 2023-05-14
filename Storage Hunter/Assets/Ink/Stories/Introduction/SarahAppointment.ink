EXTERNAL activateObject(selectedObject)
EXTERNAL deactivateObject(selectedObject)

Not many psychologists practice in rural areas.

That's why you always do your best to help your clients!

Small towns need licensed therapists as much as anywhere else does.

You’ve got a few appointments today so don’t slack off.

*[Start the day]
-> start

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
*[Yes, of course! Come in Sarah.] 
->fourth
*[Give me a few minutes. I'll call you in when I'm ready.] -> third

== third
{Um, okay.. | }
*[Clear off desk.] Your desk is nice and clean. ->third
*[Check the news.] You read the local paper.  Apparently a hiker went missing last week. -> third
*[Stare at the ceiling.] You should probably call Sarah in soon. -> third
*[Call Sarah in.] 
->fourth
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
*[So what's going on?] -> seventh

== seventh
I have a midterm exam next week and it's stressing me out. 

The class is really difficult... I don't think I'm going to do well.
*[So you're worried?] I am. -> eighth

== eighth
*[Why do you want to do well on this exam?] -> ninth
*[How would failing make you feel?] ->tenth

== ninth
I want to get a good job after school.

That means having good grades, good recommendations, good everything.

But the problem is that I know I'm not going to do well.

*[Let's talk about dealing with stress.] ->eleventh

== tenth
Failing would be terrible!

I'd be angry with myself.

I've worked hard to maintain my grades!

I can't let myself throw that away.
*[I think I know how to help.] -> eleventh

== eleventh
Okay Dr. Montana, I'm listening.
*[You should focus on your mental health.] I know that mental health is important...
But my->twelfth
*[You should study more.] That's what I've been trying to do...
My->twelfth

== twelfth
grades are super important!

I can’t allow myself to get a bad grade.

I'm willing to sacrifice sleep in order to study as much as possible.

*[You shouldn't do that...] 
It's not like I have a choice!
-> thirteenth
*[I admire your willpower.] 
It's what I need to do.
-> thirteenth

== thirteenth

I’m not a very good student.

I can't memorize things quickly...

And I have to spend a lot of time studying concepts before I understand them.

So I need to study a lot.

I don't have a choice, I'd fail otherwise.

*[You do have a choice.] -> fourteenth
*[It's okay not to have perfect grades...] ->fifteenth

==fourteenth
Do I really?

It feels like I never have enough time.

That's why I've only been sleeping four or five hours each night.

But sometimes I can't focus because I'm so tired.

I fell asleep in class yesterday..

It was really embarrassing.

But can I afford to take the time to sleep a full eight hours?

*[Getting more sleep will help you study.] You just -> sixteenth
*[My professional opinion? You should go home and take a nap.] -> twentyThirdAlt

== fifteenth
No, grades are important to me. 

Besides you went to medical school right?  

How were your grades?
*[I got a few A's...] Okay, so what? You just -> sixteenth
*[Let's not talk about that.] Okay, so what? You just -> sixteenth

== sixteenth
want me to sleep more?
*[I do.] -> seventeenth

== seventeenth
I'm still worried about this exam though.
*[Let's do some breathing exercises.] -> eighteenth

== eighteenth
Okay, I'll try the exercise.
*[Breathe in..] *inhales*-> nineteenth

==nineteenth
*[Breathe out..] *exhales*
-> twentieth

==twentieth
I'm still stressed.

But I think I understand.

Taking care of myself is important.

*[Did the breathing help?] -> twentyfirst

==twentyfirst
It helped a little.
*[It's important to slow down and breathe, especially when things get stressful.] -> twentysecond

==twentysecond
Thanks Dr. Montana.
*[Let's end this session here.] -> twentythird
*[Looks like we're out of time.] -> twentythird

== twentythird
Okay, bye Dr. Montana.
*[Good luck on your exam!]
~ deactivateObject(1)
~ activateObject(0)
->DONE
*[Get some sleep, okay!]
~ deactivateObject(1)
~ activateObject(0)
->DONE

==twentyThirdAlt
Yeah, maybe you're right.  I feel terrible.
Bye Dr. Montana.

*[Good luck on your exam!]
~ deactivateObject(1)
~ activateObject(0)
->DONE
*[Take it easy Sarah.] 
~ deactivateObject(1)
~ activateObject(0)
->DONE