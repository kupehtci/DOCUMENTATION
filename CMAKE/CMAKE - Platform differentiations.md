#CMAKE 


When you want to be able to port the project between different platforms, as example, MacOS, Windows or Linux, because they are different OS with different file structure and libraries, is important to be able to make different build for each of them in the project. 

You can differenciate some Cmake builds commands by detecting the Operating System and execute different commands in function of it. 


To make this we have built-in variable `CMAKE_SYSTEM_NAME`. 


### CMAKE_SYSTEM_NAME

This variable stores the **name** of the OS that cmake is building for. 

This variable is set by default to the same value as `CMAKE_HOST_SYSTEM_NAME`. 



#### Posible values

Also apart from the previous said for MacOS, Windows and Linux, there exist other possible values for other different systems. 

|Value|Name|
|---|---|
|`ADSP`|Analog Devices Audio Digital Signal Processing|
|`AIX`|IBM Unix operating system|
|`Android`|Android operating system|
|`ARTOS`|Operating system for microcontrollers|
|`BeOS`|Operating system for personal computers (discontinued)|
|`BlueGeneL`|Blue Gene/L static environment|
|`BlueGeneP-dynamic`|Blue Gene/P dynamic environment|
|`BlueGeneP-static`|Blue Gene/P static environment|
|`BlueGeneQ-dynamic`|Blue Gene/Q dynamic environment|
|`BlueGeneQ-static`|Blue Gene/Q static environment|
|`BSDOS`|BSD operating system (discontinued)|
|`Catamount`|Operating system for Cray XT series|
|`CrayLinuxEnvironment`|Cray Linux Environment|
|`CYGWIN`|Cygwin environment for Windows|
|`Darwin`|Apple stationary operating systems (macOS, OS X, etc.)|
|`DOS`|MS-DOS or compatible|
|`DragonFly`|BSD-derived operating system|
|`eCos`|Real-time embedded operating system|
|`Emscripten`|Compiler toolchain to WebAssembly|
|`Euros`|Real-time operating system for embedded devices|
|`FreeBSD`|FreeBSD operating system|
|`Fuchsia`|Operating system by Google based on the Zircon kernel|
|`Generic-ADSP`|Generic ADSP (Audio DSP) environment|
|`Generic-ELF`|Generic ELF (Executable and Linkable Format) environment|
|`Generic`|Some platforms, e.g. bare metal embedded devices|
|`GHS-MULTI`|Green Hills Software MULTI environment|
|`GNU`|GNU/Hurd-based operating system|
|`Haiku`|Unix operating system inspired by BeOS|
|`HP-UX`|Hewlett Packard Unix|
|`iOS`|Apple mobile phone operating system|
|`kFreeBSD`|FreeBSD kernel with a GNU userland|
|`Linux`|All Linux-based distributions|
|`Midipix`|POSIX-compatible layer for Windows|
|`MirBSD`|MirOS BSD operating system|
|`MP-RAS`|MP-RAS UNIX operating system|
|`MSYS`|MSYS environment (MSYSTEM=MSYS)|
|`NetBSD`|NetBSD operating systems|
|`OpenBSD`|OpenBSD operating systems|
|`OpenVMS`|OpenVMS operating system by HP|
|`OS2`|OS/2 operating system|
|`OSF1`|Compaq Tru64 UNIX (formerly DEC OSF/1, Digital Unix) (discontinued)|
|`QNX`|Unix-like operating system by BlackBerry|
|`RISCos`|RISC OS operating system|
|`SCO_SV`|SCO OpenServer 5|
|`SerenityOS`|Unix-like operating system|
|`SINIX`|SINIX operating system|
|`SunOS`|Oracle Solaris and all illumos operating systems|
|`syllable`|Syllable operating system|
|`Tru64`|Compaq Tru64 UNIX (formerly DEC OSF/1) operating system|
|`tvOS`|Apple TV operating system|
|`ULTRIX`|Unix operating system (discontinued)|
|`UNIX_SV`|SCO UnixWare (pre release 7)|
|`UnixWare`|SCO UnixWare 7|
|`visionOS`|Apple mixed reality operating system|
|`watchOS`|Apple watch operating system|
|`Windows`|Windows stationary operating systems|
|`WindowsCE`|Windows Embedded Compact|
|`WindowsPhone`|Windows mobile phone operating system|
|`WindowsStore`|Universal Windows Platform applications|
|`Xenix`|SCO Xenix Unix operating system (discontinued)|

