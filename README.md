
# Human adaptation to Augmented reality based wrist rehabilitation

## Introduction
This repository consists of all the building blocks required to record position data of objects and gesture data of hand in Magic Leap environment via unity and send the data to Simulink using UDP (C# scripting). 

## Methods

### Gesture data

- Install unity magic leap template available on https://ml1-developer.magicleap.com/en-us/learn/guides/1-1-unity-setup-with-template
- Install magic leap toolkit from https://github.com/magicleap/Magic-Leap-Toolkit-Unity
- After installing the toolkit, Open handtracking scene in the magic leap(tools) folder.
- Replace the handtrackingexample script with the script of the same name from this repository. 
- Once the script is replaced add the script to scene and assign a port
- load the thesis.slx script in simulink and assign the same port to the UDP block in simulink.

### Position data

- Add the position scripts to the objects. each axis requires a seperate script or the data can not be limited using substring.
- repeat steps 5 and 6 from above

### Stimulation script

- Add the handpos script to an empty object. 
- Assign text to each object in unity 
- After adding the script, assign the object and text to the script
- Adjust position of the object within the scene to meet the camera
- If the object still isnt visible try making it a prefab.
