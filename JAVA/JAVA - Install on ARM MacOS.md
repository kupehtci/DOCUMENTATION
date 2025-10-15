#JAVA 

# Install Java on ARM MacOS

To install Java in a MacOS system is recommendable to use a package manager like Brew (Homebrew), which can be used to install both Java and Maven: 

```bash
brew install openjdk@17

brew install maven
```

Once you have both packages installed in this order, as java needs to be installed for maven installation; you need to set up some configuration for environmental variables: 

* Add to the `~/.zshrc` file or `~/.bash_profile` the following lines: 

```bash
export JAVA_HOME=/opt/homebrew/opt/openjdk@17/libexec/openjdk.jdk/Contents/Home export PATH="/opt/homebrew/opt/openjdk@17/bin:$PATH"
```

This will set the path to the Java installation and the path to Java for maven to recognize the executable. 