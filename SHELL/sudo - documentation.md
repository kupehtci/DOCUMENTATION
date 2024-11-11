# Sudo command documentation

Writing sudo after a command enables you to do with the root permision. 
Doing this will ask you the password of the root user. 

**sudo su** enables you to write in terminal as the **root**user

```bash
sudo su
# In other OS
su -
```


In case that sudo is not enabled by default like most Linux systems nowadays, you can enable it: 

```bash
# Identify as superuser
su - 

# Update the APT
apt update

# Install sudo functionality
apt install sudo -y 

# If your user is not abled to do sudo 
usermod -aG sudo <username>
```

