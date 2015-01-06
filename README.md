IITkNet v1.0
=======

```txt
Saksham Sharma
Computer Science and Engineering
IIT Kanpur
B.Tech 1st Year
```

A GUI wrapper for command line commands to set the IP and DNS in IIT Kanpur. Enables ease of switching IPs, or switching from DHCP to Static.

# Usage
1.  Download the compressed archive in the source folder. Extract it.
2.  Run the setup.bat file, and press 'd' when prompted.
3.  Right click on the desktop and set permission to 'Run as administrator' in the compatibility tab.
4.  Open network and sharing center, and click on 'Change adapter settings' on the left. Note the adapter names you'll want to change the IP for.
5.  Run the software from desktop. The required files have been copied to C:/IITkNet.
6.  Do allow sharing of the Ethernet connection in network and sharing center if you want to use the hotspot  feature. This does not (yet) work for every user.

# Technical details:
1.  Built on Visual Studio 2013, with minimum .NET mistakenly set to 4.5
2.  C# used.
3.  VB Script used for creating desktop shortcut in setup.bat.

# Issues:
1.  Only works on Windows OS, with .NET framework 4.5 installed. Would be fixed soon. Windows 8 comes with .NET 4.5 pre-installed so users of Win8 and above need not worry. Others, please install .NET 4.5.
2.  Currently only supports Hall 2 IP addresses. Data files for other halls would be added soon.
3.  Help file needs to be updated.
4.  The application is named 'WindowsFormsApplication1' at the moment.
5.  Icon file is larger than required.

# Changelog:

- **6/1/15**  -  v1.0  First commit.
