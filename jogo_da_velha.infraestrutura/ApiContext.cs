using jogo_da_velha.domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace jogo_da_velha.infraestrutura
{
  public class ApiContext : DbContext
  {
    public ApiContext(DbContextOptions<ApiContext> options) : base(options)
    { }

    DbSet<PartidaEntity> Partida { get; set; }
    DbSet<TabuleiroEntity> Tabuleiro { get; set; }
    DbSet<EspacoEntity> Espaco { get; set; }
  }
}
