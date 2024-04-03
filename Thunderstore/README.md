# ViralTremors
buttplug.io integration for Content Warning

## Setting up

### Requirements
- [Intiface Central](https://github.com/intiface/intiface-central/releases) or [Intiface Engine](https://github.com/intiface/intiface-engine/releases) (former preferred)
- A buttplug or a device that can vibrate and has [buttplug.io](https://buttplug.io) support (See [here](https://iostindex.com/?filter0Availability=Available%2CDIY&filter1ButtplugSupport=4&filter2Features=OutputsVibrators) for a list of supported devices)

### Installation

#### Automatic

- For a quick installation and organiser, [r2modman](https://github.com/ebkr/r2modmanPlus) can be used

#### Manual
- Install BepInEx (see [BepInEx Installation Guide](https://docs.bepinex.dev/articles/user_guide/installation/index.html))
- Launch Content Warning once with BepInEx installed to ensure that its working and needed folders are present
- Navigate to your Content Warning install directory and go to `./BepInEx/plugins`
- Download the mod and unzip it in the installation directory

### Usage
- Open Intiface Central (or Engine if you know how to use that)
- Start it via the big play button
- Launch Content Warning with the mod installed
  - If it doesn't work, go to Intiface settings and enable `Listen on all network interfaces` in the server settings


## Features
- Vibrate when you get hurt
- Vibrate when you die
- Vibrate when you get healed
- Vibrate when you get revived
- Vibrate when you get captured by a weeping.
- Vibrate when you go/return to/from the underworld
- Vibrate when you shock something

All of these are configurable and the config file can be found in the `BepInEx/config` directory under the name `ViralTremors.cfg`.
