#PostgreSQL 

Numeric data types in PostgreSQL let store numerical data values in 2B, 4B or 8B floating point numbers: 


|Name|Storage Size|Description|Range|
|---|---|---|---|
|`smallint`|2 bytes|small-range integer|-32768 to +32767|
|`integer`|4 bytes|typical choice for integer|-2147483648 to +2147483647|
|`bigint`|8 bytes|large-range integer|-9223372036854775808 to +9223372036854775807|
|`decimal`|variable|user-specified precision, exact|up to 131072 digits before the decimal point; up to 16383 digits after the decimal point|
|`numeric`|variable|user-specified precision, exact|up to 131072 digits before the decimal point; up to 16383 digits after the decimal point|
|`real`|4 bytes|variable-precision, inexact|6 decimal digits precision|
|`double precision`|8 bytes|variable-precision, inexact|15 decimal digits precision|
|`smallserial`|2 bytes|small autoincrementing integer|1 to 32767|
|`serial`|4 bytes|autoincrementing integer|1 to 2147483647|
|`bigserial`|8 bytes|large autoincrementing integer|1 to 9223372036854775807|

### INTEGERS

`smallint`, `integer` and `bigint` store whole numbers, without fractional part. Introducing a floating numerical value would lead into an error. 


### NUMERIC

Numeric precision can be user-defined with two values, `precision` and `scale`. 

```PostgreSQL
NUMERIC(precision, scale)
```

* `precision` is the whole count of numbers, taking into account both sides of the decimal point. 
* `scale` is the count of digits in the decimal part, at the right-side of the decimal point. 

##### CONSIDERATIONS: 

* Without specifying the `scale`, its by default 0 and without specifying both of the attributes, creates an unconstrained decimal value. 

* If the stored number has a higher scale than the specified, system would round it to the specified number of fractional digits. 


