#AWS 

Once Brew is installed is by default configured for bash CLI tool. 

For using it with zsh CLI, you can execute the following commands to check if brew files are correctly placed within the device and add an `eval` line in the `.zsh` file. 

```zsh
test -d ~/.linuxbrew && eval "$(~/.linuxbrew/bin/brew shellenv)"
test -d /home/linuxbrew/.linuxbrew && eval "$(/home/linuxbrew/.linuxbrew/bin/brew shellenv)"
echo "eval \"\$($(brew --prefix)/bin/brew shellenv)\"" >> ~/.zsh
```

Once you have it you can test it: 

```zsh
brew install hello
```

In case of some errors after the install, you can use `brew doctor` to troubleshoot common issues. 


