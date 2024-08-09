#UNITY 

## METRICS

For being able to measure the performance and cost of some functions, can be analyzed with BIG O complexity notation. [[BIG O Notation]]

![[big_o_complexity.png]]

Unity shows us this metrics where we can detect: 

* ms time duration of a frame execution in main thread
* FPS (Frames per second) of the game. FPS don't progress linearly. 
* `Batches` num of batched per frame. 

![[unity stats.png]]

### ms or FPS

Take into account when optimizing a game that FPS are not linear. This means that, if we manage to make the game to run 1ms faster: 

* If the game ran at 500 FPS, now runs at 1000 FPS
* If the game ran at 30 fps, now runs at 31 FPS

![[ms-vs-fps-unity-optimization.png]]



## PROFILER 

To access the profiler window hold `Ctr` (Mac use `Command`) and press `7` or from the Unity Editor dropdown window, select Analysis > Profiler.

![UNITY PROFILER](https://connect-prd-cdn.unity.com/20210108/learn/images/7cc7bf24-4e1a-41cd-acb6-1c34d2fef023_image2.png.2000x0x1.png)

To record some metrics of the reading / writing of files in case of save systems, data can be monitorized via: 
* [[MPL_Asset loading metrics]]
