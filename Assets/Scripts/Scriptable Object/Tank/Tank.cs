using System;
using Tank;
using UnityEngine;

namespace Scriptable_Object.Tank
{
    [CreateAssetMenu(fileName = "NewTank", menuName = "User/Tank/Tank", order = 1)]
    public class Tank : ScriptableObject
    {
        [SerializeField] private TankType tankType = TankType.None;
        [SerializeField] private TankView tankView;
        [SerializeReference] private TankModel tankModel;

        public TankType TankType => tankType;
        public TankView TankView => tankView;
        public TankModel TankModel => tankModel;

        private TankType _lastType;
        private TankModel _saved;

        public Tank()
        {
            _lastType = TankType;
        }
        
        private void OnValidate()
        {
            if (tankType!=_lastType)
            {
                _lastType = tankType;
                _saved = tankModel;
                tankModel = UpdateTankModel(_saved);
                _saved = null;
            }
        }

        private TankModel UpdateTankModel(TankModel other)
        {
            TankModel newTankModel = null;
            switch (tankType)
            {
                case TankType.Player:
                    newTankModel = (other!=null)?new TankModel(other): new TankModel();
                    break;
                case TankType.Enemy:
                    newTankModel = (other!=null)?new EnemyTankModel(other):new EnemyTankModel();
                    break;
            }

            return newTankModel;
        }
    }
}