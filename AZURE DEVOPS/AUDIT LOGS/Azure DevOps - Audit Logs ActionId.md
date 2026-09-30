#AZURE_DEVOPS 

# Azure DevOps - Audit Logs ActionId

`ActionId` property in each Audit log's event represent the type of action that has been performed over the organization. 

These are the possible `ActionId` that can be found in the audit logs: 

## Artifacts events

- `Artifacts.Feed.Project.Create` – Created a project-scoped feed.    
- `Artifacts.Feed.Org.Create` – Created an organization-scoped feed.
- `Artifacts.Feed.Project.Modify` – Modified a project-scoped feed. 
- `Artifacts.Feed.Org.Modify` – Modified an organization-scoped feed.
- `Artifacts.Feed.Project.SoftDelete` – Moved a project feed to the Feed Recycle Bin.
- `Artifacts.Feed.Org.SoftDelete` – Moved an organization feed to the Feed Recycle Bin.
- `Artifacts.Feed.Project.HardDelete` – Permanently deleted a project feed.
- `Artifacts.Feed.Org.HardDelete` – Permanently deleted an organization feed.
- `Artifacts.Feed.Project.Modify.Permissions` – Changed permissions for a user/group on a project feed.
- `Artifacts.Feed.Org.Modify.Permissions` – Changed permissions for a user/group on an organization feed.
- `Artifacts.Feed.Project.Modify.Permissions.Deletion` – Removed permissions for a user/group on a project feed.
- [ ] `Artifacts.Feed.Org.Modify.Permissions.Deletion` – Removed permissions for vaulta user/group on an organization feed.
- `Artifacts.Feed.Project.FeedView.Create` – Created a feed view in a project feed.
- `Artifacts.Feed.Org.FeedView.Create` – Created a feed view in an organization feed.
- `Artifacts.Feed.Project.FeedView.Modify` – Modified a feed view in a project feed.
- `Artifacts.Feed.Org.FeedView.Modify` – Modified a feed view in an organization feed.
- `Artifacts.Feed.Project.FeedView.HardDelete` – Permanently deleted a feed view in a project feed.
- `Artifacts.Feed.Org.FeedView.HardDelete` – Permanently deleted a feed view in an organization feed.

## AuditLog events

- `AuditLog.AccessLog` – Someone accessed the audit log.
- `AuditLog.DownloadLog` – Downloaded the audit log in a specific format.
- `AuditLog.StreamCreated` – Created an audit stream to a consumer (e.g., Event Hub).
- `AuditLog.StreamDeleted` – Deleted an audit stream.
- `AuditLog.StreamDisabledBySystem` – System disabled an audit stream.
- `AuditLog.StreamDisabledByUser` – User disabled an audit stream.
- `AuditLog.StreamEnabled` – Enabled an audit stream.
- `AuditLog.StreamModified` – Modified an audit stream configuration.
- `AuditLog.StreamRead` – Accessed the list of audit streams.
- `AuditLog.TestStream` – Tested an audit stream connection.

## Billing events

- `Billing.BillingModeUpdate` – Changed billing mode for a subscription.
- `Billing.LimitUpdate` – Changed usage limit for a metered resource (e.g., parallel jobs).
- `Billing.PurchaseUpdate` – Changed purchased quantity for a metered resource.
- `Billing.SubscriptionLink` – Linked a new Azure subscription for billing.
- `Billing.SubscriptionUnlink` – Unlinked an Azure subscription from billing.
- `Billing.SubscriptionUpdate` – Changed billing from one subscription to another.

## Enterprise Live Migrations (ELM) events

- `ELM.RepoMigrationFailed` – Repository migration failed.
- `ELM.RepoMigrationCompleted` – Repository migration completed successfully.
- `ELM.RepoMigrationCancelled` – Repository migration was cancelled.
- `ELM.RepoMigrationRestarted` – Repository migration was restarted.
- `ELM.RepoValidationStarted` – Started validation for a repository migration.
- `ELM.RepoValidationCompleted` – Completed validation for a repository migration.
- `ELM.RepoInitialSyncStarted` – Started initial synchronization for a repository.
- `ELM.RepoInitialSyncCompleted` – Completed initial synchronization for a repository.
- `ELM.RepoSyncPaused` – Paused synchronization for a repository.
- `ELM.RepoSyncResumed` – Resumed synchronization for a repository.
- `ELM.RepoAdminGranted` – Granted admin access to a migrated repository.
- `ELM.RepoCutoverScheduled` – Scheduled cutover for a repository migration.
- `ELM.RepoRWConverted` – Converted source repo to read-only during cutover.
- `ELM.RepoPipelineRewireCompleted` – Completed pipeline rewiring for a migrated repo.
- `ELM.RepoBoardsConnectionProvisioned` – Provisioned Azure Boards connection for a migrated repo.

## Extension events

- `Extension.Disabled` – Disabled an extension.
- `Extension.Enabled` – Enabled an extension.
- `Extension.Installed` – Installed an extension (with version).
- `Extension.Uninstalled` – Uninstalled an extension.
- `Extension.VersionUpdated` – Updated an extension to a new version.

## Git licensing events

- `Git.RefUpdatePoliciesBypassed` – Bypassed branch/PR policies on a branch.
- `Git.RepositoryCreated` – Created a Git repository.
- `Git.RepositoryDefaultBranchChanged` – Changed the default branch of a repo.
- `Git.RepositoryDeleted` – Deleted a Git repository.
- `Git.RepositoryDestroyed` – Permanently destroyed a Git repository.
- `Git.RepositoryDisabled` – Disabled a Git repository.
- `Git.RepositoryEnabled` – Enabled a Git repository.
- `Git.RepositoryForked` – Forked a Git repository.
- `Git.RepositoryRenamed` – Renamed a Git repository.
- `Git.RepositoryUndeleted` – Restored a deleted Git repository.

## Group events

- `Group.CreateGroups` – Created a security group.
- `Group.UpdateGroupMembership.Add` – Added a member to a group.
- `Group.UpdateGroupMembership.Remove` – Removed a member from a group.
- `Group.UpdateGroups.Delete` – Deleted a security group.
- `Group.UpdateGroups.Modify` – Modified group properties.
 
## Library events

- `Library.AgentAdded` – Added an agent to an agent pool.
- `Library.AgentDeleted` – Removed an agent from an agent pool.
- `Library.AgentPoolCreated` – Created an agent pool.
- `Library.AgentPoolDeleted` – Deleted an agent pool.
- `Library.AgentsDeleted` – Removed multiple agents from a pool.
- `Library.ServiceConnectionCreated` – Created a service connection.
- `Library.ServiceConnectionCreatedForMultipleProjects` – Created a service connection shared across projects.
- `Library.ServiceConnectionDeleted` – Deleted a service connection from a project.
- `Library.ServiceConnectionDeletedFromMultipleProjects` – Deleted a service connection from multiple projects.
- `Library.ServiceConnectionExecuted` – Used a service connection in a pipeline run.
- `Library.ServiceConnectionForProjectModified` – Modified a service connection scoped to a project.
- `Library.ServiceConnectionModified` – Modified a service connection.
- `Library.ServiceConnectionPropertyChanged` – Changed a property (e.g., IsDisabled) of a service connection.
- `Library.ServiceConnectionShared` – Shared a service connection with a project.
- `Library.ServiceConnectionSharedWithMultipleProjects` – Shared a service connection with multiple projects.
- `Library.VariableGroupCreated` – Created a variable group.
- `Library.VariableGroupCreatedForProjects` – Created a variable group for multiple projects.
- `Library.VariableGroupDeleted` – Deleted a variable group from a project.
- `Library.VariableGroupDeletedFromProjects` – Deleted a variable group from multiple projects.
- `Library.VariableGroupModified` – Modified a variable group in a project.
- `Library.VariableGroupModifiedForProjects` – Modified a variable group for multiple projects.

## Licensing events

- `Licensing.Assigned` – Assigned an access level (e.g., Basic, Stakeholder) to a user.
- `Licensing.GroupRuleCreated` – Created a group-based licensing rule.
- `Licensing.GroupRuleDeleted` – Deleted a group-based licensing rule.
- `Licensing.GroupRuleModified` – Modified the access level in a group licensing rule.
- `Licensing.Modified` – Changed a user’s access level.
- `Licensing.Removed` – Removed an access level from a user.

## Organization events

- `Organization.Create` – Created an Azure DevOps organization.
- `Organization.LinkToAAD` – Linked the organization to a Microsoft Entra (Azure AD) tenant.
- `Organization.UnlinkFromAAD` – Unlinked the organization from Microsoft Entra.
- `Organization.Update.Delete` – Deleted the organization.
- `Organization.Update.ForceUpdateOwner` – Forced a change of organization owner.
- `Organization.Update.Owner` – Changed organization owner.
- `Organization.Update.Rename` – Renamed the organization.
- `Organization.Update.Restore` – Restored a deleted organization.

## OrganizationPolicy events

- `OrganizationPolicy.EnforcePolicyAdded` – Added an enforced organization policy.
- `OrganizationPolicy.EnforcePolicyRemoved` – Removed an enforced organization policy.
- `OrganizationPolicy.PolicyValueUpdated` – Changed the value of an organization policy.

## Pipelines events

- `Pipelines.DeploymentJobCompleted` – Completed a deployment job to an environment.
- `Pipelines.HostedParallelismPaid` – Set hosted parallelism to paid tier.
- `Pipelines.HostedParallelismPrivate` – Set hosted parallelism to free tier for private projects.
- `Pipelines.HostedParallelismPublic` – Set hosted parallelism to free tier for public projects.
- `Pipelines.OAuthConfigurationCreated` – Created an OAuth configuration for a service.
- `Pipelines.OAuthConfigurationDeleted` – Deleted an OAuth configuration.
- `Pipelines.OAuthConfigurationUpdated` – Updated an OAuth configuration.
- `Pipelines.OrganizationSettings` – Changed a Pipelines setting at organization level.
- `Pipelines.PipelineCreated` – Created a pipeline (YAML or classic).
- `Pipelines.PipelineDeleted` – Deleted a pipeline.
- `Pipelines.PipelineModified` – Modified a pipeline.
- `Pipelines.PipelineRetentionSettingChanged` – Changed retention settings for pipelines in a project.
- `Pipelines.ProjectSettings` – Changed a Pipelines setting at project level.
- `Pipelines.ResourceAuthorizedForPipeline` – Authorized a resource (e.g., service connection, environment) for a pipeline.
- `Pipelines.ResourceAuthorizedForProject` – Authorized a resource for a project.
- `Pipelines.ResourceNotAuthorizedForPipeline` – Failed to authorize a resource for a pipeline.
- `Pipelines.ResourceNotAuthorizedForProject` – Failed to authorize a resource for a project.
- `Pipelines.ResourceUnauthorizedForPipeline` – Revoked authorization of a resource for a pipeline.
- `Pipelines.ResourceUnauthorizedForProject` – Revoked authorization of a resource for a project.
- `Pipelines.RunRetained` – Marked a pipeline run to be retained (lease created).
- `Pipelines.RunUnretained` – Removed retention from a pipeline run.
- `Pipelines.VariablesSetAtRuntime` – Detected variables set at queue time that aren’t allowed by policy.
- `CheckConfiguration.ApprovalCheckOrderChanged` – Changed order/type of an approval check on a resource.
- `CheckConfiguration.Created` – Added a check (e.g., approval, branch control) to a resource.
- `CheckConfiguration.Deleted` – Removed a check from a resource.
- `CheckConfiguration.Disabled` – Disabled a check on a resource.
- `CheckConfiguration.Enabled` – Enabled a check on a resource.
- `CheckConfiguration.Updated` – Updated a check configuration on a resource.

## Policy events

- `Policy.PolicyConfigCreated` – Created a branch policy (e.g., required reviewers, build validation).
- `Policy.PolicyConfigModified` – Modified a branch policy.
- `Policy.PolicyConfigRemoved` – Removed a branch policy.

## Process events (Azure Boards process customization)

- `Process.Behavior.Add` – Added a portfolio backlog behavior to a work item type.
- `Process.Behavior.Create` – Created a portfolio backlog in a process.
- `Process.Behavior.Delete` – Deleted a portfolio backlog from a process.
- `Process.Behavior.Edit` – Edited a portfolio backlog in a process.
- `Process.Behavior.Remove` – Removed a portfolio backlog behavior from a work item type.
- `Process.Behavior.Update` – Updated a portfolio backlog behavior for a work item type.
- `Process.Control.Create` – Created a control (field group) on a work item form.
- `Process.Control.CreateWithoutLabel` – Created a control without a label.
- `Process.Control.Delete` – Deleted a control from a work item form.
- `Process.Control.Update` – Updated a control on a work item form.
- `Process.Control.UpdateWithoutLabel` – Updated a control without a label.
- `Process.Field.Add` – Added a field to a work item type.
- `Process.Field.Create` – Created a field in a process.
- `Process.Field.Delete` – Deleted a field.
- `Process.Field.Edit` – Edited a field in a process.
- `Process.Field.Remove` – Removed a field from a work item type.
- `Process.Field.Update` – Updated a field in a work item type.
- `Process.Group.Add` – Added a field group to a work item type.
- `Process.Group.Update` – Updated a field group on a work item type.
- `Process.List.Create` – Created a picklist (dropdown list).
- `Process.List.Delete` – Deleted a picklist.
- `Process.List.ListAddValue` – Added a value to a picklist.
- `Process.List.ListRemoveValue` – Removed a value from a picklist.
- `Process.List.Update` – Updated a picklist.
- `Process.Page.Add` – Added a tab/page to a work item type.
- `Process.Page.Delete` – Deleted a tab/page from a work item type.
- `Process.Page.Update` – Updated a tab/page on a work item type.
- `Process.Process.CloneXmlToInherited` – Cloned an XML process to an inherited process.
- `Process.Process.Create` – Created an inherited process.
- `Process.Process.Delete` – Marked a process as deleted.
- `Process.Process.Edit` – Edited a process (name or configuration).
- `Process.Process.EditWithoutNewInformation` – Edited a process (unspecified changes).
- `Process.Process.Import` – Imported a new process.
- `Process.Process.MigrateXmlToInherited` – Migrated a project from an XML process to an inherited process.
- `Process.Rule.Add` – Added a rule to a work item type.
- `Process.Rule.Delete` – Deleted a rule from a work item type.
- `Process.Rule.Update` – Updated a rule in a work item type.
- `Process.State.Create` – Added a state to a work item type.
- `Process.State.Delete` – Deleted a state from a work item type.
- `Process.State.Update` – Updated a state in a work item type.
- `Process.SystemControl.Delete` – Deleted a system control from a work item type.
- `Process.SystemControl.Update` – Updated a system control on a work item type.
- `Process.WorkItemType.Create` – Created a new work item type.
- `Process.WorkItemType.Delete` – Deleted a work item type from a process.
- `Process.WorkItemType.Update` – Updated a work item type in a process.

## Project events

- `Project.AreaPath.Create` – Created an area path.
- `Project.AreaPath.Delete` – Deleted an area path.
- `Project.AreaPath.Update` – Updated an area path.
- `Project.CreateCompleted` – Project creation completed successfully.
- `Project.CreateFailed` – Project creation failed.
- `Project.CreateQueued` – Project creation started.
- `Project.DeleteCompleted` – Project deletion (soft/hard) completed.
- `Project.DeleteFailed` – Project deletion failed.
- `Project.DeleteQueued` – Project deletion started.
- `Project.HardDeleteCompleted` – Hard delete of a project completed.
- `Project.HardDeleteFailed` – Hard delete of a project failed.
- `Project.HardDeleteQueued` – Hard delete of a project started.
- `Project.RestoreCompleted` – Project restore completed.
- `Project.RestoreQueued` – Project restore started.
- `Project.SoftDeleteCompleted` – Soft delete of a project completed.
- `Project.SoftDeleteFailed` – Soft delete of a project failed.
- `Project.SoftDeleteQueued` – Soft delete of a project started.
- `Project.UpdateRenameCompleted` – Project rename completed.
- `Project.UpdateRenameQueued` – Project rename started.
- `Project.UpdateVisibilityCompleted` – Project visibility change completed.
- `Project.UpdateVisibilityQueued` – Project visibility change started.
- `Project.IterationPath.Create` – Created an iteration path.
- `Project.IterationPath.Update` – Updated an iteration path.
- `Project.IterationPath.Delete` – Deleted an iteration path.
- `Project.Process.Modify` – Changed the process of a project.
- `Project.Process.ModifyWithoutOldProcess` – Changed the process of a project (without old process info).

## Release events (classic Release Pipelines)

- `Release.ApprovalCompleted` – Completed an approval on a release stage.
- `Release.ApprovalsCompleted` – Completed multiple approvals on a release.
- `Release.DeploymentCompleted` – Completed a deployment of a release to a stage.
- `Release.DeploymentsCompleted` – Completed multiple stage deployments of a release.
- `Release.ReleaseCreated` – Created a release.
- `Release.ReleaseDeleted` – Deleted a release.
- `Release.ReleasePipelineCreated` – Created a release pipeline.
- `Release.ReleasePipelineDeleted` – Deleted a release pipeline.
- `Release.ReleasePipelineModified` – Modified a release pipeline.

## Service hook events

- `ServiceHooks.SubscriptionCreated` – Created a service hook subscription (webhook).
- `ServiceHooks.SubscriptionModified` – Modified a service hook subscription.
- `ServiceHooks.SubscriptionDeleted` – Deleted a service hook subscription.
- `ServiceHooks.SubscriptionStatusChanged` – Changed the status (enabled/disabled) of a service hook.


## Security events

- `Security.ChangeInheritance` – Changed permission inheritance on a security namespace.
- `Security.ModifyAccessControlLists` – Modified ACL entries (permissions) for a token.
- `Security.ModifyPermission` – Changed a specific permission for a user/group.
- `Security.RemoveAccessControlLists` – Removed all ACLs on specified tokens/namespaces.
- `Security.RemoveAllAccessControlLists` – Removed all ACLs globally (admin action).
- `Security.RemoveIdentityACEs` – Removed an identity’s access control entries.
- `Security.RemovePermission` – Removed all permissions for identities on a namespace/token.
- `Security.ResetAccessControlLists` – Reset ACLs to default on a namespace/token.
- `Security.ResetPermission` – Reset all permissions for a user/group to defaults.

---

## Token events

- `Token.PatCreateEvent` – Created a Personal Access Token (PAT).
- `Token.PatExpiredEvent` – A PAT expired.
- `Token.PatPublicDiscoveryEvent` – A PAT was discovered in a public repo.
- `Token.PatRevokeEvent` – Revoked a PAT.
- `Token.PatSystemRevokeEvent` – System revoked a PAT (e.g., leak detection).
- `Token.PatUpdateEvent` – Updated a PAT (e.g., scopes, expiration).
- `Token.SshCreateEvent` – Created an SSH key.
- `Token.SshRevokeEvent` – Revoked an SSH key.
- `Token.SshUpdateEvent` – Updated an SSH key.