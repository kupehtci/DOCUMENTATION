#UNITY #CSHARP 

### How Basic rendering works

Take a single mesh. Upload mesh data to the GPU once at startup. Every frame set the shader to use, upload all of the material data, and call Draw(). Rinse and repeat for every object. Benefits: Works on literally every GPU ever made, and is extremely flexible. Unity does some work to try to not change the shader or material data if it doesn't have to, so if two meshes use the exact same material & shader variant it'll sometimes only update the position data and render those meshes one after another.