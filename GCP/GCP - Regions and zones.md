#GCP 

# GCP Regions and zones

Google Cloud is organized into regions and zones. All the deployed resources within GCP must be in an specific region and will have high availability in that Region. 


It follows this enclosure format, where a region is a section of a Multi region and a zone is a part within a region: 
```
Multi-region --> Region --> Zone
```

Example: 

```
Europe --> europe-west2 --> (europe-west2-a, europe-west2-b, europe-west2-c)
```

Unlike AWS, each edge zone or zone, its not always a physical data center, but act at is. 

A <span style="color:orange;">region</span> is a geographical area where RTT[^1] from one VM to another is less than 1ms


[^1]: RTT or Round Trip Time [[RTT Time]]