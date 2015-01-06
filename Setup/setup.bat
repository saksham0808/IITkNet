@ECHO OFF

ECHO ****************************************
ECHO ****************IITkNET*****************
ECHO Copying required files to IITkNet folder in C drive.
ECHO Press d and then enter when a choice is provided.

ECHO.
xcopy files\* /h C:\IITkNet
xcopy IITkNet.exe /h C:\IITkNet

ECHO.
ECHO Creating shortcut for the application on the desktop.
ECHO You can move this shortcut to wherever you want.
ECHO.

set SCRIPT="%TEMP%\%RANDOM%-%RANDOM%-%RANDOM%-%RANDOM%.vbs"

echo Set oWS = WScript.CreateObject("WScript.Shell") >> %SCRIPT%
echo sLinkFile = "%USERPROFILE%\Desktop\IITkNet.lnk" >> %SCRIPT%
echo Set oLink = oWS.CreateShortcut(sLinkFile) >> %SCRIPT%
echo oLink.TargetPath = "C:\IITkNet\IITkNet.exe" >> %SCRIPT%
echo oLink.Save >> %SCRIPT%

cscript /nologo %SCRIPT%
del %SCRIPT%

ECHO Shortcut created!
ECHO ****IMPORTANT****
ECHO Right click on the shortcut on the desktop,
ECHO go to compatibility tab and check the 'run as admin' checkbox.
pause

ECHO.
ECHO Installation is done!
ECHO Now you can delete this folder.
ECHO ****************************************
pause