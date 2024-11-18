
# Premake5 - Structure

Premake5 is used for generating the compilation resources for C and C++ languages. 
Its a CLI util that reads a `.lua` file where all the project definition is declared and generate the project files for tools like Visual Studio, XCode or GNU Make. 
### Structure of the file

The premake5.lua file must follow at least a certain format for defining the minimum required parameters: 

```lua
workspace "<workspace-name>"
	configurations { "Debug", "Release" }

project "<project-name>"
	kind "ConsoleApp"  
	language "C++"  
	files { "**.h", "**.cpp" }  
	  
	filter { "configurations:Debug" }  
	defines { "DEBUG" }  
	symbols "On"  
	  
	filter { "configurations:Release" }  
	defines { "NDEBUG" }  
	optimize "On"
```