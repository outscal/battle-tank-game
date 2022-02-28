using System;
using Tank;
using UnityEngine;

namespace Scriptable_Object.Tank
{
    //[CreateAssetMenu(fileName = "NewTank", menuName = "User/Tank/Tank", order = 1)]
    public abstract class Tank : ScriptableObject
    {
        //[SerializeField] private TankView tankView;
        [SerializeReference] protected TankModel tankModel;
        protected TankType tankType = TankType.None;

        public TankType TankType => tankType;
        public virtual TankView TankView => null;
        public TankModel TankModel => tankModel;

        //private TankType _lastType;
        //private TankModel _saved;

        /*public Tank()
        {
            _lastType = TankType;
        }*/
        
        /*private void OnValidate()
        {
            if (tankType!=_lastType)
            {
                _lastType = tankType;
                _saved = tankModel;
                tankModel = UpdateTankModel(_saved);
                _saved = null;
            }
        }*/

        /*private TankModel UpdateTankModel(TankModel other)
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
        }*/
    }
}