#SONARQUBE 

# SonarQube - SCM

SonarQube integrates with the project's SCM[^1] (normally [[GIT]]) to collect **blame** information (author and last commit date of each line) during the analysis. 

This information is used to: 
* Attribute each issue found to the developer who introduced it (issue assignment). 
* Compute the **new code** period, comparing changed lines against a reference branch or a previous version, so metrics like new bugs, new coverage or new duplications can be tracked independently from the rest of the code. 
* Show the last commit author and date when browsing the source code in the SonarQube UI. 

## Requirements

* The analysis must be executed from a valid SCM working copy, i.e. a full clone containing the `.git` folder (or equivalent for other SCMs). Shallow clones (`--depth 1`) can prevent the scanner from retrieving the full blame history. 
* CI/CD pipelines must checkout the repository with enough history, not only the last commit, for the blame data to be complete. 

## Configuration

| Property                    | Description                                                                                        | Example |
| ----------------------------- | ------------------------------------------------------------------------------------------------------- | --------- |
| `sonar.scm.provider`         | Forces the SCM provider to use instead of letting the scanner auto-detect it from the project structure. | `git`  |
| `sonar.scm.disabled`         | `true` \| `false`. Disables the SCM sensor entirely, so no blame information is collected (faster analysis, but no issue attribution or accurate new code detection). | `false` |
| `sonar.scm.forceReloadAll`   | `true` \| `false`. Forces reloading the blame data for every file instead of only the files changed since the last analysis. Useful to fix inconsistent blame data, at the cost of a slower analysis. | `false` |
| `sonar.scm.exclusions.disabled` | `true` \| `false`. Ignores `sonar.scm.exclusions` (the SCM's own ignore file, e.g. `.gitignore`) when computing the files to analyze. | `false` |

## Supported providers

The scanner ships with SCM support for [[GIT]] and SVN out of the box. Other SCMs require a dedicated SonarQube plugin. 

[^1]: SCM or Source Control Management [[SCM - Source Control Management]]. 
