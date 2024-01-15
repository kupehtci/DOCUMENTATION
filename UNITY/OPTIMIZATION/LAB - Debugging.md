#UNITY #OPTIMIZATION 

<span style="color:#ababf5;">Debugging</span> is the act of inspecting the behaviour of a program while its executing. 

Debugging allow the developer to deeply understant the execution of the code helping to understant errors that may arise. 

Two main ways of debugging code: 

* log debugging
* breakpoint debugging

#### LOG DEBUGGING

Consist in placing printed messages along the code to be able to use the console window to understand the code flow.

Its a slow method in terms of runtime performance and developer productivity. 
Log must be done with care and the code created to logging must be erased for the build. 

It creates <span style="color:orange;">boilerplate</span> code that uses string and these log messages must be interpreted by the developer creating more opportunities for errors in the code. 

In Unity: 

```CS
Debug.Log(string); 
Debug.LogWarning(string); 
Debug.LogError(string); 
```

Another method is to log into a file, so developer can have a persistent log state that can be shared. 

Its useful for strange behaviours in the code that can only be replicated in some machines and not others. 
Can also be used in release build to gather errors and bugs. 

#### BREAKPOINT DEBUGGING

Consist in stoping the execution of the game to provide full snapshot of the state of the program, including the <span style="color:orange;">CallStack</span>, variable values and memory. 

Its performed using <span style="color:#ababf5;">breakpoints</span>.

The developer can step through the code to inspect line by line with 4 different methods

• Step Over -> pass a function
• Step Into -> pass inside a function
• Step Out -> gets out a function
• Continue -> Continue to next line of code

Also variables can be modified mid-execution to test different conditions in code execution. 

#### OTHERS

Can also be debugged using: 

*  Developer command console (ingame) 
* Gizmos [[UNITY - Gizmos]]



## DEBUG MODE IS SLOWER

Debug mode is slower for various reasons: 

* __Optimization levels__: In release mode there are some optimization that are not in debug mode: 
	* compiler performs optimizations to make code faster and efficiently. 
	* Removes redundant code
	* Inline expansion
	* Optimize loops precalculated
* __Debug information__: Debug builds include additional information about binary files, increasing size of binary. This helps to map instructions in running program to lines in the source code. Its called <span style="color:orange;">symbolic debug information</span>, generated to correlate the program source with binary execution. 
* __Assertion check__: Are often include in runtime checks, such as assertion checks, to catch errors and bugs. Significantly slow down the execution. Example: division by 0, null references or buffer overflow. 
* __Logging and instrumentation__: Debugs may include aditional logging and instrumentation code to aid in debudding and profiling. 
* __No inline expansion__: In compiler mode, compiler perform inline expansion of functions. [[Inline Expansion]]. 
* __No dead code elimination__: Dead code is an optimization that removes code taht doesn't affect program's output. This is disabled in debug mode
* __I/O Limitations__: Debug is limited in I/O terms due to writing extensive debiug information like: 
	* Program database \*.pdb files
	* Larger Object \*.obj files