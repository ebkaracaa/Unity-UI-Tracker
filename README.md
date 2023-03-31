# Unity UI Tracker Window

The UI Tracker Window is a Unity Editor extension that tracks changes made to the Editor UI and displays them in a list. It holds the Undo/Redo history. It only tracks changes made to the Unity Editor UI, such as changes to the scene hierarchy, object properties, and component settings. The list is dynamic and limit can be changed from the script.



Window             |  Clear Button Check
:-----------------:|:-----------------:
![Window](ss.png)|![Button](ss2.png)
## Installation
    Download script.
    Copy the UI_Tracker.cs script to your Unity project's Assets/Editor folder.
    Open the Unity Editor and select Window > UI Tracker from the menu to open the UI Tracker window.

Undo or Redo to see the history.

It is not recommended to leave the window open during a build or release of the game or application.
### TODO?
Applying material to the object is counted as change at that moment, I don't know why. Because of that I added current change description part.

### License
The UI Tracker Window script is licensed under the MIT license. Feel free to use, modify, and distribute the script as needed.
