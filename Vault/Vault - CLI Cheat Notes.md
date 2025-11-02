
Work with authentication methods:

| Command                        | Purpose                                                     |
| :----------------------------- | ----------------------------------------------------------- |
| `vault auth list`              | List all available authentication methods                   |
| `vault auth list -detailed`    | List all available authentication methods with more details |
| `vault auth list -format=json` | List all available authentication methods with JSON format  |

Use `-format=json` for getting Authentication method's accessors that are needed for creating entity aliases. 

| Command                                          | Purpose                                        |
| :----------------------------------------------- | ---------------------------------------------- |
| `vailt read identity/entity/name/`               |                                                |
| `vault read /identity/entity/name/<entity-name>` | Get information about a certain entity by name |
| `vault read identity/entity/id/<entity-id>`      | Get information about a certain entity by id   |

Work with aliases: 

| Command                            | Purpose          |
| :--------------------------------- | ---------------- |
| `vault list identity/entity-alias` | List all aliases |
