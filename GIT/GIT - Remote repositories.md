#GIT 

### GIT - Remote repositories

Git keeps track of the <span style="color:orange;">remote repositories</span> that the local repository is "connected" to.

With the `git remote` command you can view, create and manage this connections to the remote repositories.

The remotes are not "connections" as so, are more like bookmarks of the URLs that the local repo can fetch and push to. 

This connections are defined within the `repo/.git/config` file. 


The name of the remote ease to use it, by replacing the use of the entire URL. 

### remote/origin

When you clone a repository with the `git clone <url>` command or via a UI client like Github Desktop or Sourcetree, it automatically creates a <span style="color:orange;">remote</span> connection named as `origin`

### How to use it

To list the different remotes: 
```bash
git remote
```

And to also show the urls that belong to each remote: (`-v = --verbose`)

```bash
git remote -v
```

To create a new remote: 

```bash
git remote add <remote-name> <remote-url>
```

To remove a remote: 

```bash
git remote rm <remote-name>
```

Rename a connection to a remote: 

```bash
git remote rename <old-name> <new-name>
```


