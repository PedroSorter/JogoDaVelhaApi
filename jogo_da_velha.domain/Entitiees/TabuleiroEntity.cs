using jogo_da_velha.domain.Constants;
using jogo_da_velha.domain.Constants.Mensagens;
using System.Collections.Generic;
using System.Linq;

namespace jogo_da_velha.domain
{
  public class TabuleiroEntity : Entity
  {
    private static readonly List<int[]> PosicoesVencedoras = new List<int[]>()
    {
      new int[] { 7, 8, 9 },
      new int[] { 4, 5, 6 },
      new int[] { 1, 2, 3 },
      new int[] { 1, 4, 7 },
      new int[] { 2, 5, 8 },
      new int[] { 3, 6, 9 },
      new int[] { 1, 5, 9 },
      new int[] { 3, 5, 7 }
    };

    public TabuleiroEntity(EIdentificacaoJogador primeiroJogador)
    {
      Jogador = primeiroJogador;
    }

    public EIdentificacaoJogador Jogador { get; private set; }

    private IList<EspacoEntity> _listaEspacos = new List<EspacoEntity>();
    public IReadOnlyCollection<EspacoEntity> ListaEspacos { get { return _listaEspacos.ToArray(); } }

    public void AlterarJogadorAtual(EIdentificacaoJogador jogador)
    {
      this.Jogador = jogador;
    }

    public void MarcarQuadro(EspacoEntity espaco)
    {
      if (_listaEspacos.Select(a => a.PosicaoFacilitada).Contains(espaco.PosicaoFacilitada))
      {
        AddNotification("Espaço Marcado", Mensagens.EspacoMarcado(espaco.PosY, espaco.PosX));
      }
      else
      {
        _listaEspacos.Add(espaco);
      }
    }

    public bool ValidarJogadorCorreto(EIdentificacaoJogador jogador)
    {
      return Jogador.Equals(jogador) ? true : false;
    }
    
    public EResultadoPartida VerificarResultado()
    {
      if (_listaEspacos.Count() > 9) { return EResultadoPartida.Empate; }

      var posicoesFacilitadasX = _listaEspacos.Where(a => a.Jogador == EIdentificacaoJogador.X);
      var posicoesFacilitadasY = _listaEspacos.Where(a => a.Jogador == EIdentificacaoJogador.Y);
      foreach (var posicoes in PosicoesVencedoras)
      {
        if (posicoesFacilitadasX.Select(a => a.PosicaoFacilitada).Contains(posicoes[0]) && posicoesFacilitadasX.Select(a => a.PosicaoFacilitada).Contains(posicoes[1]) && posicoesFacilitadasX.Select(a => a.PosicaoFacilitada).Contains(posicoes[2]))
        {
          return EResultadoPartida.X;
        }

        if (posicoesFacilitadasY.Select(a => a.PosicaoFacilitada).Contains(posicoes[0]) && posicoesFacilitadasX.Select(a => a.PosicaoFacilitada).Contains(posicoes[1]) && posicoesFacilitadasX.Select(a => a.PosicaoFacilitada).Contains(posicoes[2]))
        {
          return EResultadoPartida.X;
        }
      }

      return EResultadoPartida.EmCurso;
    }
  }
}
