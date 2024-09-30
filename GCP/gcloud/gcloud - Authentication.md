#GCP 

# Authentication using gcloud

You have different forms of login depending on the resources you want to affect and if you are in local shell or the cloud shell. 

### Local environment

You can use your user credentials in order to sign into the gcloud CLI or by using a service account: 

When you are signed, the tool refresh your credential token in the home credentials. 

You need to `init` and `auth login`. At this time, the authentication is done by opening the displayed URL in the web browser of preference and login in it with your google account. Once you have login, you will need to copy and paste the verification code that its displayed in the web browser, to the console. 

Then you will be displayed all the set of projects that you have permissions over it or you are owner or collaborator. You need to select the project by the number its selected with. 

```bash
> gcloud init

> gcloud auth login


```