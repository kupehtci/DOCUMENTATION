#ML #DEEP_LEARNING
### Some Object Detection History (2001-2017)

#### The first efficient Face Detector (Viola-Jones Algorithm, 2001)

- An efficient algorithm for face detection was invented by Paul Viola & Michael Jones
- Their demo showed faces being detected in real time on a webcam feed.
- Was the most stunning demonstration of computer vision and its potential at the time.
- Soon, it was implemented in OpenCV & face detection became synonymous with Viola and Jones algorithm.

![alt text](https://camo.githubusercontent.com/2afdb744bdcff6d1f652b791c30836fde7b449a3b63ae8d0c1544f1b16dbbc13/68747470733a2f2f7777772e7265736561726368676174652e6e65742f70726f66696c652f53616c61685f456464696e655f42656b686f756368652f7075626c69636174696f6e2f3237353034333936362f6669677572652f666967322f41533a32393435343234323833393334373440313434373233353739353038332f4669672d322d5468652d70726f706f7365642d617070726f6163682d612d56696f6c612d4a6f6e65732d616c676f726974686d2d622d4163746976652d53686170652d4d6f64656c732d776974682e706e67 "Logo Title Text 1")

![alt text](https://camo.githubusercontent.com/78a9cf7ad76ff2c11f569204d5011de55c8455f5f60a3bd2fe779ee9b1eb6073/68747470733a2f2f6172732e656c732d63646e2e636f6d2f636f6e74656e742f696d6167652f312d73322e302d53323436383036373231363330303131362d6772312e6a7067 "Logo Title Text 1")

##### Much more efficient detection technique (Histograms of Oriented Gradients, 2005)

- Navneet Dalal and Bill Triggs invented "HOG" for pedestrian detection
    
- Their feature descriptor, Histograms of Oriented Gradients (HOG), significantly outperformed existing algorithms in this task
    
- Handcoded features, just like before
    
- For every single pixel, we want to look at the pixels that directly surrounding it:
    

![Alt Text](https://camo.githubusercontent.com/464dea05c07408c92d016291424935a100133b193c2595331bb2b623c9aaf400/68747470733a2f2f63646e2d696d616765732d312e6d656469756d2e636f6d2f6d61782f313434302f312a525a533035655f35585851646f6664527831477650412e676966)

- Goal is, how dark is current pixel compared to surrounding pixels?
- We will then draw an arrow showing in which direction the image is getting darker:

![Alt Text](https://camo.githubusercontent.com/0c9bf3e2651e9c020cc11b11f76960b178ca41285835bad1be60f4712ee02d8f/68747470733a2f2f63646e2d696d616765732d312e6d656469756d2e636f6d2f6d61782f313434302f312a5746353474516e48314867706f716b2d567466394c672e676966)

- We repeat that process for every single pixel in the image
- Every pixel is replaced by an arrow. These arrows are called gradients
- Gradients show the flow from light to dark across the entire image:

![Alt Text](https://camo.githubusercontent.com/feadbc597a278848d7158982b7c03593a7009fee92920121f58bc59e8ae308ec/68747470733a2f2f63646e2d696d616765732d312e6d656469756d2e636f6d2f6d61782f313434302f312a6f546461456c785f4d2d5f7a39635f694177777163772e676966)

- We'll break up the image into small squares of 16x16 pixels each
- In each square, we’ll count up how many gradients point in each major direction
- Then we’ll replace that square in the image with the arrow directions that were the strongest.
- End result? Original image converted into simple representation that captures basic structure of a face in a simple way:
- Detecting faces means find the part of our image that looks the most similar to a known HOG pattern that was extracted from a bunch of other training faces:

![Alt Text](https://camo.githubusercontent.com/99f1ba1459a7d85ca2e8ee7ab45b8d9d199ede58cf829dbf1629ff0e4f74c84e/68747470733a2f2f63646e2d696d616765732d312e6d656469756d2e636f6d2f6d61782f313434302f312a367867657630722d716e346f523838467257366669412e706e67)

#### The Deep Learning Era begins (2012)

- Convolutional Neural Networks became the gold standard for image classification after Kriszhevsky's CNN's performance during ImageNet

![Alt Text](https://camo.githubusercontent.com/94e808e6adc37140ae455a769fb28e12728c0f2709831ce007cbbb06672bfb4e/68747470733a2f2f696d6167652e736c696465736861726563646e2e636f6d2f636e6e2d746f75706c6f61642d66696e616c2d3135313131373132343934382d6c7661312d617070363839322f39352f636f6e766f6c7574696f6e616c2d6e657572616c2d6e6574776f726b732d636e6e2d36352d3633382e6a70673f63623d31343535383839313738)

While these results are impressive, image classification is far simpler than the complexity and diversity of true human visual understanding.

![Alt Text](https://camo.githubusercontent.com/27660fc557f1efd1f34d613f2feb28de7c56b6ea8e9fadd7a04d5ab036fca433/68747470733a2f2f63646e2d696d616765732d312e6d656469756d2e636f6d2f6d61782f313630302f312a6247546177467851777a63357956315f737a447277512e706e67)

In classification, there’s generally an image with a single object as the focus and the task is to say what that image is

![Alt Text](https://camo.githubusercontent.com/d781c4ce1dcf932673e161d3b267e1c7f6b7c135106fdd1a38e43288a8577344/68747470733a2f2f63646e2d696d616765732d312e6d656469756d2e636f6d2f6d61782f313630302f312a3847567563583979686e4c32314b43746379464452512e706e67)

But when we look at the world around us, we carry out far more complex task

![Alt Text](https://camo.githubusercontent.com/ac38291c3c492cc0196525525ec2a1e33d5cc0f7e14d6ac38acb559b5e6c514c/68747470733a2f2f63646e2d696d616765732d312e6d656469756d2e636f6d2f6d61782f313630302f312a4e647766484d72573372706a3553575f5651745756772e706e67)

We see complicated sights with multiple overlapping objects, and different backgrounds and we not only classify these different objects but also identify their boundaries, differences, and relations to one another!

Can CNNs help us with such complex tasks? Yes.

![Alt Text](https://camo.githubusercontent.com/eb9383ad538315b133d23b51fa9efea63a5549447089c519f42c9b996c5b3f41/68747470733a2f2f6972656e656c697a696875692e66696c65732e776f726470726573732e636f6d2f323031362f30322f636e6e322e706e67)

![Alt Text](https://camo.githubusercontent.com/d798f1edbc51252d8a3a785ed33767e72f7243dd3d67e85039a16f38a451711f/68747470733a2f2f7777772e7079696d6167657365617263682e636f6d2f77702d636f6e74656e742f75706c6f6164732f323031372f30332f696d6167656e65745f76676731362e706e67)

- We can take a classifier like VGGNet or Inception and turn it into an object detector by sliding a small window across the image
- At each step you run the classifier to get a prediction of what sort of object is inside the current window.
- Using a sliding window gives several hundred or thousand predictions for that image, but you only keep the ones the classifier is the most certain about.
- This approach works but it’s obviously going to be very slow, since you need to run the classifier many times.

##### A better approach, R-CNN

![Alt Text](https://camo.githubusercontent.com/5b2c8af7eb21f0f48e6def58252516bdb27a68377a60449676926441ec651e82/68747470733a2f2f63646e2d696d616765732d312e6d656469756d2e636f6d2f6d61782f313630302f312a5a513033496238346259696f464b6f686f35486e4b672e706e67)

- R-CNN creates bounding boxes, or region proposals, using a process called Selective Search
- At a high level, Selective Search looks at the image through windows of different sizes, and for each size tries to group together adjacent pixels by texture, color, or intensity to identify objects.

![Alt Text](https://camo.githubusercontent.com/b949808030153a7eb0245074f5b7d85a4fea5ccc665a17232b845cccf8614a5d/68747470733a2f2f63646e2d696d616765732d312e6d656469756d2e636f6d2f6d61782f313630302f302a53646a36734b445251795a704f366f482e)

1. Generate a set of proposals for bounding boxes.
2. Run the images in the bounding boxes through a pre-trained AlexNet and finally an SVM to see what object the image in the box is.
3. Run the box through a linear regression model to output tighter coordinates for the box once the object has been classified.

###### Some improvements to R-CNN

R-CNN: [https://arxiv.org/abs/1311.2524](https://arxiv.org/abs/1311.2524) Fast R-CNN: [https://arxiv.org/abs/1504.08083](https://arxiv.org/abs/1504.08083) Faster R-CNN: [https://arxiv.org/abs/1506.01497](https://arxiv.org/abs/1506.01497)Mask R-CNN: [https://arxiv.org/abs/1703.06870](https://arxiv.org/abs/1703.06870)

But YOLO takes a different approach

### What is YOLO?

- YOLO takes a completely different approach.
- It’s not a traditional classifier that is repurposed to be an object detector.
- YOLO actually looks at the image just once (hence its name: You Only Look Once) but in a clever way.

YOLO divides up the image into a grid of 13 by 13 cells:

![Alt Text](https://camo.githubusercontent.com/57b54dd97a64b8e34a388416a0910ff89258625c83c37a67d0f6b26eb06d1480/687474703a2f2f6d616368696e657468696e6b2e6e65742f696d616765732f796f6c6f2f477269644032782e706e67)

- Each of these cells is responsible for predicting 5 bounding boxes.
- A bounding box describes the rectangle that encloses an object.
- YOLO also outputs a confidence score that tells us how certain it is that the predicted bounding box actually encloses some object.
- This score doesn’t say anything about what kind of object is in the box, just if the shape of the box is any good.

The predicted bounding boxes may look something like the following (the higher the confidence score, the fatter the box is drawn):

![Alt Text](https://camo.githubusercontent.com/c43d0ad79a049723c623845a6739ac2f589eb1d493455691a522218cf7f0ae6e/687474703a2f2f6d616368696e657468696e6b2e6e65742f696d616765732f796f6c6f2f426f7865734032782e706e67)

- For each bounding box, the cell also predicts a class.
    
- This works just like a classifier: it gives a probability distribution over all the possible classes.
    
- YOLO was trained on the PASCAL VOC dataset, which can detect 20 different classes such as:
	- bicycle
	- boat
	- car
	- cat
	- dog
	- person
The confidence score for the bounding box and the class prediction are combined into one final score that tells us the probability that this bounding box contains a specific type of object.
   
 For example, the big fat yellow box on the left is 85% sure it contains the object “dog”:   

![Alt Text](https://camo.githubusercontent.com/1c32bba073a26da0f4ce6eee95aa6db6d473d917ffe4cef0af5d80aa9ac3e756/687474703a2f2f6d616368696e657468696e6b2e6e65742f696d616765732f796f6c6f2f53636f7265734032782e706e67)

- Since there are 13×13 = 169 grid cells and each cell predicts 5 bounding boxes, we end up with 845 bounding boxes in total.
- It turns out that most of these boxes will have very low confidence scores <span style="color:#ababf5;">(--conf) property</span>, so we only keep the boxes whose final score is 30% or more (you can change this threshold depending on how accurate you want the detector to be).

The final prediction is then:
![Alt Text](https://camo.githubusercontent.com/aadd5ca0d8dfdb284be07152f61985dbc996327d3fa259aa115e5ab638c77a9e/687474703a2f2f6d616368696e657468696e6b2e6e65742f696d616765732f796f6c6f2f50726564696374696f6e4032782e706e67)

- From the 845 total bounding boxes we only kept these three because they gave the best results.
- But note that even though there were 845 separate predictions, they were all made at the same time — the neural network just ran once. And that’s why YOLO is so powerful and fast: [[Object Recognition - Basics]]
