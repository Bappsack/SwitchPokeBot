# SwitchPokeBot
a Bot for Pokémon Sword and Shield on Nintendo Switch



## Current supported:

### Suprice Trade Bot

- Trade multiple Boxes in Box order.
- Start from a specific Slot.
- Reconnects after X amount of Trades.
- Syncable multiple Bots via Registry read/writes (needs a external Timer program).
- Bypasses auto. 'idle' disconnects.

### Link Trade via Code

- Trade multiple Boxes in Box order.
- Start from a specific Slot.
- Reconnect after X amount of Trades.
- able to use a custom Code.
- Syncable multiple Bots via Registry read/writes (needs a external Timer program).


# Requirements

- An Arduinoor Teensy (tested with ATMega16u2 and ATMega32u4)
- An UART USB Controller (make sure u install the right UART Driver for yor product)
- some Jumper cables
- probaply needs to disable Sleep Mode to prevent disconnects from USB.




### Used Libaries

Costura https://github.com/Fody/Costura

HoriPad Emulator https://github.com/wchill/SwitchInputEmulator
