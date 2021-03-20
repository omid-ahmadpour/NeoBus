# NeoBus
A Bus for sending command, query and event using CQRS in .Net.

## Installing NeoBus

```ruby
> Install-Package NeoBus
```

## Registering NeoBus
### in Startup -> ConfigureServices

```ruby
> services.AddNeoBus();
```

### Register Command Or Query Or Event

#### Command :
```ruby
> services.AddScoped<IRequestHandler<ProductAddCommand, CommandResult>, ProductAddCommandHandler>();
```

#### Query :
```ruby
> services.AddScoped<IRequestHandler<GetProductQuery, CommandResult>, GetProductQueryHandler>();
```

#### Event :
```ruby
> services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductAddedEventHandler>();
```

### The source of a project that used NeoBus is also included.

> [Sample For Use NeoBus](https://github.com/omid-ahmadpour/NeoBus/tree/main/Sample/SampleForUseNeoBus)
