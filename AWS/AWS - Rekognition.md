#AWS 

# AWS Rekognition

Amazon Rekognition is a **fully managed computer vision service** from AWS that allows you to analyze images and videos using machine learning. You **don’t need to build or train models yourself**—AWS provides pre-trained models for common vision tasks.

Its usefull for: 

1. Image Analysis
	- Detect objects, scenes, and activities (cars, trees, people, etc.).
	- Recognize text in images using **text detection**.
	- Detect faces and compare or search for them.
	- Analyze facial attributes (age range, emotions, etc.).
	- Detect unsafe content (nudity, violence).

2. Video Analysis
	- Track people, objects, or activities in video streams.
	- Detect text in videos.
	- Identify celebrities.
	- Detect unsafe content in videos.

3. Face Recognition
	- **Face detection:** Identify faces in images or videos.
	- **Face comparison:** Compare two faces for similarity.
	- **Face search:** Find a face in a large collection.

4. Text Detection
	- Extract text from images or videos (useful for scanned documents or signs).
	- Supports multiple languages.


### How its Rekognition normally used?

- Upload an image to S3.
- Trigger a Lambda function that calls Rekognition.
- Analyze the image for labels, faces, or text.
- Store results in DynamoDB or trigger further workflows.