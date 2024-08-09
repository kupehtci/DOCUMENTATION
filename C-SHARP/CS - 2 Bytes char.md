
### 2 BYTES CHAR 


In C\# the size in bytes of a char primitive type is 2 bytes instead of the normal 1 byte like in C or C++.  

This is because a char is unicode in C#, therefore the number of possible characters exceeds 255. So you'll need two bytes.

Extended ASCII for example has a 255-char set, and can therefore be stored in one single byte. That's also the whole purpose of the `System.Text.Encoding` namespace, as different systems can have different charsets, and char sizes. C# can therefore handle one/four/etc. char bytes, but Unicode UTF-16 is default.