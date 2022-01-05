using EstoqueAlarmaq.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EstoqueAlarmaq.Infra.Data
{
    public class DataContext : DbContext
    {
        DbSet<Produto> Produtos;
    }
}
