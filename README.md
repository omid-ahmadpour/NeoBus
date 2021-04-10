# NeoBus
A Bus for sending command, query and event using CQRS in .Net.

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

### Register Command Or Query Or Event

#### Command And Query :
```ruby
> services.AddScoped<IRequestHandler<ProductAddCommand, CommandResult>, ProductAddCommandHandler>();

> services.AddScoped<IRequestHandler<GetProductQuery, CommandResult>, GetProductQueryHandler>();
```

#### Event :
```ruby
> services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductAddedEventHandler>();
```

### The source of a project that used NeoBus is also included.

> [Sample For Use NeoBus](https://github.com/omid-ahmadpour/NeoBus/tree/main/Sample/SampleForUseNeoBus)
