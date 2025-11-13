
Work with authentication methods:

| Command                        | Purpose                                                     |
| :----------------------------- | ----------------------------------------------------------- |
| `vault auth list`              | List all available authentication methods                   |
| `vault auth list -detailed`    | List all available authentication methods with more details |
| `vault auth list -format=json` | List all available authentication methods with JSON format  |
|                                |                                                             |

Use `-format=json` for getting Authentication method's accessors that are needed for creating entity aliases. 

For interacting with vault's roles from the AppRole Authentication method you can use the following command, supposing you have an enabled AppRole with "approle" name: 

Path: `/auth/{METHOD-NAME}/role/{[OPT]ROLE-NAME}`

| Command                                                                              | Purpose                                                                            |
| :----------------------------------------------------------------------------------- | ---------------------------------------------------------------------------------- |
| `vault list /auth/approle/role`                                                      | List all declared roles                                                            |
| `vault read /auth/approle/role/{ROLE-NAME}`                                          | Get metadata from a single role                                                    |
| `vault write auth/approle/role/{ROLE-NAME} \ token_policies="policy-one,policy-two"` | Create a role under "approle" with `{ROLE-NAME}` name and policies attached to it. |
| `vault read auth/approle/role/{ROLE-NAME}/role-id`                                   | Get the `role_id` from a role.                                                     |
| `vault write -f auth/approle/role/{ROLE-NAME}/secret-id`                             | Create a new `secret_id` for the role and retrieve it.                             |
| ```<br>vault write auth/approle/login role_id={ROLE-ID} secret_id={SECRET-ID}<br>``` | Login with an AppRole's role using the `role_id` and `secret_id`.                  |
|                                                                                      |                                                                                    |

Take into account that `write` command has an -f as force, meaning that won't prompt requesting an input, it will create the `secret_id` itself and prompt it.

| Command                                          | Purpose                                        |
| :----------------------------------------------- | ---------------------------------------------- |
| `vault read identity/entity/name/`               |                                                |
| `vault read /identity/entity/name/{entity-name}` | Get information about a certain entity by name |
| `vault read identity/entity/id/{entity-id}`      | Get information about a certain entity by id   |
|                                                  |                                                |

Work with aliases: 

| Command                                            | Purpose                              |
| :------------------------------------------------- | ------------------------------------ |
| `vault list identity/entity-alias`                 | List all aliases                     |
|                                                    |                                      |
| `vault write identity/entity name="{ENTITY-NAME}"` | Create an entity with a certain name |
|                                                    |                                      |
