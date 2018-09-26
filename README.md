Spacecraft's physics simulation in weightlessness for my Bachelor thesis. 6 DOF, interactive controls. Done with Unity, OculusVR and some free assets. 
Uploading only scripts because of too large files. 

Simulation allowed player to control ship in FPP and TPP. User can choose from 2 modes of controlling: Stable and Free. Stable lets him to add velocity to spacecraft, even if he doesn't give an input. It can be stopped any time so the spacecraft would slow down to 0 vel. Free lets the user fly freely, and slows down asap it doesn't take input. 
Input data is collected by the distance difference between oculus touch controllers and "control balls" ( go to the film below ). MovementController allow the user to move spacecraft freely in 6 DOF if he gets fluency in using it :) 

The most interesting thing is Filter class. Making use of it I could cut off high frequencies from player input which let me interpolate gently between real-time velocity changes. 

Link to film with TPP view:https://drive.google.com/file/d/11octeLUu_k1uD3rPPtRXBNYUv19iUeYW/view?usp=sharing
Unity 2018.1.2f1

