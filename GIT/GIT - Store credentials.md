#GIT 

### Store credentials

You can store the credentials to access a remote repository in a local plain text file

You can create this file as: `\home\<user>|.git-credentials`: 

```txt
https://<username>:<password>@<remote_repo_url>
```

Another simpler method is use the command: 

```
git config --local credential.helper store
```

and then: 

```
git pull
```

And the credentials requested in this command will stored in the file