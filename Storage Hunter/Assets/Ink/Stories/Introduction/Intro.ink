It's a slow day at the office.
* [Drink coffee] -> begin
    Someone is calling the office.

* [Stare at the wall] -> begin
    Someone is calling the office.

== begin
Ring ring.
+[Answer] -> hannah
*[Let it ring] You don't feel like answering the phone right now. -> annoying

== annoying
Ring. Wow, that's annoying.
-> begin

== hannah
"Hi, is this Dr Montana?"
+["It certainly is. How can I help you?"] -> hannah2
+["Yup."] -> hannah2

== hannah2
My name's Hannah Crypt. I'm calling to schedule an appointment for my husband Dale?
*["Sure thing. When would you like to have him come in?"] -> hannah3
*["Mhm."] -> hannah3

== hannah3
Are you available today or tomorrow?
* [“I have an opening tomorrow afternoon if you can believe it”] -> hannah5
* [“Uhhh…”] -> hannah4

== hannah4
Can you hear me okay Dr. Montana?
*[“Yes, I can hear you. I’ll meet with him tomorrow.”] -> hannah5
*[“...I can do tomorrow.”] -> hannah5

== hannah5
Alright. I’ll tell Dale to be at your office early tomorrow. And do you do group sessions?
*["I certainly do. I find it helpful to first meet everyone individually though.”] That's wonderful. -> hannah6
*["Depends on your insurance.”] Okay, we can discuss that another time. -> hannah6

== hannah6
Bye Dr. Montana.
*[“It was wonderful speaking with you, Mrs. Crypt.”] -> end
*[“Adios.”] -> end

== end
That went well. I think I'll call it a day soon.->END