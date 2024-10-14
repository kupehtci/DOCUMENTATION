

### DESCRIPTION

Therac-25 was a linear accelerator used in hospitals during the 80s to treat cancers. The machine had two possible configurations:

Mode A: Radiate high energy on cells with cáncer without damaging the cells sourrounding them. There was no need to protect the patient in this mode.

Mode B: Radiate X-rays with megavolts power that required filters and special protection to the patients.

People who operated the machine acquired great experience managing the machine and entering the command sequence to start the treatment., which they did very fast.

However, due to a programming bug, if during the process they made a sequence of operations in less than 8 seconds, the machine could use the wrong mode due to a race-condition. Because of this bug 5 people died and tens of them suffered the consequences of being exposed to a high radiation because treatment B was applied instead of mode A.

### QUESTIONS FOR YOU

* Think about the concepts of Bug, Error Situation and Failure in this example.

* Think about some measurements that allow containing the bug in a way that the bug did not lead to a failure or at least the failure consequences were minimized.