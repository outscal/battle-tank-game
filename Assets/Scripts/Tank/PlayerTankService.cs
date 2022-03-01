using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

namespace Tank
{
    public class PlayerTankService : SingletonMB<PlayerTankService>, ITankService
    {
        [SerializeField] private ParticleSystem tankExplosion;
        [SerializeField] private int index;
        [SerializeField] private InputSystem.InputSystem inputSystem;
        [SerializeField] private Scriptable_Object.Tank.PlayerTankList tanks;
        [SerializeField] private SafePoint[] safePoints;

        public ParticleSystem Explosion => tankExplosion;
        public SafePoint[] SafePoints => safePoints;
        private PlayerTankController _player;
        public PlayerTankController Player => _player;

        protected override void Awake()
        {
            base.Awake();
            _player = (PlayerTankController) ((ITankService) this).CreateTank(tanks.List[index]);
        }

        /*private void Start()
        {
            _player = (PlayerTankController) ((ITankService) this).CreateTank(tanks.List[index]);
        }*/

        TankController ITankService.CreateTank(Scriptable_Object.Tank.Tank tank)
        {
            return new PlayerTankController(inputSystem, tank);
        }

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
    }
}
