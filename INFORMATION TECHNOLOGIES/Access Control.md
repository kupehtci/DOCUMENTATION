#DATABASES 


### How to manage Access Control

The access control is managed using <span style="color:LightSeaGreen;">DCL (Data Control Language)</span>. 

To be able to manage some simultaneous connections to a database

Depending on the permisions that an user has, it has an <span style="color:orange;">external view</span> different from others. 


Exercise: 


Create an external view so that customers can only access their personal data, and their preferences (Which groups and artists they like). However, they can only see the title and the price of the artworks and the name and style of the artists. 


Using a Relation-ship model, you can define the external view for a certain user: 

```
Artworks (title, year, price, artistName, idGroup, idCustomer)
Types (idType, type, title)
Artists (artistName, style, birthdate, birthplace)
Groups (idGroup, nameGroup)
Customers (idCustomer, name, street, zipCode, city, country)
Phones (idPhone, phoneNumber, idCustomer)
CustomersLikeArtists (idCustomerArtist, idCustomer, artistName)
CustomersLikeGroups (idCustomerGroup, idCustomer, idGroup)
```

The external view would be: 

```
Artworks (title, price)
Artists (artistName, style)
Groups (idGroup, nameGroup)
Customers (idCustomer, name, street, zipCode, city, country)
Phones (idPhone, phoneNumber, idCustomer*)
CustomersLikeArtists (idCustomerArtist, idCustomer*, artistName*)
CustomersLikeGroups (idCustomerGroup, idCustomer*, idGroup*)
```