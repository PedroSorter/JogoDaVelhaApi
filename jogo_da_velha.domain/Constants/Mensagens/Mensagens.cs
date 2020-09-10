using System;
using System.Collections.Generic;
using System.Text;

namespace jogo_da_velha.domain.Constants.Mensagens
{
  public sealed class Mensagens
  {
    public static string TurnoIncorreto(EIdentificacaoJogador jogador)  => $"Não é o turno do jogador {jogador}";
    public static string PartidaNaoEncontrada(Guid IdPartida) => $"A partida com ID {IdPartida} não foi encontrada.";
    public static string PosicaoIncorreta(int Pos) => $"A posição {Pos} não existe no tabuleiro de jogo.";
    public static string PartidaEncerrada(Guid IdPartida) => $"A partida de Id {IdPartida} foi finalizada.";
    public static string ParametroIncorreto(string parametro) => $"O parametro {parametro} está incorreto.";
  }
}
