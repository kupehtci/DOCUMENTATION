#SONARQUBE 
# SonarQube Metrics

A **metric** in SonarQube is a rating that describe a certain aspect of the code with a concrete value. 

This value can be represented with: 
* A quantitative value (A count, time or percentage)
* A Qualitative grade (A letter grade from A to E)

SonarQube measures: 

* **Bugs**: count of issues classified as bugs. 
	* Qualitative from A to E depending on the severity of the detected bugs. 
* **Vulnerabilities and security hotspots**: number of security vulnerabilities, security hotspotsm how many hotspots are reviewed. 
	* Qualitative from A to E together with an estimated remediation or patching effort. 
* **Code Smells**: total and on new code representing the maintainability problems detected by the rules. 
	* Quantitative counting the number of code smells detected. 
* **Technical debt**: estimated time to fix all code smells: 
	* **Debt ratio**: 
	* Quantitative as counts the time in workdays and hours to fix all the code smells. 
* **Line coverage**: percentage of executable lines covered by tests and number of uncovered lines: 
	* Quantitative represented with a percentage of the code covered. 
* **Condition / branch coverage**: how many boolean conditions have been evaluated both true and false plus a "coverage" metric combining line and condition coverage, 
* **Test metrics**: number of unit tests, test execution time and test success rate. 
	* Quantitative as it measures the amount of unit test implemented. 
* **Cyclomatic complexity**: how many independent paths exists in the code. 
	* Quantitative as it measures the number of paths per function, file, module or project, 
* **Cognitive complexity**: measure of how hard the control flow is to understand: 
	* This measure is affected by nested branches, complex loops and different levels. 
	* Quantitative as calculates a numerical score that quantifies how difficult is for a developer to understand the control flow of a function or method. 
* **Duplicated lines and blocks**: detects the number of lines and blocks that are detected as copy-and-paste or similarly duplicated. 
	* Quantitative with a percentage of the lines of code that are duplicated. 
* **Lines of code**: non-commented lines of code, total lines and new lines on "new code"
	* Quantitative count of the number of lines for each aspect. 

And as a general sight of the status of the code: 

* **Issue count**: number of issued by type (bug, vulnerability, code smells) and the severity. 
* **Quality gate**