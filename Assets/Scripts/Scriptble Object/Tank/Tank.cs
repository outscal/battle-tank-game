using System;
using Tank;
using UnityEngine;

namespace Scriptble_Object.Tank
{
    [CreateAssetMenu(fileName = "NewTank", menuName = "User/Tank/Tank", order = 0)]
    public class Tank : ScriptableObject
    {
        [SerializeField] private TankType tankType;
        [SerializeField] private TankView tankView;
        [SerializeReference] private TankModel tankModel;

        public TankType TankType => tankType;
        public TankView TankView => tankView;
        public TankModel TankModel => tankModel;

        private TankType _lastType;
        private TankModel _saved;

        Tank()
        {
            tankModel = new TankModel();
        }
        private void OnEnable()
        {
            _lastType = tankType;
        }

        private void OnValidate()
        {
            if (tankType != _lastType)
            {
                _saved = tankModel;
                tankModel = updateTankModel(_saved);
                _lastType = tankType;
            }
        }

        private TankModel updateTankModel(TankModel other)
        {
            TankModel tankModel = null;
            switch (tankType)
            {
                case TankType.Player:
                    tankModel = new TankModel(other);
                    break;
                case TankType.Enemy:
                    tankModel = new EnemyTankModel((EnemyTankModel)other);
                    break;
            }

            return tankModel;
        }
    }
}