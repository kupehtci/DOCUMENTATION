#CONCEPTS #FILES

# CSV

**CSV** (Comma-Separated Values) is a plain-text, **row-based** format for tabular data: each line is a record, and each field within a line is separated by a delimiter — most commonly a comma.

It's one of the simplest possible data formats, which makes it universally supported (spreadsheets, databases, every programming language) but also the least expressive.

## Syntax basics

```csv
id,name,age,city
1,Daniel,30,Zaragoza
2,Marta,22,Madrid
3,"Smith, John",41,Valencia
```

* The **first line** is conventionally a **header** row naming each column, though this isn't required by any standard.
* Fields are separated by a **delimiter** — a comma by default, but semicolons (`;`) or tabs (**TSV**, tab-separated values) are also common, especially in locales where the comma is used as a decimal separator.
* A field containing the delimiter, a newline, or a quote itself must be wrapped in `"double quotes"`, with any internal quote doubled (`""`).

## Characteristics

* **No native types**: every value is text; the reader has to decide how to parse `"30"` as a number or `"true"` as a boolean.
* **No nesting**: CSV can only represent a flat, two-dimensional table — no objects, arrays, or hierarchical structures like [[YAML]] or JSON support.
* **No embedded schema**: unlike [[Apache Parquet]] or [[Apache Avro]], there is no metadata describing column types, so producers and consumers must agree on the format out of band.
* Extremely portable: virtually every spreadsheet application and data tool can import/export CSV.

## Use cases

* Exporting/importing tabular data between spreadsheets, databases, and scripts.
* Simple data interchange where a full schema isn't needed and human-editability in a text editor or spreadsheet matters.
* Bulk-loading data into a database or data warehouse (often as a first landing format before conversion to something like [[Apache Parquet]] for analytics).

## Related

* [[Apache Parquet]] — a columnar, typed, self-describing alternative used once data needs efficient analytical storage.
* [[JSON - BASICS]] — used instead when the data isn't flat/tabular.
* [[File Extensions]] — the `.csv` extension entry.
