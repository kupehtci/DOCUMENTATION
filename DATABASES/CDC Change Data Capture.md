#CONCEPTS 

# Change Data Capture

**Change Data Capture** or **CDC** its a technique for detecting and stream only the changes made to a data source like new inserts, updates or deletes. 

Instead of copying the entire database's tables, CDC captures the incremental changes and synchronize with other DB instances. 

# How it works ?

It captures the transactions commit log to capture row-level changes with minimal impact. 

It can also be triggered when changes to tables are made or by periodic comparisons to detect differences. 