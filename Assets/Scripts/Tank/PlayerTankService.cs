using System;
using Scriptable_Object.Tank;
using Tank.Interfaces;
using UnityEngine;

namespace Tank
{
    public class PlayerTankService : SingletonMB<PlayerTankService>, Interfaces.ITankService
    {
        #region Public Events

        public static event Action LoseLife;
        public static event Action PlayerDied;
        public static event Action PlayerCreated;

        #endregion
        #region Serialized Data Members

        [SerializeField] private ParticleSystem tankExplosion;
        [SerializeField] private int index;
        [SerializeField] private InputSystem.InputSystem inputSystem;
        [SerializeField] private PlayerTankList tanks;
        [SerializeField] private SafePoint[] safePoints;

        #endregion

        #region Private Data Members

        private PlayerTankController _player;

        #endregion

        #region Getters

        public ParticleSystem Explosion => tankExplosion;
        public SafePoint[] SafePoints => safePoints;
        public PlayerTankController Player => _player;

        #endregion

        #region Unity Functions

        private void Start()
        {
            _player = (PlayerTankController) ((ITankService) this).CreateTank(tanks.List[index]);
        }

        #endregion
        
        TankController Interfaces.ITankService.CreateTank(Scriptable_Object.Tank.Tank tank)
        {
            PlayerCreated?.Invoke();
            Debug.Log("Player Created");
            return new PlayerTankController(inputSystem, tank);
        }

        #region Public Functions

        public void Destroy(TankController controller=null)
        {
            StartCoroutine(((ITankService) this).KillTank(_player, tankExplosion));
        }

        public Vector3 GetSafePosition()
        {
            Vector3 safe = Vector3.zero;
            foreach (var safePoint in safePoints)
            {
                if (safePoint.Safe)
                {
                    safe = safePoint.transform.position;
                    break;
                }
            }
            return safe;
        }

        public void PlayerLoseLife() => LoseLife?.Invoke();
        public void PlayerDie() => PlayerDied?.Invoke();

        #endregion
    }
}
