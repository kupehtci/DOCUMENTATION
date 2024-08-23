#VELERO 

# Velero: Defining a Backup Schedule via CLI

Velero provides a CLI to manage backup operations, including defining backup schedules. This guide will walk you through how to create, manage, and verify a backup schedule using the Velero CLI.

To define a backup schedule using the Velero CLI, you can use the `velero schedule create` command. Below are the steps and examples.

The basic command to create a backup schedule is:

```bash
velero schedule create <schedule-name> --schedule="<cron-expression>" --ttl=<time-to-live> --snapshot-volumes
```

More additional options: 

- Include specific namespaces:  `--include-namespaces <namespace-1,namespace-2>`
- Exclude specific namespaces: `--exclude-namespaces <namespace-1,namespace-2>`
- Include specific resources:  `--include-resources <resource-kind-1,resource-kind-2>`
- Exclude specific resources: `--exclude-resources <resource-kind-1,resource-kind-2>`

#### Examples

A good example of a automatic backup, is to create a whole cluster backup each day at 2AM adn retain it for 7 days: 

```bash
velero schedule create daily-backup --schedule="0 2 * * *" --ttl=168h
```


### List all schedules

You can list all available and active schedules, with the command: 

```bash
velero schedule get
```
### Delete an schedule

You can delete the existing backups with the following command specifying the command name: 

```bash
velero schedule delete <schedule-name>
```