#WINDOWS

# WINDOWS - PATH Environment Variable

The **Path** environment variable in windows is one of the most useful variables in the OS as its stores a **list** of folders for programs or executables (like when you throw a command like python or git in the Powershell cmd). 
Because those folders are listed in path, you type the commands without typing the full installation path. 

Example, path contains `C:\Program Files\Python\` you just type `python` instead of `C:\Program Files\Python\python.exe`. 

As a **list** it has a series of paths separated with `;` and each time you execute a command, searches in those paths and it its a match runs the program, otherwise; you get a "command its not recognized" error. 

> Note!: many application installation will indicate an "Add to PATH" option during installation so their commands work immediately on any terminal window. 
> 
## Setting PATH variable

Path variable can be edited in Windows 10 and 11 in various ways: 

* Permanently: 
	* System Properties → Advanced → Environment Variables and by selecting Path variable you can add or delete entries of the variable. 
	* Using `SetEnvironmentalVariable` command [[PS - Environment Variables]].
	* Using `setx PATH "%PATH%;C:\path\to\directory\"`
	* For all users: `setx /M PATH "%PATH%;C:\path\to\directory\"`
* Temporary: only over the current session. 
	* In the command prompt: 
```cmd
set PATH=%PATH%;C:\path\to\directory\
```

