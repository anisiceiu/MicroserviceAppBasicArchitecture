using CatalogService.Models;
using MassTransit;
using System.Text.Json;

namespace CatalogService.Consumer
{
    public class OrderConsumer : IConsumer<SharedLibrary.Order>
    {
        public async Task Consume(ConsumeContext<SharedLibrary.Order> context)
        {
            await Console.Out.WriteLineAsync($"\nMessage Received:{JsonSerializer.Serialize(context.Message)}");
        }
    }
}
