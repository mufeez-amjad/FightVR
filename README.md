# FightVR
## Inspiration
As avid gamers, we've always strived to fully immerse ourselves within the game. Whether it be ultrawide 21:9 curved 34 inch monitors or virtual reality, we love delving deep into the fantastical realm of video games. We wished to take this immersion to the next level using hardware input devices to control in-game objects. Currently, virtual reality headsets with dedicated controllers such as the HTC Vive and Oculus Rift are prohibitively expensive for the average consumer, leading to the fact that many have not experienced the true sensation of being immersed into the world of video games. As such, we built a game that allows consumers to use relatively inexpensive devices, including their existing phones, to take part in such an experience.

## What it does
* An open world Google Cardboard game in which you control a sword using your phone's gyroscope and accelerometer data in addition to using various sensors on the Myo, created by Thalmic Labs, which allows for hand-free control of the player's shield in a very life-like manner.
* The player is able to kill enemies which spawn into the arena and block hits from these enemies.


## How we built it
* Unity game engine for creating the virtual reality environment
* Myo SDK to use Bluetooth low energy to directly communicate with an Android phone
* A server-client interface was built to wirelessly send information from one phone to another to control the main hand weapon (a sword)
* An Android application to display our game and server-client interface


## Challenges we ran into
* Forgot the Myo Bluetooth dongle leading to not being able to connect the Myo directly to a PC thus we were forced to use Bluetooth low energy to connect via Android (which turned out to be best in the end since it directly integrated with our Unity-based Android VR application


## Accomplishments that we're proud of
* Embedding Myo code into our exported Unity project
* Figuring out what the data from the phone and Myo's sensors meant
* Using double integration to calculate the position from the accelerometer data of the phone
* Reverse engineering the use of the Myo Android SDK from the Myo Whip application on the Play Store

## What we learned
* Android Studio and Unity is painful
* Vector and quaternion mathematics

## What's next for FightVR
* We hope to package the application in a distributable and make it public for others to enjoy!
* We plan to incorporate biometric sensors e.g. heart-beat sensors and the Muse headband, to allow for more inputs to creatively control the game world
