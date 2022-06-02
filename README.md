# NeoBus
A Bus for sending command, query and event using CQRS in .NET

## Give a Star! ⭐
If you like or are using this project to learn or using NeoBus package, please give it a star. Thanks!

## Installing NeoBus

```ruby
> Install-Package NeoBus
```

## Registering NeoBus
### in Startup -> ConfigureServices

```ruby
> services.AddNeoBus();
```
## AppSettings Config
## Put the following configuration in appsettings.json and add your kafka address
```
"NeoBus": {
    "Kafka": {
      "Servers": [ "localhost:9092" ]
    }
  }}
  ```

### Register Command Or Query Or Event

#### Command And Query :
```ruby
> services.AddScoped<IRequestHandler<ProductAddCommand, CommandResult>, ProductAddCommandHandler>();

> services.AddScoped<IRequestHandler<GetProductQuery, CommandResult>, GetProductQueryHandler>();
```

#### InMemory Events :
```ruby
> services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductAddedEventHandler>();
```

#### Distributed Events(Event On Kafka) :
```ruby
> services.AddHostedService<KafkaEventSubscriberService<ProductAddedEventOnKafka, ProductAddedEventOnKafkaHandler>>();

 services.AddSingleton<ProductAddedEventOnKafkaHandler>();
```

### The source of a project that used NeoBus is also included.

> [Sample For Use NeoBus](https://github.com/omid-ahmadpour/NeoBus/tree/main/Sample/SampleForUseNeoBus)

# Kafka Docker Compose
  ## for running Kafka, follow the following instruction
  
  ```ruby
  1. Install Docker on your OS(operating system)
  2. Download and put the docker-compose-kafka.yml file in a path of your OS(There is inside the project solution)
  3. Open your Terminal as administrator
  4. Go to the docker-compose-kafka.yml file path
  5. Run docker-compose -f docker-compose-kafka.yml up
  6. Now Kafka is ready on Docker
   ```
