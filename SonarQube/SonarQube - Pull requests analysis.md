#SONARQUBE 
# SonarQube - Pull Requests analysis

SonarQube[^1] can analyze the pull requests when its opened and each time a change is pushed into the pull request branch. 

The **Pull Requests analysis** must be integrated into a CI pipeline to follow this workflow: 
1. The pull request source branch executes the CI pipeline. 
2. The CI pipeline fetches the source branch that must contain valid `.git` to check the branches and pull requests. 
3. The results of the CI pipeline's SonarQube analysis must be published into Pull Request and condition the Pull Request resolution. 

This analysis must be integrated in a CI pipeline: 

## Azure DevOps

After developing new code, the pull request is created to incorporate this development into the main branch. 

To add a SonarQube analysis to analyze the new code in order to validate that has the enough quality so it can be integrated in the main code, you need to add a **Build Validation Policy** ([[Azure DevOps - Build Validation Policy]]): 

This Build validation policy executes a determined build pipeline that need to success (Pass the Quality Gate[^3])so a Pull request can be completed. 


[^1]: SonarQube is an automated platform for analyzing source code to track the quality state of the code and find bugs, security breaches and other issues. [[SonarQube]]
[^2]: Pull Request [[GITFLOW]]. 
[^3]: Quality Gate [[SonarQube - Quality Gate]]. 