# Better Sonic Generations Config Tool
An improved configuration tool for Sonic Generations, using [Sajid's](https://github.com/Sajidur78) decompilation as a base.

This aims to maintain the same design as the original configuration tool, but with some tweaks
in order to improve performance and design inconsistencies.

Fixes/Changes so far:
- Aligned text of the Graphics Configuration pane
- Removed repeated title in Graphics Configuration pane
- Added system tray icon
- Changed name of the Antialiasing setting to "Antialiasing (FXAA)"
- Improved resolution list by simplifying the algorithm
- Improved algorithm to set global definition of the analytics option
- Removed a bunch of unused code/variables/fields
- Removed outline around the images in the first 2 tabs
- Renamed the button "Cancel" to "Quit"
- Disabling window resizing and maximize button, since it breaks with that
- Fix scaling issues with the background image of the tabs
- Implemented Nvidia Optimus support
- Fixed transparency issues on higher DPI modes
- Changed the graphics adapter combo box text to make displays start at 1, and changed it so it shows "(Display [])" instead of "(#[])"
- Running the Configuration Tool will now fix the `Game files either missing or corrupt please reinstall` problem that occurs when copying Sonic Generations to another PC without installing it through Steam, making it now truly portable. You will know that the problem is being fixed once it asks you for admin rights when launching.

Along with this, some discoveries have been made:
- The config tool has unused checkboxes for its items. The VSync and Shadow options were previously a checkbox, but then later changed to a combo box. In the middle of those, there's a checkbox for a windowed mode, which remained unused in the final game. The game does not read this though, so this has been removed from the tool.
- The config tool also has an unused tab called "Advanced Configuration". The game, apparently, ignores this file, even though the EXE has a listing for the file. This tab can be restored and it's fully working, although the game itself appears to ignore its values completely.
- The config tool normally generates a GraphicsConfig.cfg file everytime you save. Turns out some of the lines of that file are unused by the game, and can be left blank (the lines containing GUIDs). Sometimes, if not blank, the game will refuse to launch, so these lines have been made blank in this modified version.

![Graphics Options](https://raw.githubusercontent.com/PTKickass/BetterGenerationsConfigTool/master/Images/Graphics.png)
## The unused Advanced Configuration tab
![Advanced Options](https://raw.githubusercontent.com/PTKickass/BetterGenerationsConfigTool/master/Images/Advanced.png)
