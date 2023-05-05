It's a slow day at the office.
* [Drink coffee.] -> begin

* [Stare at the wall.] -> begin

== begin
{Someone is calling.| You don't feel like answering the phone right now.}

{*Ring ring* | *Ring ring ring*}
+[Answer the phone.] -> hannah
*[Let it ring.] -> begin


== hannah
Hi, is this Dr Montana?
+[It certainly is. How can I help you?] -> hannah2
+[Yup.] -> hannah2

== hannah2
My name's Hannah Crypt. 

I'm calling to schedule an appointment for my husband Dale?
*[When does he want to come in?] -> hannah3
*[Mhm..] -> hannah3

== hannah3
Are you available today?
* [I have an opening this afternoon actually!] -> hannah5
* [Uhhh..] -> hannah4

== hannah4
Can you hear me okay Dr. Montana?
*[Yes, I can hear you. I’ll meet with him today!] -> hannah5
*[...I can do tomorrow.] -> hannah5

== hannah5
Alright. I’ll tell Dale to come visit you soon. 

Also, do you offer couple's therapy sessions?
*[I certainly do.] That's wonderful. -> hannah6
*[Depends on your insurance.] Okay, we can discuss that another time. -> hannah6

== hannah6
Bye Dr. Montana.
*[It was wonderful speaking with you, Mrs. Crypt.] -> DONE
*[Adios!] -> DONE