using jogo_da_velha.domain.Constants;
using System;

namespace jogo_da_velha.domain
{
  public class PartidaEntity : Entity
  {
    public PartidaEntity()
    {
      var rnd = new Random();
      Tabuleiro = new TabuleiroEntity((EIdentificacaoJogador)rnd.Next(1, 2));
      Iniciada = true;
      Resultado = EResultadoPartida.EmCurso;
    }

    public EResultadoPartida Resultado { get; private set; }
    public bool Finalizada { get; private set; }
    public bool Iniciada { get; private set; }
    public TabuleiroEntity Tabuleiro { get; private set; }

    public void FinalizarPartida()
    {
      Finalizada = true;
    }
  }
}
