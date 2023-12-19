
Data persistence means making data last longer than the process used to create that data. 

You need to make your data <span style="color:#ababf5;">persistent</span> to be able to keep instances between scenes. 

In Unity, data created within a scene is easily available within that scene. 

<div style="background-color:white;
	 border-radius: 0.5rem; color: black; padding: 1rem; 
	  border: 1px solid grey; width: 50%; height: 10rem;display: inline-flex;">SCENE <div style="background-color:cyan;
	 border-radius: 0.5rem; padding: 0.2rem; 
	  border: 1px solid grey; width: 50%;  height: 2rem; margin-top: 4rem; ">DATA</div></div>


But when a user moves to another scene this data is lost. Data persistence between scenes is the process of transferring data from scene to scene to give the user a consistent experience as they progress through your application. In the first two examples above are examples of data persistence between scenes — they are typically one-session experiences that use multiple scenes.


#### STATIC METHODS

Static properties are persistent between scenes, because during the execution there are no instanciation executes by Unity itself. 

Keeping data in a static property maintain it between scenes: 

#### SCRIPTABLE OBJECTS 

Are scriptable objects currently persistent between scenes? 
