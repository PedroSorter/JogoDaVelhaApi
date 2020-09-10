using jogo_da_velha.domain.Constants;
using jogo_da_velha.domain.Constants.Mensagens;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace jogo_da_velha.domain
{
  public class TabuleiroEntity : Entity
  {
    public TabuleiroEntity()
    {
      var rnd = new Random();
      JogadorAtual = (EIdentificacaoJogador)rnd.Next(1, 2);
    }

    public EIdentificacaoJogador JogadorAtual { get; private set; }

    private IList<QuadroEntity> _listaQuadro = new List<QuadroEntity>();
    public IReadOnlyCollection<QuadroEntity> ListaQuadros { get { return _listaQuadro.ToArray(); } }

    public void AlterarJogadorAtual(EIdentificacaoJogador jogador)
    {
      this.JogadorAtual = jogador;
    }

    public void MarcarQuadro(int posY, int posX)
    {
      _listaQuadro.Add(new QuadroEntity(posY, posX, JogadorAtual));
    }

    public bool ValidarJogadorCorreto(EIdentificacaoJogador jogador)
    {
      return JogadorAtual.Equals(jogador) ? true : false;
    }

    public EResultadoPartida ResultadoPartida()
    {

    }
  }
}
