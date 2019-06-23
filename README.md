**The GreenLuma Reborn App project was moved from [GitLab](https://gitlab.com/linkthehylian/glrapp) to [GitHub](https://github.com/linkthehylian/GreenLuma-Reborn-App). If you wish to download an older version of GLRApp. Please go [here](https://gitlab.com/linkthehylian/glrapp/tags) as the older releases will not be uploaded to GitHub.**

# GreenLuma Reborn App
An app specifically designed for the Steam unlocker: "GreenLuma Reborn".

# Latest update: **[GreenLuma Reborn 1.7.2](https://cs.rin.ru/forum/viewtopic.php?f=29&t=80797)**

To make things easier, I'll keep the download link updated for anyone who wants the latest version of GLR.

[Download GreenLuma Reborn 1.7.2](https://www40.zippyshare.com/v/gvpHWwto/file.html)

The "DllInjector.ini" in the download link has already been modified by me to automatically include NoHook mode. Just follow the [installation instructions](https://github.com/linkthehylian/GreenLuma-Reborn-App#can-i-get-banned-for-using-greenluma-reborn-) and skip step three and four. **Do not** edit it.

![alt text](https://i.imgur.com/UfuGncl.png)

[cs.rin.ru](https://cs.rin.ru/forum/) Status: Its official domain is back up. Enjoy yourselves.

# What is the GreenLuma Reborn App ?
GreenLuma Reborn App (GLRApp) is an app specifically designed for the Steam unlocker known as "GreenLuma Reborn".

*GLRApp v2.1*

![alt text](https://i.imgur.com/wHcDyKp.png)

# What is GreenLuma Reborn ?
GreenLuma Reborn (GLR) is a Steam unlocker made by [Steam006](https://cs.rin.ru/forum/memberlist.php?mode=viewprofile&u=415627) that is used to obtain games from family shared libraries and DLC for games. There's much more to it, though.

The full list of features provided by Steam006.

![alt text](https://i.imgur.com/D18pz0f.png)

# Can I get banned for using GreenLuma Reborn ?
There will always be a risk when using GLR. If you're willing to take that risk, go right on ahead. If not, then don't bother. Especially when that risk means the status of your Steam account.

As expected, there are some games that blacklist GLR and using it will result in receiving a game ban. Refer to [this page](https://github.com/linkthehylian/GreenLuma-Reborn-App/wiki/Blacklist) if you want to check what games NOT to play.

Please keep in mind. Like CreamAPI, GreenLuma Reborn **does not** work for every game.

Also, keep in mind that not **every game** is available to play through Steam family sharing.

I **highly advise** you to follow the "Legit stealth mode" installation instructions if you do plan on using GreenLuma Reborn.

![alt text](https://i.imgur.com/6SAlxad.png)

# Is GreenLuma Reborn considered a "crack" for Steam ?
This is a question I get asked *a lot*.

No, and it hasn't been since it was first released. These two statements by the moderator on cs.rin known as "[Christsnatcher](https://cs.rin.ru/forum/memberlist.php?mode=viewprofile&u=501706)" should give you a better understanding of what it does.
> GLR is no "Crack" at all, but an unlocker, which works as follows: All packages subscribed to your account are referenced in appcache\packageinfo.vdf. I assume the SteamCrack you speak of refers to the hex modification of exactly that file. Now in 2014, Shlak and Mamooun found out that you can add app- and depotIDs of non-owned apps to an owned sub, making steam think you would own them too. Those were the days of packageinfopatcher and SFSFix. GLR now hooks steamclient.dll on load (and since it does that via kernel .dlls it needs admin rights, not because of the game location somewhere on C:), intercepts the packageinfo screening and injects the added appIDs into memory, basically the same principle used since 5 years.

> GLR does not alter any kind of physical data which of course is a huge advantage, but on the other hand it leaves a memory footprint that de facto can't be hidden effectively. I mean, even if you use it in "Stealth Mode", only the game memory stays untouched, while the memory of the steam client remains significantly altered over the entire time you use the loader, simply because an entire custom 100+ KB .dll is kept actively loaded in steam's memory while being hooked at steamclient.dll. And exactly that's the point why dozens or even hundreds of games do NOT work with GLR at all, e.g. the last four CoD titles in online mode, Arma 3 DLC, PAYDAY 2. basically all Valve games and most of the Denuvo- or Arxan-protected titles. And all these games detect the exploit aside all their highly sophisticated kernel checks by simple scanning not the memory of the game in question, but the one of the steam client

# Is GreenLuma Reborn better than SteamCrack and CreamAPI ?
~~My personal opinion ? Yes, TONS better.~~

GLR is still a very unique tool because of what it's able to do, especially the unintended feature of bypassing family sharing restrictions. But I hardly ever use it anymore unless I actually plan on playing a game from a friend's library.

[SteamCrack](https://www.mpgh.net/forum/showthread.php?t=1383930) works like GreenLuma Reborn from what I've heard. Unfortunately, it requires you to downgrade your Steam client, not to mention it's incredibly unstable and it will crash Steam completely if someone messages you.

[CreamAPI](https://cs.rin.ru/forum/viewtopic.php?f=29&t=70576) is a DLC unlocker for legitimately owned Steam games. Everything is done through a .ini file since the Steam API is modified. I use CreamAPI for some single player games and others. Although, it doesn't work for [*every*](https://docs.google.com/spreadsheets/d/1sVNjbkzGFsfeszDx-psLTm7Qe67nvEh2vlWpUPGnYdA/edit#gid=0) game.

# What can I do with your app ?
You can:

*  Link your Steam folder to add new app IDs.
*  Keep track of your app IDs with their own descriptions.
*  Effortlessly remember the last app ID you added. (*The app does it automatically.*)
*  Simultaneously add/edit both your app IDs along with their descriptions.
*  Allows you to delete any app ID's text file along with its description.

# Where can I download your app ?
All stable releases can be found [here](https://github.com/linkthehylian/GreenLuma-Reborn-App/releases/latest).

# Any viruses/malware ?
I can assure you it is 100% [virus free](https://www.virustotal.com/#/file/5d12065235e836b313c2009df0af8ad83ced7c4db958d46ca33a18d1d06b7b02/detection).

# Why does the program automatically have Administrative privileges ?
In order for literally any program to access or modify files in Program Files/Program Files (x86). Administrative privileges are required.

# Will more features be added soon ?
Most definitely, I'm just adding what I think is necessary at the moment. If you have any suggestions or if you need any help you can contact me.

Discord:

![alt text](https://i.imgur.com/5W8AUVS.png)
