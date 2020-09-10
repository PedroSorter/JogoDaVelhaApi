using Flunt.Notifications;
using System;


namespace jogo_da_velha.domain
{
  public abstract class Entity : Notifiable
  {
    public Entity()
    {
      Id = Guid.NewGuid();
    }

    public Guid Id { get; protected set; }

    public void AtualizarId(Guid id)
    {
      if (id == Guid.Empty)
        id = Guid.NewGuid();

      Id = id;
    }
  }
}
