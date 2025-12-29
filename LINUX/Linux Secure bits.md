#Linux 

# Linux Secure bits

`securebits` is a linux flag that can be used to control how the linux capabilities behave when dropping or gaining root privileges. 

Its meant to harden a Linux system. 

It has different values mapped int-string: 

* `keep-caps`: keep the capabilities when i change to a non-root user. 
	* Useful when a root user executes a command and switches to an unprivileged user that need to maintain the capabilities. 
* `keep-caps-locked`: same as `keep-caps` but block the process from switching the `keep-caps`. 
* `no-setuid-fixup`: 
* `no-setuid-fixup-locked`: same as previous but cannot be changed by a service. 
* `noroot`: being UID. 0 (root) doesn't give me automatic capabilities and they only give me what i define in the capability bounding set. 
* `noroot-locked`: same but permanent for that process. 

They can be combined so for example: 
```ini
# keep the capabilities when leavig root, dont change capabilities on UID changes and do not treat root as an special user: 
keep-caps no-setuid-fixup noroot-locked
```

In a **systemd**[^1], within an unit that defines a service, you can set the `securebits` flag using `SecureBits` within `[Service]` section. 


[^1]: systemd is the main linux service manager [[systemd]]

