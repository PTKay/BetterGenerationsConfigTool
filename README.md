# You are probably looking for this instead: [Rewrite](https://github.com/PTKickass/GenerationsConfigTool_Rewrite)

# Better Sonic Generations Config Tool
A tweaked version of Sonic Generations' configuration tool, using [Sajid's](https://github.com/Sajidur78) decompilation as a base.

This aims to maintain the same design as the original configuration tool, but with some tweaks in order to fix some issues and design inconsistencies.

Fixes/Changes so far:
- Aligned text of the Graphics Configuration pane
- Removed repeated title in Graphics Configuration pane
- Added taskbar icon
- Changed name of the Antialiasing setting to "Antialiasing (FXAA)" to specify the tipe of AA used
- Improved resolution list by simplifying the algorithm
- Improved algorithm to set global definition of the analytics option
- Removed a bunch of unused code/variables/fields
- Removed outline around the images in the first 2 tabs
- Renamed the button "Cancel" to "Quit" (personal preference)
- Disabled window resizing and the maximize button, since the window doesn't resize properly
- Fix scaling issues with the background image of the tabs
- Fixed transparency issues on higher DPI modes
- Changed the graphics adapter combo box text to make displays start at 1, and changed it so it shows "(Display \[number])" instead of "(#\[number])"
- Running the Configuration Tool will now fix the `Game files either missing or corrupt please reinstall` problem that occurs when copying Sonic Generations to another PC without installing it through Steam, making the game truly portable. You will know that the problem is being fixed once it asks you for admin rights when launching.

Discoveries so far:
- The config tool has unused checkboxes for its items. The VSync and Shadow options were previously a checkbox, but then later changed to a combo box. In the middle of those, there's a checkbox for a windowed mode, which remained unused in the final game. The game does not read this though, so this has been removed from the tool.
- The config tool has an unused tab called "Advanced Configuration". The game, apparently, ignores this file, even though the EXE has a listing for it. This tab can be restored and it's fully working, although the game itself appears to completely ignore its values.
- The config tool normally generates a GraphicsConfig.cfg file everytime you save. Turns out some of the lines of that file seem to be unused by the game, and can be left blank (the lines containing GUIDs). Sometimes, if not blank, the game will refuse to launch, so these lines have been made blank in this modified version.

![Graphics Options](https://raw.githubusercontent.com/PTKickass/BetterGenerationsConfigTool/master/Images/Graphics.png)
## The unused Advanced Configuration tab
![Advanced Options](https://raw.githubusercontent.com/PTKickass/BetterGenerationsConfigTool/master/Images/Advanced.png)
