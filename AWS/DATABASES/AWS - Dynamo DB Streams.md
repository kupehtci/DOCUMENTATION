#AWS 

# AWS - Dynamo DB Streams

AWS Dynamo DB Streams is a DynamoDB's feature that captures time-ordered sequence of item-level changes (Inserts. Updates and deletes) made to items in a DynamoDB table and **records this data modification in a dedicated Stream for 24 hours**. 

This enables applications to access and process changes in real time. 

Whenever data in DynamoDB is modifies, DynamoDB Streams writes an stream record describing the change, including: 
* Only the item key
* The new image after change
* The old image before change. 
* Both images

An **image** is an snapshot or state of the item's attributes captured upon an event that changes or deletes it. 



