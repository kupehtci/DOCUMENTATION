#NETWORKING #CONCEPTS 

In order to transform from a IEE 802 48-bits MAC address to a EUI-64 format, there are some basic steps to transform it: 

Image Router R1 has a MAC address of 0015.2BE4.9B60 on its Fa 0/0 interface. 
The purpose is to calculate the corresponding EUI-64

1. Split the MAC address in the middle:
```
0015.2B   E4.9B60
```

2. Insert FF:FE in the middle:
```
0015.2BFF.FEE4.9B60
```

3. Change the format to use a colon delimiter:
```
0015:2BFF:FEE4:9B60
```

4. Convert the first eight bits to binary:
```
00 -> 00000000
```

5. Flip the 7th bit to mark as 
* u=1 => global unique 
* u=0 => local scope
```
00000000 -> 00000010
```

6. Convert these first eight bits back into hex:
```
00000010 -> 02, which yields an EUI-64 address of 0215:2BFF:FEE4:9B60
```