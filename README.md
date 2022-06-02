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
