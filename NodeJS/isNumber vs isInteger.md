#NodeJS #TypeScript 


# isNumber vs isInteger

The difference between `isNumber` and `isInteger` lies in the types of values they validate and the conditions under which they return `true`.

### 1. `isNumber`

- **Definition**: Determines if a value is of type `number`.
- **Usage**: Checks if the value is a valid JavaScript number, including integers and floating-point numbers.
- **Returns `true` for**:
    - Both integers and floating-point numbers.
    - Positive and negative numbers.
    - Special numbers like `Infinity` and `NaN` (because they are technically of type `number`).
- **Returns `false` for**:
    - Non-numeric types (e.g., `string`, `object`, `null`, `undefined`, etc.).

Example with `_.isNumber` (from Lodash):
```ts
_.isNumber(123);      // true (integer)
_.isNumber(3.14);     // true (float)
_.isNumber(NaN);      // true
_.isNumber(Infinity); // true
_.isNumber('123');    // false (string)
_.isNumber(null);     // false
```

---

### 2. `isInteger`

- **Definition**: Determines if a value is an integer.
- **Usage**: Checks if the value is a whole number (i.e., no decimal places).
- **Returns `true` for**:
    - Whole numbers (both positive and negative).
- **Returns `false` for**:
    - Floating-point numbers.
    - Special numbers like `NaN` or `Infinity`.
    - Non-numeric types.

Example with `Number.isInteger` (native JavaScript):

```ts
_.isNumber(123);      // true (integer)
_.isNumber(3.14);     // true (float)
_.isNumber(NaN);      // true
_.isNumber(Infinity); // true
_.isNumber('123');    // false (string)
_.isNumber(null);     // false
```

---

### Key Differences

| Feature                                     | `isNumber`                                                                 | `isInteger`                                      |
| ------------------------------------------- | -------------------------------------------------------------------------- | ------------------------------------------------ |
| **Scope**                                   | Checks if the value is a number (including floats, `NaN`, and `Infinity`). | Checks if the value is a whole number (integer). |
| **Returns `true` for floats**               | ✅ Yes                                                                      | ❌ No                                             |
| **Returns `true` for `NaN` and `Infinity`** | ✅ Yes                                                                      | ❌ No                                             |
| **Common Use Case**                         | General numeric checks.                                                    | Ensuring the value is a whole number.            |