#SoftwareQuality 


##### Serial System Reliability

1. In a software system composed by different serial software components, a failure of any component, results in failure for the entire system. In other words, all the components involved in the software must succeed for the system to succeed.  
Imagine a serial system composed by three different serial software components.

We know that the errors follow an exponential distribution, that the components are not correlated (errors in one component do not depend on other component errors) and that the error rates for every software module are:

- Component 1: $λ_1$ = 0.0001 errors/hour
- Component 2: $λ_2$ = 0.0002 errors/hour
- Component 3: $λ_3$ = 0.0005 errors/hour

1.a. Calculate the reliability for 100 hours of each module: 
$$R_n(t) = e^{-λ_n*t}$$
* $R_1(t) = e^{-λ_1*t}$ --> $R_1(100) = e^{-0.0001*100} = e^{-0.01} = 0.99$  
* $R_2(t) = e^{-λ_2*t}$ --> $R_2(100) = e^{-0.0002*100} = e^{-0.02} = 0.98$
* $R_3(t) = e^{-λ_3*t}$ --> $R_3(100) = e^{-0.0005*100} = e^{-0.05} = 0.95$  

1.b. Calculate the reliability of the whole system for 100 hours taking into consideration that the system's modules follows a serial distribution. 

$R_S(100) = \prod_{n = 1}^{3} R_n(100)$ = $R_S(100) = R_1(100) * R_2(100) * R_3(100) = 0.99 * 0.98 * 0.95 = 0.92$

1.b. Calculate the error rate of the whole system: 

$Rs(100) = 0.92 = e^{-100 * \lambda_S}$
$ln(0.92) = -100 * \lambda_S$
##### Defect Density per module

6. Company X runs a large software system S that has been developed in-house over a number of years. The company collects information about software defects discovered by users of S. During the regular maintenance cycle, each defect is traced to one of the nine subsystems of S (labeled with letters A through I), each of which is the responsibility of a different team of programmers. The following table summarizes information about new defects discovered during the current year:

| System      | A   | B   | C   | D   | E   | F   | G   | H   | I   |
| ----------- | --- | --- | --- | --- | --- | --- | --- | --- | --- |
| Defects     | 35  | 0   | 95  | 35  | 55  | 40  | 55  | 40  | 45  |
| Size (KLOC) | 40  | 100 | 5   | 50  | 120 | 70  | 60  | 100 | 40  |

Compute the defect density for each subsystem: 

| System         | A     | B   | C   | D   | E    | F    | G    | H   | I     |
| -------------- | ----- | --- | --- | --- | ---- | ---- | ---- | --- | ----- |
| Defect Density | 0.875 | 0   | 19  | 0.7 | 0.45 | 0.57 | 0.91 | 0.4 | 1.125 |
