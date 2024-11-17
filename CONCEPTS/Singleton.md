
# SINGLETON

Singleton is a creation data pattern that is designed to make sure that a class has an unique instance and give a quick access to that instance. 

It meet two requirements: 

* The class has an unique instance
* The access to that instance is global

It helps to store esential objects that need to be globally accessible at any time and under any circumstance. 

An example in psudocode is: 

```psudo
class Database is
	private static field instance : Database


	private constructor Database() is

	public static method getInstance is
		is(Dabase.instance == null) then
			Database.instance = this; 

		return Database.instance

class Application is
	method main() is
		Database newDB = Database.getInstance()
		newDB.run("SELECT * FROM Users")
	
```

