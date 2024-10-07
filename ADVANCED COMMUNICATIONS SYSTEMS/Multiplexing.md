#CONCEPTS 

# MULTIPLEXING

Multiplexing consist in sending various signals within the same channel.  

You can multiplex in various forms: 

* (MDT) Multiplex in time: sending one signal after another, for example, a time span of 1 second for sending each signal. 
* (MDF) Frequency multiplex: you send all the signals at the same time but each one in a different frequency. 
* Multiplex by code: By code, mix the signals and in the receiver, decompose all by identifying the correspondent code of the desired signal. 


### Time division multiplexing

Its divided in various time spans or slots and each slot of time, transmit a signal $m_i(t)$ using all the bandwidth available in the channel. 

The slots usually is 1B. 

Its synchronized by measuring the start of each slot by an start byte or an slot header. 

The slots can be occupied or in case that is not necessary to send data, the slot will be empty but will ocupe the slot. 

Its necessary a buffer per each signal in order to receive the information and reconstruct it $buffer\ size = slot\ size$

Being: 
* $m_1(t)$, $m_2(t)$, ...., $m_n(t)$
* $C_1$, $C_2$, ...$C_n$ = Capacity in $bps$ of each signal. 
	* Digital signals --> $C_i$ (bps)
	* Analogic signals --> $C_i = 2 * B_i(Hz) * depth(bits)$

* $C_{channel}$ = $C_1 + C_2 + C_3 + .... + C_n$ The capacity of the whole channel is the sumatory of all the capacity of each signal sent. 
* $T_{bit}=1/C_{channel}$


### Frequency division multiplexing

Multiplexing using the frequency consist in splitting the bandwidth of a channel between all the signals to send. 

For doing so, the bandwidth of the channel needs to be at least the sum of all the bandwidths of the signals. 

$B_{channel} >= \sum_{x = 1}^{n}B_x$ with x = signal 1, 2, ... n

Each signal has a Bandwidth slot for sending the data during all the time. 

Each signal $m_1(t), m_2(t), ...., m_n(t)$ is modulated with a different carrier. 

The assign of each bandwidth can be permanent or being provisioned dynamically. 

$$s(t) = m_i(t)*cos(2 \pi f_c t)$$
With: 
* $m_i(t)$ signal to be modulated. 
* $f_c$ the frequency of the carrier signal
* $s(t)$ will be the resulting signal

WDM or Wavelength Division Multiplexing is the same as frequency modulation but when the frequency its so high, the wave and the frequency of the signal its measured by its wavelength. 


### Multiple access

When multiple signals from various sources need to be grouped and send into the same channel, we talk about multiple access multiplexing: 
* FDMA
* TDMA
* CDMA
* WDMA


