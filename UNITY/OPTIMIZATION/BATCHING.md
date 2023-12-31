
<h2 style="color:#77eff7;">BATCHING</h2>


Needs to be static: 

> <span style="color:orange;text-decoration:underline;">Static</span> means that its transform position is static. This means that being static, can be moved via <span style="color:orange;">shaders</span>


<h3 style="color:#b8f59a;">STATIC BATCHING</h3>

Take a look into: [[UNITY - BATCHING]]

<h3 style="color:#b8f59a;">DYNAMIC BATCHING</h3>
The same as static batching but using CPU. 

It has the advantage of allowing  moving meshes to be combined. 

Is only an optimization if the transformation work is <span style="color:#ababf5; ">less work </span>


<h5 style="color:#b8f59a;">DYNAMIC BATCHING FOR DYNAMIC GENERATED GEOMETRIES</h5>

A particle system usually consumes one draw call because of this. 
Unity uses dynamic batching for: 
* Buil-in Particle Systems. 
* Line Renderers
* Trail Renderers

