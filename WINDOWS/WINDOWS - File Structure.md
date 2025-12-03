#WINDOWS 

# WINDOWS - File Structure



# User Profile

The user profile folders lives under `C:\Users\<username>` and store the user related files and settings that should not be shared across the system to other accounts. 

An administrator user has access to all user's folder but a nominal user has normally only access to its own folder. 

Inside this folder we find: 
* **Desktop**: actual windows desktop. 
* **Documents**
* **AppData\local**: holds application data like caches, logs and local-only configurations for each app. 
* **AppData\Roaming** user settings for the user profile normally in domain or roaming scenarios. 
	* Many IDEs and tools keepo the configuration here so its tied to the user. 


## Typical dev locations

Several folders are found over the user profile used for developer tools: 

* `.nugeet` stores the NuGet global packages and cache for .Net projects. 
* `.dotnet`: used by the .Net SDK and global tools to store the SDKs, runtimes and tools. 
* `.npm` for Node.js to store the CLI took and cached NPM packages. 



