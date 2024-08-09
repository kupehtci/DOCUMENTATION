#UNITY #CS 

## PARTICLE SYSTEM

A particle system is a .... TODO 


As particle system act as a component, can be accesed by `GetComponent<>()`. 
```CS
ParticleSystem particleSystem = GetComponent<ParticleSystem>(); 
```

### RESET PARTICLE SYSTEM 

For reset a non-loop particle system, you need to set the time to 0 of the duration of the animation. This will also stop the animation so you need to `Play()` again. 

```CS
particleSystem.time = 0; 
	particleSystem.Play(); //Replay the particle system 
```


### MAIN PROPERTIES

You can get the duration of a non-loop particle system by accessing the `duration` property from main particle system. 

```CS
float psDuration = particleSystem.main.duration; 
```