#REDIS #DATABASES 

## INITIALIZE REDIS

Firstly, initialize redis server app.

Once is the server initialized, enter `redis-cli` in the command promt in order to initialize redis client:

```
redis-cli
```

Use `select` command to select the database to use and indicate an index: 

```redis
select [index]

Example: 

select 1
```

### SET AND GET A KEY-VALUE PAIR

To store a variable liked to a key use `set <key> <value>`: 

```
set name "Felipe"
```

And in order to retrieve the value stored using the index: 

```
get name ""
```

### LIST 

To <span style="color:MediumSlateBlue;">list the keys</span> that are stored: 
``` 
keys *
```

## TYPE

You can get the type of the value stored under a key by using `type` command: 

```type <key_name>```

```
> hset users user1 daniel
> type users: 
> hash
```


### GET A PART

You can also get a part of a value by using `getrange <key> <low_index> <sup_index>`: 
```
getrange name 2 3
// Result: "li"
```

### REPLACE AN EXISTING VALUE

To <span style="color:MediumSlateBlue;">replace a value</span> that currently exists, we can get and set in same operation: 
This will return the current value and replace with the new one. 
```
getset name "Andrew"
// result: "Felipe"

get name
// result: "Andrew"
```

### MULTIPLE GET

To retreive multiple values combined we can use `mget <index1> <index2> ...`
```
set lastname "Freeman"

mget name lastname
// result: 
// 1) "felipe"
// 2) "Freeman"
```

### DELETE 

An existing a key-value pair, can be deleted by using `del <key>` commmand and would respond with `(integer) 1` if exists and have been currently deleted. 
```
> set score 20
OK
> get score
"20"
> del score
(integer) 1
> get score
(nil)
```
### CHECK IF EXISTS

If we want to set a new key-value pair if doesn't currently exists we can use `setnx <index> <value>`: 
This will return: 
* `(Integer) 0` if currently exists and no changes have been applied to the database
* `(Integer) 1` if doesn't exists and has create the new key-value pair

```
setnx name "Pablo"
// result: (Integer) 0
get name
// result: "Felipe"
```

### SET AN EXPIRATION TIME

You can set a key-value pair with an expiration time (In seconds) . This means that once the expiration time has reached, the tuple is deleted: 

```
setex score 10 
```

### INCREASE A VALUE

A value can be increased without extracting it and modify externaly by using the `incr <key>`

```
set score 10

incr score
// result: (integer) 11
```

Also by using a step, the value can be increased more: 

```
> incrby score 3
(integer) 14
```

### APPEND TEXT

Text can be appended to an existing key-value pair by using `append <key> <value>`. 

This will return the length of the new value stored: 

```
set hello "Hello"
append hello " World"
// result: (integer) 11
get hello
// result: "Hello World"
```

### ARRAY

You can store key-value pairs like in a array or data structure by storing the keys-values under a hash name: 

This is done using: 
* `hset <hash_name> <key> <value>` for inserting a single value under the hash
* `hmset <hash_name> <key1> <value1> <key2> <value2>`  for inserting multiple values

And keep adding using the same `<hash_name>`. 

Also to retrieve the values of the hash-map use `hvals <hash_name>`: 

```
> hmset professor1 name "Daniel" lastname "Freeman"
OK
> hvals professor1
1) "Daniel"
2) "Freeman"
```

To get the <span style="color:MediumSlateBlue;">keys</span> of the hash-map: 

```
127.0.0.1:6379[1]> hkeys professor1
1) "name"
2) "lastname"
```

And get all the key-values, not only the values: 

```
> hgetall professor1
1) "name"
2) "Daniel"
3) "lastname"
4) "Freeman"
```

Increase a hash-map field by using `hincrby`:


## CLEAR

By using `clear` you clean the command prompt: 

```txt
> clear
```

## LISTS USES

You can store a list of values under a key. 

To manipulate this lists you have few commands: 

To **push** a new value to the list`lpush <list_name> <value>" 

Get the **length** of the list by using `llen <list_name>`

Pop a value from left or right of the list: `lpop <list_name>` or `rpop <list_name>`

## FILTER

You can search a key-value pair that meet certain conditions by using `scan _ match` command. 

Because Redis internal structure is like an array of key - values: 

| Position | Key      | Value   |
| -------- | -------- | ------- |
| 0        | name     | Daniel  |
| 1        | lastname | Freeman |
| 2        | score    | 30      |
Redis when doing an scan only search in the firsts 10 values of the array. So if in the first search by using the 0, only will search until 10. 
So for continue searching you need to find using the 11 and so on. 

```
scan 0 match 1

// REGEX
scan 0 match "Dan"*.    // Would search something that starts with "Dan"
1) "0"
2) "Daniel"
```

And search inside a hash: 

```hscan <hash_name> <start_index> match <condition>```

```txt
// Inside a hash
hset users name daniel lastname freeman
``` 
