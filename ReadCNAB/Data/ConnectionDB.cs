using Microsoft.EntityFrameworkCore;
using ReadCNAB.Models;

namespace ReadCNAB.Data
{
    public class ConnectionDB : DbContext
    {
        public DbSet<CNABModel> CNABs { get; set; }
        public DbSet<TranModel> Transaction { get; set; }

        public ConnectionDB(DbContextOptions<ConnectionDB> options) : base(options)
        {
            if (!Transaction.Any())
            {
                var transaction1 = new TranModel { TranType = 1, Description = "Debito", Nature = "Entrada", Signal = "+" };
                var transaction2 = new TranModel { TranType = 2, Description = "Boleto", Nature = "Saída", Signal = "-" };
                var transaction3 = new TranModel { TranType = 3, Description = "Financiamento", Nature = "Saída", Signal = "-" };
                var transaction4 = new TranModel { TranType = 4, Description = "Crédito", Nature = "Entrada", Signal = "+" };
                var transaction5 = new TranModel { TranType = 5, Description = "Recebimento Empréstimo", Nature = "Entrada", Signal = "+" };
                var transaction6 = new TranModel { TranType = 6, Description = "Vendas", Nature = "Entrada", Signal = "+" };
                var transaction7 = new TranModel { TranType = 7, Description = "Recebimento TED", Nature = "Entrada", Signal = "+" };
                var transaction8 = new TranModel { TranType = 8, Description = "Recebimento DOC", Nature = "Entrada", Signal = "+" };
                var transaction9 = new TranModel { TranType = 9, Description = "Aluguel", Nature = "Saída", Signal = "-" };

                Transaction.Add(transaction1);
                Transaction.Add(transaction2);
                Transaction.Add(transaction3);
                Transaction.Add(transaction4);
                Transaction.Add(transaction5);
                Transaction.Add(transaction6);
                Transaction.Add(transaction7);
                Transaction.Add(transaction8);
                Transaction.Add(transaction9);

                SaveChanges();
            }
            
        }

    }
}