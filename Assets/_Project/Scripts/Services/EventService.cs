using BattleTank.Enum;
using BattleTank.GenericSingleton;
using System;

namespace BattleTank.Services
{
    public class EventService : GenericSingleton<EventService>
    {
        public event Action<TankID> onBulletFired;
        public event Action<TankID, TankID> onTankDestroyed;
        public event Action onPlayerEscaped;
        
        public void OnBulletFired(TankID tankID)
        {
            onBulletFired?.Invoke(tankID);
        }

        public void OnTankDestroyed(TankID shooter, TankID reciever)
        {
            onTankDestroyed?.Invoke(shooter, reciever);
        }

        public void OnPlayerEscaped()
        {
            onPlayerEscaped?.Invoke();
        }
    }
}