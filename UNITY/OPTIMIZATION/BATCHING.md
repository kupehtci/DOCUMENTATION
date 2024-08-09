#COMPUTER_GRAPHICS #UNITY 
<h2 style="color:#77eff7;">BATCHING</h2>


<h3 style="color:#b8f59a;">STATIC BATCHING</h3>

Take different meshes with same material into a single mesh once during build time / play mode startup. 
Upload that data to the GPU once on startup. Set the shader variant & material data for that single material, call DrawIndexed() for each renderer component as an offset & range of triangle indices. Done. Benefits: Very fast on the CPU & GPU, but uses a lot of memory and is, well, static. Is quite flexible in terms of allowing individual renderer components to be hidden for occlusion, LOD, or via script. Unity will also swap the shader variant and data for things like dynamic lights & shadows so only the renderer components that are affected needs to be rendered again rather than the whole batched mesh, but that incurs some cost in doing that swap. Per object data can be stored in the mesh vertex data.


Needs to be static: 

> <span style="color:orange;text-decoration:underline;">Static</span> means that its transform position is static. This means that being static, can be moved via <span style="color:orange;">shaders</span>

Take a look into: [[UNITY - Static Batching]]

<h3 style="color:#b8f59a;">DYNAMIC BATCHING</h3>
The same as static batching but using CPU. 
It has the advantage of allowing  moving meshes to be combined. 
Is only an optimization if the transformation work is <span style="color:#ababf5; ">less work </span>

Take several meshes with very low poly counts and exactly the same material & shader variant and combine into a single mesh, every single update. Send that mesh data to the GPU, set the shader & material data for that single material, call Draw() once. Done. Benefits: Very, very fast on the GPU, even with the cost of uploading a new mesh every frame as it's only rendering a single "thing". Dynamic batching is limited to very simple meshes so this usually isn't a ton of data. Particle systems work like this too. Main cost comes from the CPU combing meshes. Limited per object data can be stored in the mesh vertex data.

<h5 style="color:#b8f59a;">DYNAMIC BATCHING FOR DYNAMIC GENERATED GEOMETRIES</h5>

A particle system usually consumes one draw call because of this. 
Unity uses dynamic batching for: 
* Buil-in Particle Systems. 
* Line Renderers
* Trail Renderers


<h3 style="color:#b8f59a;">SRP BATCHING</h3>

Gather up data from several different meshes with the same shader. Upload mesh data once at startup. Put per-material data into long lists and upload once at startup*. Put per-object data into long lists and upload every frame. Render each mesh by setting the offsets to the list data and using a Draw(). Benefits: Much less data being uploaded between each draw and much less communication between the CPU and GPU. Unlike traditional rendering switching between different sets of material data is essentially free as the data is already uploaded.

