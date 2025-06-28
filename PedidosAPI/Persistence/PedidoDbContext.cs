using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using PedidosAPI.Models;

namespace Pedidos.API.Persistence
{
    public class PedidoDbContext(DbContextOptions<PedidoDbContext>options): DbContext(options)
    {
        public DbSet<Pedido> Pedidos { get; set; } = null!;
    }
}
