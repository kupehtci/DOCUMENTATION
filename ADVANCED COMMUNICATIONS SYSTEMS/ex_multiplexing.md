#CONCEPTS 

# MULTIPLEXING Exercises

This are some exercises about multiplexing: 

##### Time division Multiplexing

1. If you want to transmit by a TDM channel 4 different signals of 10KHz bandwidth each one with 16bits sample depth. Describe the schema TDM to use and the necessary capacity for the communication channel that must be used. 

Using the [[Multiplexing]] Time Division Multiplexing mathematical concepts we can ensure that: 

* The capacity of a single signal, because its analogical its: 

$$C_i = 2 * B_i(Hz) * depth(bits)$$
So the capacity of a single channel is: 

$C_i = 2 * 10 KHz * 16 bits = 320 kbps$

So the total capacity of the channel is the sum of all the capacity necessary of each signal. There is going to be 4 signals in the same channel so: 

$C_{channel} = C_1 + C_2 + C_3 + C_4 = 320kbps * 4 = 1280 kbps$ 

This means that the channel needs to be able to transmit at least 1280 kilobytes per each second in order to send all the data on time. 

---

2. We want to transmit 11 signals through a TDM channel of the following nature:
	
	- **m1(t)**: Analog signal with a bandwidth of 2kHz
	- **m2(t)**: Analog signal with a bandwidth of 4kHz
	- **m3(t)**: Analog signal with a bandwidth of 2kHz
	- **m4(t) .. m11(t)**: Digital signals with a bit rate of 8kbps

The signals will be sampled with a depth of 4 bits.  
Describe the TDM scheme to be used and calculate the necessary capacity of the communication channel.


### Frequency division multiplexing

1. We want to transmit 3 audio signals in the spectrum between 300Hz and 3400Hz, using carrier signals starting at 64kHz.  

Describe the FDM scheme to be used, indicating the carrier frequencies and the total bandwidth used.

%%TODO%%



