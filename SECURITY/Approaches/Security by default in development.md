#SECURITY 

# Security by default in development

In security by default its a development approach that establishes that an application or a information system must be secure from the moment that is installed or used the first time. 
The application is delivered with appropriate configurations for minimizing security risks without manual adjustments. 

This is a "checklist" to ensure that an application mets the security by default approach:
* An SAST analysis is executed in each application deployment to production: 
	* in systems like SonarQube ([[SonarQube]]) an SAST analysis over the application must ensure that it mets the quality gate and has a high ratting. 
* The application implements solutions for avoiding brute force attacks over the available endpoints. 
* Access and authorization: 
	* Under an incorrect logging the application must only display generic error messages: 
		* Do not show if the username or password is the one that failed, as can be useful for attackers. 
	* User sessions expiration its defined under the application base and cannot be modified by the user. 
	* Cookies generation its made randomly and cannot be reproduced. 
	* Under important changes in the application / data like the user credentials, the original credentials must be asked again to avoid credentials steal. 
	* No session related information is kept within the web browser cache. 
* Injection: 
	* The user input must be filtered avoiding incorrect / malicious behavior of the application. 
	* The user inputs and application are protected against SQL Injection. 
	* Code Injection:
		* Tested character injection. 
		* Tested value injection in URI. 
		* Verified that the input is properly sanitized and validated. 
	* SQL Injection: 
		* Tested with standard SQL injection patterns.
		* Tested with UNION operator attacks. 
		* Tested blind SQL injection vulnerabilities.

* Logging: 
	* Under error and exceptions, the error messages must be generic and don't show information that can be useful for determining the inner of the application. 
	* Logs must be protected within the application environments or in an external application like GrayLog, or ELK. 
	* Successful or incorrect login must be logged. 
	* Error prompts must be logged and reviewed. 
* Communications: 
	* A protected channel must be used for communication between client and server. 
	* A protected channel must be used for communication between frontend-backend or client-backend. 
* Common checks: 
	* Verified that the application has no memory leak
	* Verified that the application has no free storage problems. 
	* Verified that the application has no errors while freeing the connections with Database. 
* Endpoints (backend): 
	* Check GET requests with excessive length
	* Verified that operation invocations do not expose sensitive information. 
	* Check that authorization needed endpoints return 401 over non-authenticated requests. 
* Session management: 
	* Verified that session management is not vulnerable (variable tokens in all requests)
	* Verified secure token generation and rotation
	* Verified proper session timeout implementation. 
* Cross Site Scripting (XSS): 
	* Tested vulnerabilities attempting to exploit them. 
	* Identified and analyzed areas where the code can be dynamically written into the page. 
	* Identifies and analyzed areas where the DOM is modified. 
	* Verified proper output encoding and sanitization. 
* CSRF Protection: 
	* Verified anti-CSRF tokens are implemented on state-changing opertions
	* Verified SameSite cookies attributes are properly configured. 
* Security Headers: 
	* Verified implementation of Content-Security-Policy (CSP). 
	* Verified X-Frame-Options header to prevent clickjacking. 
	* Verified X-Content-Type-Options is set to nosniff. 
	* Verified Strict-Transport-Security (HSTS) header is configured. 
* Dependencies and libraries: 
	* Verified no known vulnerabilities exist in dependencies 
		* SCA analysis is performed before each application deployment to production: 
		* Using systems like Trivy ([[Trivy]]) you can perform an SCA analysis over the application dependencies. 
	* Verified all third-party libraries are up to date. 
	* Verified removal of unused dependencies. 