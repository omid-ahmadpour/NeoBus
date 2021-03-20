# NeoBus
A Bus for sending command, query and event using CQRS in .Net.

## Installing NeoBus

```ruby
> Install-Package NeoBus -Version 1.0.1
```

## Registering NeoBus
### in Startup -> ConfigureServices

```ruby
> services.AddNeoBus();
```

### Register Command Or Query Or Event

```ruby
> services.AddScoped<IRequestHandler<ProductAddCommand, CommandResult>, ProductAddCommandHandler>();
> services.AddScoped<IRequestHandler<GetProductQuery, CommandResult>, GetProductQueryHandler>();
> services.AddScoped<INotificationHandler<ProductAddedEvent>, ProductAddedEventHandler>();
```
