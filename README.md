# NeoBus
NeoBus is a powerful library that enables you to send commands, queries, and events using the CQRS pattern in .NET. It simplifies the implementation of distributed systems and event-driven architectures by seamlessly integrating with Kafka. If you find NeoBus helpful, please consider giving it a star ⭐ to show your support.

## Installation
You can easily install NeoBus via NuGet Package Manager:

```shell
> Install-Package NeoBus
```

## Configuration
To configure NeoBus, add the following settings to your `appsettings.json` file and specify your Kafka server address:

```json
"NeoBus": {
    "Kafka": {
        "Servers": ["localhost:9092"]
    }
}
```

## Registration
Incorporate NeoBus into your project by registering it in the `Startup.cs` file within the `ConfigureServices` method:

```csharp
services.AddNeoBus(Assembly.GetExecutingAssembly());
```

### Distributed Events (Kafka)
For distributed events using Kafka, register the necessary services as follows:

```csharp
services.AddHostedService<KafkaEventSubscriberService<ProductAddedEventOnKafka, ProductAddedEventOnKafkaHandler>>();
services.AddSingleton<ProductAddedEventOnKafkaHandler>();
```

If you are using a version lower than 1.2.0, use the following code to register and manually register commands and queries:

```csharp
services.AddNeoBus();
```

### Registering Commands, Queries, and In-Memory Events
To register commands and queries, follow these steps:

#### Command and Query Handlers:
```csharp
services.AddScoped<IRequestHandler<ProductAddCommand, CommandResult>, ProductAddCommandHandler>();
services.AddScoped<IRequestHandler<GetProductQuery, CommandResult>, GetProductQueryHandler>();
```

#### In-Memory Event Handlers:
```csharp
services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductAddedEventHandler>();
```

## Sample Project
Explore a sample project that demonstrates how to use NeoBus:

[Sample For Use NeoBus](https://github.com/omid-ahmadpour/NeoBus/tree/main/Sample/SampleForUseNeoBus)

## Setting Up Kafka with Docker Compose
To run Kafka locally, follow these instructions:

1. Install Docker on your local machine.
2. Download the `docker-compose-kafka.yml` file from within the project solution.
3. Open your Terminal as an administrator.
4. Navigate to the directory containing the `docker-compose-kafka.yml` file.
5. Run the following command:

```shell
docker-compose -f docker-compose-kafka.yml up
```

Now Kafka is up and running in a Docker container.

## Learn More
For more information about NeoBus and its applications, consider reading the following articles:

1. [EventBus Application and Introduction of NeoBus Package](https://medium.com/@omid-ahmadpour/eventbus-application-and-introduction-of-neobus-package-c22029d07f4)
2. [کاربرد EventBus و معرفی پکیج NeoBus (Persian)](https://virgool.io/@ahmadpooromid/%DA%A9%D8%A7%D8%B1%D8%A8%D8%AF-eventbus-%D9%88-%D9%85%D8%B9%D8%B1%D9%81%DB%8C-%D9%BE%DA%A9%DB%8C%D8%AC-neobus-rveoqqgefbmu)

Feel free to explore these resources to enhance your understanding of NeoBus and its capabilities.
