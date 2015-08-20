# AutoClose

A Windows application that aids in protecting the privacy of the user when the system comes out of a sleep state.

## Overview

I decided to put this application together after reading a number of posts from Reddit users.  They had been using their College / Work laptops at night and either the battery had run out, the laptop had gone to sleep due to power settings or the lid had been closed.  Any applications open at the time would be put to sleep also, to then be restored in all their glory when the laptop resumed the next day.

### Example

Bob is a Brony but his work colleagues do not know.  He is also a fan of One Direction, his colleagues do not know this either.  One Tuesday night while trying to get to sleep, after a particularly stressful day, Bob decides to listen to some One D and google some My Little Pony artwork.  His trick works, and he falls asleep within 20 minutes, with the laptop still running.  After an hour, the laptop battery gets critically low and goes into a sleep state, all while Bob is blissfully unaware.  When Bob wakes up, he performs his usual morning rituals, puts his laptop in his bag and heads off to work.
Bob has a meeting first thing and is to be showing a PowerPoint presentation he created the day before.  He gets into the office, enters the meeting room, which is already quite busy, connects his laptop to the projector and plugs in the power.  This is where things take a turn for the worse, firstly the second the laptop comes out of its sleep state and shows the Windows login screen, One Direction resumes playing through the speakers, at full volume.  Bob quickly presses the hardware mute button, unfortunately everyone noticed and now Bob has their full attention.  He then logs into Windows to be greeted with My Little Pony artwork all over the screen.  Fail.

## Features

AutoClose has several features that are designed to prevent any embarrassing situations from occurring.  Although it is not infallible, these features should prevent this kind of incident from every happening to you.

###Muting of all audio devices
All audio devices will be muted to prevent any noises coming from running applications.

###Minimising of all open windows
All windows are minimised so that they are not in full view all over the screen.

###Top-most privacy shield
A full-screen *black-out* window is displayed that prevents any user from seeing what was open, although they should be minimised at this point if the previous feature is enabled.  There is a single button that will close the window, revealing the desktop.  All active screens at the time the system went to sleep should be covered.

##How It Works
At current AutoClose works by detecting power state changes on the primary display.  This appears to be the most reliable technique, as opposed to responding to system events that are raised when the system goes to sleep.  The Surface Pro 3 for example will not raise the sleep event message instantly but sometime later, due to “advanced power management techniques”… i.e. a bug.  The current method covers pressing the power button once, closing the type cover, and also the system going to sleep due to a critical battery.

*Please note that I have not tested this on many devices, so please test it yourself prior to attempting to rely on it*

##Installation

You can grab the latest installer from the following URL,

https://s3-eu-west-1.amazonaws.com/devoctomy/installers/AutoClose/AutoCloseSetup.exe  

##Compilation

The application was created using Visual Studio 2015, and the installer was created using Inno Setup.

The community edition of Visual Studio can be obtained for free from the following page,

https://www.visualstudio.com/en-us/downloads/download-visual-studio-vs.aspx

Inno Setup can be obtained for free from the following page,

http://www.jrsoftware.org/isinfo.php


