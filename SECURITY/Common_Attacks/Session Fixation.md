#SECURITY 

# Session Fixation

Session fixation is a session attack patten that attacks over how a web application creates and manages the user session IDs. 

Session Fixation is when an attacker chooses or knows a session ID and tricks the victim client into logging to the application so when it authenticates, the attacker can use the ID to act as the victim. 

As a resume, attacker sets the ID first, victim later authenticates with that ID so attacker can use it. 