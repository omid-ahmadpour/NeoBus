# NeoBus
A Bus for sending command, query and event using CQRS in .NET

## Give a Star! ⭐
If you like or are using this project to learn or using NeoBus package, please give it a star. Thanks!

## Installing NeoBus

```ruby
> Install-Package NeoBus
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
  
## Register NeoBus
### in Startup -> ConfigureServices

```ruby
>  services.AddNeoBus(Assembly.GetExecutingAssembly());
```

## Register Distributed Events

### Distributed Events(Event On Kafka) :

```ruby
> services.AddHostedService<KafkaEventSubscriberService<ProductAddedEventOnKafka, ProductAddedEventOnKafkaHandler>>();

 services.AddSingleton<ProductAddedEventOnKafkaHandler>();
```


### for versions lower than 1.2.0 use following code to register and need to register commands and queries manually

```ruby
> services.AddNeoBus();
```

### Register Command and Query and Event

#### Command And Query :
```ruby
> services.AddScoped<IRequestHandler<ProductAddCommand, CommandResult>, ProductAddCommandHandler>();

> services.AddScoped<IRequestHandler<GetProductQuery, CommandResult>, GetProductQueryHandler>();
```

#### InMemory Events :
```ruby
> services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductAddedEventHandler>();
```

### The source of a project that used NeoBus is also included.

> [Sample For Use NeoBus](https://github.com/omid-ahmadpour/NeoBus/tree/main/Sample/SampleForUseNeoBus)


### Kafka Docker Compose
  #### for running Kafka, follow the following instruction
  
  ```ruby
  1. Install Docker on your OS(operating system)
  2. Download and put the docker-compose-kafka.yml file in a path of your OS(There is inside the project solution)
  3. Open your Terminal as administrator
  4. Go to the docker-compose-kafka.yml file path
  5. Run docker-compose -f docker-compose-kafka.yml up
  6. Now Kafka is ready on Docker
   ```
   
   
   ## Read More
1. https://medium.com/@omid-ahmadpour/eventbus-application-and-introduction-of-neobus-package-c22029d07f4
2. https://virgool.io/@ahmadpooromid/%DA%A9%D8%A7%D8%B1%D8%A8%D8%B1%D8%AF-eventbus-%D9%88-%D9%85%D8%B9%D8%B1%D9%81%DB%8C-%D9%BE%DA%A9%DB%8C%D8%AC-neobus-rveoqqgefbmu
