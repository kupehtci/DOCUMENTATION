#CMAKE 


### `CMAKE_SYSTEM`

This variable is the composite of [`CMAKE_SYSTEM_NAME`](https://cmake.org/cmake/help/latest/variable/CMAKE_SYSTEM_NAME.html#variable:CMAKE_SYSTEM_NAME "CMAKE_SYSTEM_NAME") and [`CMAKE_SYSTEM_VERSION`](https://cmake.org/cmake/help/latest/variable/CMAKE_SYSTEM_VERSION.html#variable:CMAKE_SYSTEM_VERSION "CMAKE_SYSTEM_VERSION"), e.g.`${CMAKE_SYSTEM_NAME}-${CMAKE_SYSTEM_VERSION}`. If `CMAKE_SYSTEM_VERSION` is not set, then this variable is the same as `CMAKE_SYSTEM_NAME`.