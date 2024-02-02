# CardGamesCSharp
This project is an extendable platform to create card games in the console. I've programmed all of this project in C# and I plan on adding new card games to this project in the future. Some other future ideas for extensibility that I am thinking about are: creating a website, or a desktop app with a GUI. Right now, this program only has Blackjack implemented. The code for Blackjack is fully documented using Doxygen and can be found [here](https://github.com/AdamKvant/CardGamesCSharp/tree/main/CardGamesCSharp/docs).

## Blackjack
At this time, Blackjack is the only game fully implemented inside of CardGamesCSharp. To play Blackjack, run the **CardGamesCSharp.exe** and follow the prompts on screen. Initially, the user will need to type 0 into the console to select Blackjack. Then the on screen prompts will ask the user how many players they would like to have in the game. After inputting the initial information into the console, the game will commence. Every player will be asked to either "hit" (type 0) or "stay" (type 1) on their hand. More rules about Blackjack can be found [here](https://en.wikipedia.org/wiki/Blackjack) on Wikipedia.
## Documentation
As mentioned above, the code is fully documented in Doxygen and can be found [here]. The code also has many other comments inside it to provide an easy understanding of what is going on. I have also created a UML class diagram for the current version (Beta-1.0).

![UML clas diagram of current release](https://github.com/AdamKvant/CardGamesCSharp/blob/main/CardGamesCSharp/images/C%23%20CardGames.png)

## Changelog
Version Beta-1.0: Core Blackjack functionality created, alongside the extendable CardGames platform.
