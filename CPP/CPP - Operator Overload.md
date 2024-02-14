#CPP 

<span style="color:orange;">Operator overloading</span> is a compile-time polymorphism. 
Lets you define the meaning or execution of a provided arithmetic operator like \(+, -, *, etc\) for classes defined by programmer. 

The different operator overloads needs to have an specific structure: 

```CPP
Vector2D& operator=(const Vector2D& equal);  
Vector2D operator+(const Vector2D& plus);  
Vector2D operator-(const Vector2D& subs);  
Vector2D operator*(const float& op);
```

### Important points to take into account

* For operator overloading at least one of the operators of the overload need to be a <span style="color:orange;">user-defined class object</span>.
* The <span style="color:orange;">assignment operator</span> is by default created for every class and by default assigns each member of the right operand to the left operand. 

### Operators that can be overloaded

The following operators can be overloaded in c++: 

|Operators that can be overloaded|Examples|
|---|---|
|Binary Arithmetic|+, -, *, /, %|
|Unary Arithmetic|+, -, ++, —|
|Assignment|=, +=,*=, /=,-=, %=|
|Bitwise|& , \| , << , >> , ~ , ^|
|De-referencing|(->)|
|Dynamic memory allocation,  <br>De-allocation|New, delete|
|Subscript|[ ]|
|Function call|()|
|Logical|&,  \| \|, !|
|Relational|>, < , = =, <=, >=|

### Operators that can't be overloaded

The following operators cannot be overloaded: 

* `sizeof()`:  this operator return the size of a object or datatype. 
* `typeid`: used for recovering the derived type of an operator. 
* `::` : scope resolution operator is used for specifying the context of the context refers by a namespace. 

---
### Example

```cpp
class Complex {
private:
    int real, imag;
 
public:
    Complex(int r = 0, int i = 0)
    {
        real = r;
        imag = i;
    }
    void print() { cout << real << " + i" << imag << endl; }
    // The global operator function is made friend of this
    // class so that it can access private members
    friend Complex operator+(Complex const& c1,
                             Complex const& c2);
};

Complex operator+(Complex const& c1, Complex const& c2)
{
    return Complex(c1.real + c2.real, c1.imag + c2.imag);
}
```

