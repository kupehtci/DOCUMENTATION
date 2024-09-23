#NodeJS #JS

# NodeJS Await

`await` syntax can only be used within an `async` function. 

This will "wait" (Not really) for the promise to resolve and in case that this promise is rejected, throw an error that can be catched with a `try catch` block. 


Example of a chained await functions, similar functionality like a `.then` promise chain: 

```js
// Example of async download of various files 

function DownloadFile(filename){  
    return new Promise((resolve=>{  
        setTimeout(() =>{  
            resolve("downloaded: " + filename);  
        }, 1000);  
    }));  
}  
  
async function AsyncDownloadFile(){  
  
    try{  
        const result1 = await DownloadFile("file1");  
        console.log(result1);  
  
        const result2 = await DownloadFile("file2");  
        console.log(result2);  
  
        const result3 = await DownloadFile("file3");  
        console.log(result3);  
    }  
    catch (error){  
        console.log(error);  
    }  
}  
  
AsyncDownloadFile();
```