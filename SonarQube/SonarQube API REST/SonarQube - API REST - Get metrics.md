#SONARQUBE 

# SonarQube - API REST - Get metrics

You can get the metrics and other KPIs from a certain scanned project making a GET request to `/api/measures/component` endpoint that accept: 
* `component`: name of the project to retrieve metrics from. 
* `metricKeys`: comma separated list of names of the metrics to retrieve (Check **Metric Keys** section). 
* `additionalFields`: additional fields that want to be returned in the response. 
* `branch`: (Only in Enterprise edition). Select the branch of the project to retrieve the metrics from. 
* `pullRequest`: ID of the pull request to retrieve the metrics from. 

Example: 
```txt
GET https://calidad.mityc.age/api/measures/component?component=DemoProject&metricKeys=reliability_rating, security_rating, sqale_rating,security_review_rating, new_reliability_rating,new_security_rating,new_maintainability_rating,new_security_review_rating
```

## Metric Keys

The available metric keys that you can obtain from a project can be consulted using `/api/metrics/search`. 

This endpoint will list all the metrics and their keys in the API. 

This is a list of the metrics with its key and their meaning in version 25 : 
* **accepted_issues**: Accepted issues  
* **new_technical_debt**: Added Technical Debt  
* **new_software_quality_maintainability_remediation_effort**: Added Technical Debt - Total effort (in minutes) to fix all the maintainability issues on new code  
* **analysis_from_sonarqube_9_4**: Analysis From SonarQube 9.4 - Indicates whether the analysis has been run after SonarQube 9.4 upgrade  
* **high_impact_accepted_issues**: Blocker and High Severity Accepted Issues  
* **blocker_violations**: Blocker Issues  
* **software_quality_blocker_issues**: Blocker Severity Issues  
* **bugs**: Bugs  
* **classes**: Classes  
* **code_smells**: Code Smells  
* **cognitive_complexity**: Cognitive Complexity  
* **comment_lines**: Comment Lines - Number of comment lines  
* **comment_lines_data**: comment_lines_data  
* **comment_lines_density**: Comments (%) - Comments balanced by ncloc + comment lines  
* **branch_coverage**: Condition Coverage  
* **new_branch_coverage**: Condition Coverage on New Code  
* **conditions_to_cover**: Conditions to Cover  
* **new_conditions_to_cover**: Conditions to Cover on New Code  
* **confirmed_issues**: Confirmed Issues  
* **coverage**: Coverage - Coverage by tests  
* **new_coverage**: Coverage on New Code  
* **critical_violations**: Critical Issues  
* **complexity**: Cyclomatic Complexity  
* **last_commit_date**: Date of Last Commit  
* **report**: Dependency-Check Report - Report HTML  
* **development_cost**: Development Cost  
* **new_development_cost**: Development Cost on New Code  
* **duplicated_blocks**: Duplicated Blocks  
* **new_duplicated_blocks**: Duplicated Blocks on New Code  
* **duplicated_files**: Duplicated Files  
* **duplicated_lines**: Duplicated Lines  
* **duplicated_lines_density**: Duplicated Lines (%)  
* **new_duplicated_lines_density**: Duplicated Lines (%) on New Code  
* **new_duplicated_lines**: Duplicated Lines on New Code  
* **duplications_data**: Duplication Details  
* **effort_to_reach_maintainability_rating_a**: Estimated effort to reach Maintainability Rating A  
* **effort_to_reach_software_quality_maintainability_rating_a**: estimated effort to Reach Maintainability Rating A  
* **executable_lines_data**: total number of lines of executable data
* **false_positive_issues**: False Positive Issues  
* **files**: Files - Number of files  
* **functions**: Functions  
* **generated_lines**: Generated Lines  
* **generated_ncloc**: Generated Lines of Code  
* **software_quality_high_issues**: High Severity Issues  
* **high_severity_vulns**: High Severity Vulnerabilities  
* **info_violations**: Info Issues  
* **software_quality_info_issues**: Info Severity Issues  
* **inherited_risk_score**: Inherited Risk Score  
* **violations**: Issues  
* **prioritized_rule_issues**: Issues from prioritized rules  
* **issues_in_sandbox**: Issues in Sandbox  
* **line_coverage**: Line Coverage  
* **new_line_coverage**: Line Coverage on New Code  
* **lines**: Lines  
* **ncloc**: Lines of Code - Non commenting lines of code  
* **ncloc_language_distribution**: Lines of Code Per Language  
* **lines_to_cover**: Lines to Cover  
* **new_lines_to_cover**: Lines to Cover on New Code