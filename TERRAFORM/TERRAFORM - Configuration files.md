
The code in terraform is used to define the configuration of the different resources that form the infrastructure. 

This configuration is defined in <span style="color:orange;">.tf</span> files and follow a json similar language format. 


A <span style="color:LightSeaGreen;">module</span> is a collection of `.tf` and/or `.tf.json` files kept in a directory. It only takes into account top-level files, the ones kept in nested directories are taken as separated modules. 