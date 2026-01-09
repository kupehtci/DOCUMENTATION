#JAVA 

# JAVA - JDK Installation

This guide explains the different steps to install Java JDK versions in different Operating Systems. 

## Linux JDK installation

To install JDK on Linux its normally to use the package manager: 

```bash
# ubuntu / debian
sudo apt update
sudo apt install openjdk-17-jdk  # For Java 17
sudo apt install openjdk-11-jdk  # For Java 11
sudo apt install openjdk-21-jdk  # For Java 21

# RHEL / CentOS
sudo yum install java-17-openjdk-devel  # For Java 17
sudo yum install java-11-openjdk-devel  # For Java 11
```

> Note: `-devel` includes the development tools like `javac` into the installation. 

## Windows JDK installation

In Windows, you can follow this steps to install and configure a java version: 

1. Download the required version from https://www.oracle.com/es/java/technologies/downloads/. (An Oracle account is needed, use an existing one or register into the platform). 
2. Unzip the contents into `C:\ProgramFiles\Java\jdk-{version}`
3. Modify the environmental variables: 
	* Add `JAVA_HOME` pointing to the new version or the default one. 
	* Some platforms like Azure DevOps ([[JavaToolInstaller]]) want other versions different from the default to be referenced in environmental variables like `JAVA_HOME_{version}_{architecture}` like `JAVA_HOME_11_X64`. 
	* Add the path to the new installed Java version to `PATH` environmental variable. Take into account the order, the default Java must be the first, after other versions. 



