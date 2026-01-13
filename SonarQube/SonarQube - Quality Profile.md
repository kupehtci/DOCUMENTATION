#SONARQUBE 

# SonarQube - Quality Profile

A **SonarQube quality profile** is a set of coding rules that SonarQube applies to the analysis to ensure the quality. 

This **rules** are language specific and define the rules that are checked on the project when its analyzed. When a project is analyzed, SonarQube detects automatically the language and applies the corresponding Quality Profile. 

You can also create **custom quality profiles** that define: 
* Which rules are active and inactive
* Severity levels applied to each rule. 
* Configurable rule parameters like thresholds. 
* Prioritized rules that can cause a **quality gate**([[SonarQube - Quality Gate]]) to fail


