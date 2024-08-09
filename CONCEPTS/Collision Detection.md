#CONCEPTS #CSHARP 

Collision can be calculated between two game object by two different types

### Discrete collision detection

During the detection, object might be sampling for example, every 0.1 seconds, at its movement speed. 


### Continuous Collision Detection

During the detection, every object movement is calculated in order to find the accurate time of contact.

efficient solution for accelerating collision detection checks in massive environments (Bergen, 2004). According to (Bergen, 2004) for n objects there are:
![[Captura de pantalla 2023-12-21 a las 11.43.17.png]]
potentially collided pairs. There are two types of spatial data structures being used for collision detection: spatial division and BVH



For optimizing collision detection, each object cannot be compared with each other object in the scene. 