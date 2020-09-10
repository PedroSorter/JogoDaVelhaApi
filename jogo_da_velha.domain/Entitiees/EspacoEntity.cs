using Flunt.Validations;
using jogo_da_velha.domain.Constants;
using jogo_da_velha.domain.Constants.Mensagens;


namespace jogo_da_velha.domain
{
  public class EspacoEntity : Entity
  {
    public EspacoEntity(int posY, int posX, EIdentificacaoJogador jogador)
    {
      AddNotifications(new Contract()
                      .Requires()
                      .IsBetween(posY, 0, 2, "Y", Mensagens.PosicaoIncorreta(posY))
                      .IsBetween(posX, 0, 2, "X", Mensagens.PosicaoIncorreta(posX))
                      .IsNotNullOrEmpty(jogador.ToString(), "Jogador", Mensagens.ParametroIncorreto("Jogador"))
                      );
      if (Valid)
      {
        PosY = posY;
        PosX = posX;
        Jogador = jogador;
        CalcularPosicaoFacilitada();
      }
    }

    public int PosY { get; private set; }
    public int PosX { get; private set; }
    public EIdentificacaoJogador Jogador { get; private set; }
    public int PosicaoFacilitada { get; private set; }
    public void CalcularPosicaoFacilitada()
    {
      var posicaoFacilitada = 0;
      switch (this.PosY)
      {
        case 0:
          switch (this.PosX)
          {
            case 0:
              posicaoFacilitada = 1;
              break;
            case 1:
              posicaoFacilitada = 2;
              break;
            case 2:
              posicaoFacilitada = 3;
              break;
          }
          break;
        case 1:
          switch (this.PosX)
          {
            case 0:
              posicaoFacilitada = 4;
              break;
            case 1:
              posicaoFacilitada = 5;
              break;
            case 2:
              posicaoFacilitada = 6;
              break;
          }
          break;
        case 2:
          switch (this.PosX)
          {
            case 0:
              posicaoFacilitada = 7;
              break;
            case 1:
              posicaoFacilitada = 8;
              break;
            case 2:
              posicaoFacilitada = 9;
              break;
          }
          break;
      }

      PosicaoFacilitada = posicaoFacilitada;
    }
  }
}
