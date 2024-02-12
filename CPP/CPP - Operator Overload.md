#CPP 

The different operator overloads needs to have an specific structure: 

```CPP
Vector2D& operator=(const Vector2D& equal);  
Vector2D operator+(const Vector2D& plus);  
Vector2D operator-(const Vector2D& subs);  
Vector2D operator*(const float& op);
```