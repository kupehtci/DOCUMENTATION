#SONARQUBE 

# SonarQube - API REST




## Get Quality Gate status

To get the quality gate status of a project, make a GET query to: 

```python
f"www.sonar-url.com/api/qualitygates/project_status?projectKey={project}&branch={branch}"
```

And you will receive a JSON indicating the gate status like this: 
```json
{
	'projectStatus': 	{
		'status': 'OK', 
		'conditions': [], 
		'ignoredConditions': False, 
		'caycStatus': 'non-compliant'
	}
}
```

* `projectStatus.status`: can be `OK` (Passed), `WARN` (Warnings), `ERROR` (Failed) or `NONE` (No gate associated). 
* `projectStatus.conditions`: list of evaluated conditions that failed. None if no condition of the gate failed. Each metric in this list include the actual value and the expected value. 
* `projectStatus.ignoredConditions`: True if some conditions were skipped due to lack of data. 
* `projectStatus.caycStatus`: Compliance with the Clean As You Code (CAYC) standards. Returned values are `compliant` or `non-compliant`. 

