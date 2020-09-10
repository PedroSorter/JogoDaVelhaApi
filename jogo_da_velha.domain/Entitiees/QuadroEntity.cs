using jogo_da_velha.domain.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace jogo_da_velha.domain
{
  public class QuadroEntity
  {
    public QuadroEntity(int posY, int posX, EIdentificacaoJogador jogador)
    {
      PosY = posY;
      PosX = posX;
      Jogador = jogador;
      CalcularPosicaoFacilitada();
    }

    public int PosY { get; private set; }
    public int PosX { get; private set; }
    public EIdentificacaoJogador Jogador { get; private set; }
    public int PosicaoFacilitada { get; private set; }

    public bool IsValid()
    {
      if (PosY > 0 && PosY < 3 && PosX > 0 && PosX < 3)
      {
        return false;
      }

      return true;
    }

    public void CalcularPosicaoFacilitada()
    {
      switch (PosY)
      {
        case 0:
          switch (PosX)
          {
            case 0:
              PosicaoFacilitada = 1;
            break;
            case 1:
              PosicaoFacilitada = 2;
            break;
            case 2:
              PosicaoFacilitada = 3;
            break;
          }
        break;
        case 1:
          switch (PosX)
          {
            case 0:
              PosicaoFacilitada = 4;
              break;
            case 1:
              PosicaoFacilitada = 5;
              break;
            case 2:
              PosicaoFacilitada = 6;
              break;
          }
        break;
        case 2:
          switch (PosX)
          {
            case 0:
              PosicaoFacilitada = 7;
              break;
            case 1:
              PosicaoFacilitada = 8;
              break;
            case 2:
              PosicaoFacilitada = 9;
              break;
          }
        break;
      }
    }
  }
}
