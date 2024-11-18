#UNIX 

### Simplify commands using aliases

You can simplify commands by establishing aliases within the bash configuration file. 

The syntax is as follows: 

```
alias <new-command>=<previous-command>
```

Example, use `k` instead of `kubectl`: 
1. Access `~/.bashrc`
2. Add the alias `alias k=kubectl`
3. Save and apply the changes with `source ~/.bashrc`
