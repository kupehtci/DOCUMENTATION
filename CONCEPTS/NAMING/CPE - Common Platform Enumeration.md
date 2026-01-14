#CONCEPTS 

# CPE - Common Platform Enumeration

**CPE** or **Common Platform Enumeration** is an standardized naming scheme bring an unique identifier to IT products like OS, applications and hardware. 

It provides a **structured**, **URI-based** named for a product that also includes its version, update and even the edition so its human readable and understandable by a system or software. 

CPE 2.3 has the following syntax: 
```txt
cpe:<cpe_version>:<part>:<vendor>:<product>:<version>:<update>:<edition>:<language>:<sw_edition>:<target_sw>:<target_hw>:<other>
```

* **part**: identifies `a` for applications, `h` for hardware and `o` for operating systems. 
* **vendor**: describe or identifies the organization that manufactured the product. 
* **product**: the name of the OS, system, package or application. 
* **version**: version of the product. 
* **update**: minor versions like `ga` for General Availability or `beta`, `alpha` or similar. 
* **edition**: more version granularity than version + update. 

Examples of CPEs: 
```txt
# Microsoft's windows 7
cpe:2.3:o:microsoft:windows_7:-:sp2:*:*:*:*:*:*

# React library
cpe:2.3:a:facebook:react:*:*:*:*:*:*:*:*
```

CPE its normally used for: 
* Vulnerability databases relate CVEs[[CVEs Common Vulnerabilities and Exposures]] using the CPE associated with the dependency. 
* Inventory in IT environments. 
