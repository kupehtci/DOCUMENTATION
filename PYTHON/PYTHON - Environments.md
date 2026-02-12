#PYTHON 

# PYTHON Environments

An environment in python, encapsulates and isolates the project dependencies from the system installation, so its easier to manage packages and avoid conflicts. 

Instead of using the system-wide dependencies installation, uses the virtual environment ones. 

## Create an environment

In order to create an environment, python includes the `venv` module to create this virtual environments. 

```bash
python3 -m venv /path/to/venv

# by default
python3 -m venv .venv
```

This will create a `.venv` folder that contains the python interpreter, pip and other modules installed. 

## Using the environment

The environment needs to be activated in order to use it, and disables (exit). 

To activate the environment, 
In windows: 
```powershell
/path/.venv/Scripts/activate
```

In Bash: 
```bash
source /path/.venv/bin/activate
```

To deactivate, simply execute the following command: 
```bash
deactivate
```