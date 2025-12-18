#APACHE

# Apache Parquet

**Apache Parquet** is an open-source column-based data file format designed for an efficient storage and fast analytical reads. 

Its commonly used in data lakes and big-data ecosystems such as Hadoop, Apache Spark and Hive. 

It has the following characteristics: 
* Column orientes layout designed for engines like SQL read only the needed columns for a query, improving performance. 
* Built-in compression and data encoding for shrinking storage. 
* Its self-describing, including the schema in the metadata. 


In comparison with CSV and JSON that are row-based formats, Parquet is oriented in columns so avoid reading unused columns. 


## Usage

The easiest way to write into an Apache Parquet file is using python (Pandas library):

```python
import pandas as pd

df = pd.DataFrame({"Name":["Daniel","Marta"], "Age":[25,22]})

df.to_parquet("data.parquet", engine="pyarrow", index=False)
```


Or in .Net framework using `Parquet.NET` package: 
```cs
using Parquet;
using Parquet.Data;

var idField = new DataField<int>("Id");
var nameField = new DataField<string>("Name");
var schema = new Schema(idField, nameField);

var id = new DataColumn(idField, new[] { 1, 2, 3 });
var name = new DataColumn(nameField, new[] { "Alice", "Bob", "Charlie" });

using var fs = System.IO.File.Create("people.parquet");
using var writer = await ParquetWriter.CreateAsync(schema, fs);
using (var rowGroup = writer.CreateRowGroup())
{
    await rowGroup.WriteColumnAsync(id);
    await rowGroup.WriteColumnAsync(name);
}
```

In the code you can see that data is written using Row groups that has columns groups of data, conforming this column-based storage. 