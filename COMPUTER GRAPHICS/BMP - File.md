Short for <span style="color:#ababf5;">bitmap image file</span>. 
BMP images are device independent and require no graphics adapter to display them. Image data in BMP files are usually <span style="color:orange;">uncompressed or barely compressed</span> with a lossless compression.
## BMP File structure

This is the structure of the file header: 

![[bmp-structure.jpg]]


  

|Structure name|Optional|Size|Purpose|Comments|
|---|---|---|---|---|
|Bitmap file header|No|14 bytes|To store general information about the bitmap image file|Not needed after the file is loaded in memory|
|DIB header|No|Fixed-size   <br>(7 different versions exist)|To store detailed information about the bitmap image and define the pixel format|Immediately follows the Bitmap file header|
|Extra bit masks|Yes|3 or 4 DWORDS|   <br>(12 or 16 bytes)|To define the pixel format|Present only in case the DIB header is the BITMAPINFOHEADER and the Compression Method member is set to either BI_BITFIELDS or BI_ALPHABITFIELDS|
|Color table|Semi-optional|Variable size|To define colors used by the bitmap image data (Pixel array)|Mandatory for [color depths](https://en.wikipedia.org/wiki/Color_depth "Color depth") ≤ 8 bits|
|Gap1|Yes|Variable size|Structure alignment|An artifact of the File offset to Pixel array in the Bitmap file header|
|Pixel array|No|Variable size|To define the actual values of the pixels|The pixel format is defined by the DIB header or Extra bit masks. Each row in the Pixel array is padded to a multiple of 4 bytes in size|
|Gap2|Yes|Variable size|Structure alignment|An artifact of the ICC profile data offset field in the DIB header|
|ICC color profile|Yes|Variable size|To define the color profile for color management|Can also contain a path to an external file containing the color profile. When loaded in memory as "non-packed DIB", it is located between the color table and Gap1.[[7]](https://en.wikipedia.org/wiki/BMP_file_format#cite_note-DIBHeaderTypes-7)|


### Calculate size of a row



![[Captura de pantalla 2023-12-19 a las 17.40.08.png]]

The necessary number of bytes necesary to store an array of pixels in a <span style="color:orange;">n</span> bits per pixel (bpp),  can be calculated by accounting for the effect of rounding up the size of each row to a multiple of 4 bytes. 

![[Captura de pantalla 2023-12-19 a las 17.40.21.png]]