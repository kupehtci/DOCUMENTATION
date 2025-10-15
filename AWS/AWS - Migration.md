#AWS 

# AWS Migration


## AWS Database Migration Service (AWS DMS)
### Ongoing replication task (AWS DMS)

An ongoing replication task in AWS Database Migration Service (DMS) is a task that continuously keeps the target database synchronized with the source database after the **initial load**.

- You first perform a **full load** of the existing data from the source to the target.
- Then, the task **keeps monitoring changes** on the source and applies them to the target database **in near real-time**.
- This allows the source database to **remain online and operational** during the migration.
- Useful for **minimal downtime migrations**.