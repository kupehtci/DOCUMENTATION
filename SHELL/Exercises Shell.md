
1. use echo to display Hello followed by the username. 

```bash
echo "Hello $USER"
# or
echo "Hello $(whoami)"
```

2. List all exported variables in the shell

```bash
env
# or 
printenv
```

3. Enter a command that displays the number of lines of the file /var/log/messages

```bash
wc -l < /var/log/messages
```

