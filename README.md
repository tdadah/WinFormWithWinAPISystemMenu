# WinFormWithWinAPISystemMenu
This is a simple Windows Forms application that uses Window API to add an item to the system menu.  

## Form

The system menu item "Code assesment" is added to the Windows Form application using the Windows API.  Clicking on the menu item will open a popup that says "Hello World!".

![Form](Screenshots/Form.png?raw=true "Form")

![System menu](Screenshots/SystemMenu.png?raw=true "System menu")

![Pop up](Screenshots/Popup.png?raw=true "Pop up")

## Calculator

If the Windows Calculator application is already open or opened after the Form1 is already running, a menu item will be added to the Calculator's system menu.  This menu item does not do anything on click and is therefor disabled by default.  To make this work, a background worker was added to constantly check to see if the calculator application is open.  If the the calculator is open, the menu item is added.  This background worker continues to run so it also checks to see if the menu item has already been added so that the item is only added once.  Because the background worker is continuously running, if the calculator is closed and then opened again, the menu item will be added again.
![Calculator](Screenshots/Calculator.png?raw=true "Calculator")

## Known issues

If the Form is closed while the Calculator is still running, the system menu will no long appear.  Starting the Form does not fix the menu on the calculator.  Removing the new menu items on closing event does not fix the issue either.  Closing the Calculator and opening it does fix the issue.

