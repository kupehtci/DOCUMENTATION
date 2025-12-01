#RabbitMQ 

# RabbitMQ Docker

You can run a "disposable" or "development" RabbitMQ using Docker. 

Firstly pull the `3-management` version for an stable version and well documented or `latest` for the newest functionalities. 

```bash
docker pull rabbitmq:3-management
```

The docker image has the following configuration expected: 
* Port `5672` for AMQP communication mapped to a host port.
* Port `15672` for UI web access mapped to a host port.
* Optional persistency by attaching a volume to `/var/lib/rabbitmq`
* Optional persistency for RabbitMQ's logs attaching a volume to `/var/log/rabbitmq`. 

An example DockerCompose file: 

```yaml
version: '3.8'
services:
  rabbitmq:
    image: rabbitmq:3-management
    container_name: rabbitmq
    hostname: my-rabbit
    ports:
      - "5672:5672"       # AMQP port
      - "15672:15672"     # UI Web port
    volumes:
	    # Persists database/data
      - rabbitmq_data:/var/lib/rabbitmq   
        # Persists logs
      - rabbitmq_log:/var/log/rabbitmq    

volumes:
  rabbitmq_data:
  rabbitmq_log:
```