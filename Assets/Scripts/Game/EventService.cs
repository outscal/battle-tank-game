
using System;

public class EventService : SingletonGeneric<EventService>
{

    public Action OnPlayerBulletFire;
    public Action OnPlayerDead;
    public Action OnPlayerEscapeFromChasingTank;
}
