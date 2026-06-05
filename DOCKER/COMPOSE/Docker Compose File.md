#DOCKER 

# Docker Compose File

The `docker-compose.yaml` is the file that need to define all the services environment, including services, networks and volumes: 

```yaml
# Compose file version
services:
  # Service name - can be anything descriptive
  {SERVICE_NAME}:
    # Image to use from Docker Hub or other registry
    image: nginx:alpine
    
    # [Optional] build from a Dockerfile instead of using an image
    build:
      context: ./web          # Path to build context
      dockerfile: Dockerfile  # Dockerfile ref(optional if != dockerfile)
      args:                   # Build arguments
        - BUILD_VERSION=1.0
    
    # Container name (optional) (by default auto generated)
    container_name: my-web-app
    
    # Restart policy
    restart: unless-stopped  # Options: no, always, on-failure, unless-stopped
    
    # Port mapping - host:container
    ports:
      - "8080:80"           # Expose container port 80 on host port 8080
      - "443:443"
    
    # Volume mounts for persistent data
    volumes:
      - ./html:/usr/share/nginx/html      # Bind mount host directory
      - nginx-config:/etc/nginx/conf.d    # Named volume
      - /var/run/docker.sock:/var/run/docker.sock:ro  # Read-only mount
    
    # Environment variables
    environment:
      - NODE_ENV=production
      - API_KEY=${API_KEY}  # Reference from .env file
      POSTGRES_PASSWORD: secret123
    
    # Alternative: load env vars from file
    env_file:
      - .env
      - ./config/.env.prod
    
    # Network configuration
    networks:
      - frontend
      - backend
    
    # Service dependencies - ensures other services start first
    depends_on:
      - database
      - cache
    
    # Health check configuration
    healthcheck:
      test: ["CMD", "curl", "-f", "http://localhost"]
      interval: 30s
      timeout: 10s
      retries: 3
      start_period: 40s
    
    # Resource limits
    deploy:
      resources:
        limits:
          cpus: '0.5'
          memory: 512M
        reservations:
          cpus: '0.25'
          memory: 256M
    
    # Command override
    command: npm start
    
    # Entrypoint override
    entrypoint: ["/bin/sh", "-c"]
    
    # Working directory inside container
    working_dir: /app
    
    # User and group
    user: "1000:1000"
    
    # Labels for metadata
    labels:
      com.example.description: "Web frontend"
      com.example.team: "devops"

  # Database service example
  database:
    image: postgres:15-alpine
    container_name: postgres-db
    restart: always
    environment:
      POSTGRES_DB: myapp
      POSTGRES_USER: dbuser
      POSTGRES_PASSWORD: ${DB_PASSWORD}
    volumes:
      - postgres-data:/var/lib/postgresql/data
      - ./init-scripts:/docker-entrypoint-initdb.d  # Init scripts
    ports:
      - "5432:5432"
    networks:
      - backend

  # Redis cache example
  cache:
    image: redis:7-alpine
    container_name: redis-cache
    restart: always
    command: redis-server --requirepass ${REDIS_PASSWORD}
    volumes:
      - redis-data:/data
    ports:
      - "6379:6379"
    networks:
      - backend

# Named volumes declaration
volumes:
  postgres-data:
    driver: local
  redis-data:
    driver: local
  nginx-config:

# Networks declaration
networks:
  frontend:
    driver: bridge
  backend:
    driver: bridge
    internal: true  # Not accessible from host
```

## Services

Each service is created as `service.{service_name}`, indicating at least `build` for custom `Dockerfiles` or `image` for a remote or pulled image: 
```yaml
services:
  web:
    image: nginx:latest
    ports:
      - "8080:80"

  db:
    image: postgres:18
    environment:
      POSTGRES_USER: example
      POSTGRES_DB: exampledb
```

Each service can have the following configurations: 
* `container_name`: custom container name (By default its auto-generated). 
* `environment`: environmental variables mapping accesible from inside the container. 
	* `env_file`: indicates an environmental variables file path in `.env` format that will be load. 
* `configs`: access to configuration files that allow to modify the application without rebuilding the image. 
* `secrets`: similar to configs but for sensitive data. 

For networking: 
* `ports`: mapping of ports for open communication between the local host and the container, in `"HOST:CONTAINER"` format. 
* `expose`: declares internal ports accesibles to linked services. This ports are not published to the host.
* `networks`: wich defined networks this service is connected to. 
* `hostname`: set a custom hostname inside the container. 
* `domainname`: declares a custom domain name. 
* `dns`: defines a custom DNS server (Single value or a list)
* `dns_search`: custom DNS search domains. 
* `dns_opt`: custom DNS options passed to `/etc/resolv.conf` file. 
* `extra_hosts`: add hostname mappings to `/etc/hosts` file. 
* `mac_address`: sets a MAC address for the container. 

For storage: 
* `volumes`: list of mounts host paths or named volumes into the container. Following the `{VOLUME_NAME}:{VOLUME_MOUNTING_PATH}`. 
* `tmpfs`: temporary mount file systems. 
* `volumes_from`: mount all volumes from another container. 


If `build` is defined for a custom docker container: 
* `command`: override default CMD instruction command from the docker file. 
* `entrypoint`: override default ENTRYPOINT instruction from the docker file. 

For dependencies and startup logic between services: 
* `depends_on`: controls the service startup order waiting for other indicated services health check. 
	* Supports list of service names that must be started up and healthy in order to start this service. 
	* Also supports advanced conditions like `service_healthy`, `service_completed_successfully` and others. 
* `links`: creates network links to other services. 
* `external_links`: links to services outside the compose application. 

For resource limits: 
* `cpus`: 
* `cpu_count`: 
* `cpu_percent`: 
* `cpu_shares`: 
* `cpuset`: 
* `mem_limit`: 
* `mem_reservation`: 
* `mem_swappiness`: 
* `memswap_limit`: 
* `blkio_config`: 

For security and permissions: 
* *

## Network


## Volumes

