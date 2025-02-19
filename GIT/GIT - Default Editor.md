#GIT 

# GIT Default Editor

When you run Git commands like `git merge` or `git rebase -i`, Git opens a text editor to allow you to modify commit messages or rebase instructions. 

By default, Git in Linux distributions, it has Nano as its editor, but many developers (like in my case) prefer Vim.

You can check which editor Git is currently using by running:

```
git config --get core.editor
```

If no output appears, Git is likely using the system default, which is often Nano.

You can set Vim as the default editor with the following command:

```
git config --global core.editor "vim"
```

This command ensures that every time Git requires an editor, it will open Vim instead of Nano.

Another way to configure the default Git editor is by setting the `EDITOR` environment variable. This can be useful if you want the change to apply beyond Git:

```
export EDITOR=vim
```

To make this change permanent, add the following line to your shell configuration file:

- For Bash: Add this line to `~/.bashrc` or `~/.bash_profile`
- For Zsh: Add it to `~/.zshrc`

```
echo 'export EDITOR=vim' >> ~/.bashrc
source ~/.bashrc
```

### Changes verification

After making these changes, verify that Vim is set as the editor:

```
git config --get core.editor
```

If it outputs `vim`, the configuration was successful.