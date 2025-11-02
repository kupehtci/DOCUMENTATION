#DOCKER 

# DockerFile - React + NGINX

A good example of exposing a React Application using an NGINX server is: 

```DockerFile
FROM node:20 AS build
WORKDIR /app
COPY package*.json ./
RUN npm install
COPY . .
RUN npm run build

FROM nginx:stable-alpine
COPY --from=build /app/dist /usr/share/nginx/html
EXPOSE 80
CMD ["nginx", "-g", "daemon off;"]
```

It uses node image to install the dependencies of the project and compile and NGINX image to build an nginx server that expose and run the service. 