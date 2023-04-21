Not many psychologists practice in rural areas.

That's why you always do your best to help your clients.

Small towns need licensed therapists as much as anywhere else does! 

You’ve got a few appointments today so don’t slack off.
*[Start the day]-> start

== start
You hear a knock on the door.
*[Please, come in] -> fourth
*[Who's there?] -> first

== first
Good morning Dr. Montana. I'm here for my appointment.
*[Come on in] -> fourth
*[Who are you again?] -> second

== second
It's Sarah. I had an appointment with you last week. Can I come in?
*[Yes, of course! Come in Sarah] -> fourth
*[Give me a few minutes. I'll call you in when I'm ready.] -> third

== third
{Um, okay | }
*[Call Sarah in] -> fourth
*[Clear off desk] Your desk is nice and clean. -> third
*[Check the news] You read the local paper.  There's not much going on -> third
*[Stare at the ceiling] You should probably call Sarah in soon. -> third
== fourth
Hey Dr. Montana.
*[Good morning. How're you feeling today?] -> fifth

== fifth
I don't know. I'm kinda tired.
*[Have you been getting enough sleep?]  -> sixth
*[That’s unfortunate] -> sixth

== sixth
I've been really stressed recently.
*[What's causing you to feel this way?] -> seventh
*[It’s important to get enough sleep] -> seventh

== seventh
I have a midterm exam next week. Normally I'm confident but this class is really difficult.
*[It sounds like you've been working hard] -> eighth
*[Are you worried?] -> eighth

== eighth
I just don't think I'm ready for this exam and I’m afraid of letting the class harm my gpa.
*[How would doing well make you feel?] -> ninth
*[So, what happens if you don't do well on the exam?] ->tenth

== ninth
I'd feel relieved.
*[Let's come up with a goal to help you succeed] -> eleventh
*[That's great. Let's talk about some ways we can deal with stress] ->eleventh

== tenth
I'd be angry with myself.
*[Let's come up with a solution so that doesn't happen] -> eleventh
*[It’s okay to be angry. Let’s try something..] -> eleventh

== eleventh
Okay Dr. Montana, I'm listening.
*[I think you need to invest some more time into your mental health] ->twelfth
*[You should acknowledge that you can only give this midterm your best effort] ->twelfth

== twelfth
But the midterm is all I can think about! I can’t allow myself to get a bad grade by doing something else.
*[Okay, tell me more about why you feel that way] -> thirteenth

== thirteenth
The truth is that I’m not a very good student. I have to spend a lot of time studying in order to get the results I want.  And I’m always studying because that’s what I need to do to maintain my grades. 
*[You've invested a lot of time into your academics. I think that's making this exam more stressful for you] -> fourteenth
*[It's okay not to have perfect grades...] ->fifteenth

==fourteenth
I guess the stress is more likely to harm my grade than help though, right? If I’m unable to focus because I’m not stressed it could put all my effort to waste..
*[That's true] -> sixteenth
*[Let's talk about ways to reduce your stress] -> sixteenth

== fifteenth
No, it’s important to me. Besides you went to medical school right?  How were your grades?
*[I got a few A's...] -> sixteenth
*[Let's not talk about that] -> sixteenth

== sixteenth
Mhm. So what should I do?
*[Do whatever makes you feel better] -> seventeenth
*[Listen to some music, spend some time with friends, go to bed an hour early, you decide] -> seventeenth

== seventeenth
I'm still worried about this exam though.
*[Let's do some breathing exercises. Next time you feel stressed out, I want you to use them] -> eighteenth

== eighteenth
Okay, I'll try it.
*[Breathe in] -> nineteenth

==nineteenth
*[Breathe out] -> twentieth

==twentieth
Okay, but I'm still a littled stressed.
*[Don't think about your exam. Just focus on your breathing. How do you feel?] -> twentyfirst

==twentyfirst
I feel a little better.
*[It's important to slow down and breathe, especially when things get stressful] -> twentysecond

==twentysecond
Thanks Dr. Montana. I'll remember that.
*[Looks like we're out of time] -> twentythird
*[Let's end this session here] -> twentythird

== twentythird
Okay, bye Dr. Montana.
*[Good luck on your exam!] ->END
*[Take it easy Sarah] -> END
