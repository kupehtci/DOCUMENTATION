#CONCEPTS 

# Sampling Theory

Sampling is the process of recording and transform a continuous signal into a discrete signal, taking samples at a certain rate in the time. 

By defining a sampling rate and number of levels of precision of the sample, we can represent this analogical signal into a digital one. 

It has some mathematical key features: 

* $f_m$ in $Hz$ is the sampling frequency or baud rate. Number of samples  taken by second. It must be as high as necessary to avoid losing information.
* $T_m$ or sampling period, its the interval of time between two consecutive samples. Its the inverse of the Sampling frequency

$$T_m = 1/f_m$$
* $n_m$ in bits as the depth of a sample its the size of a sample. This means that has $M = 2^n$
* $C\ or\ BPS$ its the capacity of communication or bit rate. Between two samples, it need to be at least time to transmit the size in bits of the sample. 

$$C(bits/s)=n(bits/sample)/T_m(s/sample)$$
$$C = 2*B*log_2(M)$$
$$f_m = 2*B$$

The sampling theory of Nysquist establishes that sampling rate must be at least the double of the Bandwidth: 

$$f_m >= 2 * B$$