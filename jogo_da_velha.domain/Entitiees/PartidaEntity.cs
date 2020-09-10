using jogo_da_velha.domain.Constants;

namespace jogo_da_velha.domain
{
  public class PartidaEntity : Entity
  {
    public PartidaEntity()
    {
      Finalizada = false;
    }

    public EResultadoPartida Resultado { get; private set; }
    public bool Finalizada { get; private set; }
   
    public void FinalizarPartida()
    {
      Finalizada = true;
    }
  }
}
