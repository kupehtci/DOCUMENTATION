#SoftwareQuality 


#### BACKGROUND

Living Apps are applications that are executed on top of Movistar TV service. These applications are basically web applications that use an SDK that provides some components and services.

When a partner creates an application it uses a particular version of the SDK.
A partner (RAE) has created a Living App and the Living App has been already put in production. It has been working properly for a while.

#### THE PROBLEM

Suddenly some elements of the Living App were not rendering properly, for instance, the background picture is not shown entirely. See the following image:

#### THE “INVESTIGATION”

The code application was not been modified, so we started to look for alternative causes. We discovered the following:

- The SDK was modified to change something related to the terms and conditions. Those terms and conditions are included in all the living apps.
- All the living apps were updated to use the new SDK and they were re-deployed.
- Not all the living apps were tested after the re-deployment because the team responsible for the SDK development said that the changes were backwards compatible.
* Obviously, as the only changes were related with the SDK, the problems have to do with that so we decided to investigate that change in detail. We found out:
- That in the SDK, the name of some CSS classes were applied. The class names were related to the terms and conditions.
- The new class names were very general (e.g. main)

```css
.Main {
	width: 1920px;
	height: 300px;
	background-color: black;
	padding-top: 72px;
	position: absolute;
	bottom: 0;
	box-sizing: border-box;
	}
```

* The Living App was using some class names identical to the new ones included in the SDK (e.g. main)
```CSS
.Main {
	display: flex;
	display: -webkit-flex;
	align-items: center;
	-webkit-align-items: center;
	justify-content: center;
	-webkit-justify-content: center;
	flex-direction: column;
	-webkit-flex-direction: column;
	width: 100%;
	box-sizing: border-box;
	padding: 0 calc(#{$main-margin-right} - 4rem);
	margin-top: (100vh - $home-grid-height) / 1.5;
	height: $home-grid-height;
	background-color: transparent;
	position: relative;
	bottom: auto;
}
```
- The SDK code, although separated from the LIving App ended up being combined in a unique web app where all the code was mixed up.   
* In the resulting code two definitions of the same class name (main) were included.
* The Living App main element was using the main class definition from the SDK and not from the app as only of the implementation of the main class was valid.

#### A FIRST ANALYSIS

Ideally, the SDK should be totally independent from the LIving App, e.g. by using separate iframe so the code are totally separated and hence this type of conflicts could not happen.

This ideal approach was not followed in favor of a sub-optimal one, this was not properly documented and the partners developing Living Apps were not informed about this limitation. After changing the SDK the Living Apps were not tested so the failure was not observed.

In the moment the full problem was understood, we changed the name of the living app style and we fix it.

##### THE CONCLUSIONS


+ Apply the terms failure and bug in this particular example
- Can you list all the problems/bad decisions that were taken that lead to this problem?
- Do you think we can call the root cause of this problem “technical debt”?
- What are the different actions you would take?