using System;
using Tank;
using UnityEngine;

namespace Scriptable_Object.Tank
{
    public abstract class Tank : ScriptableObject
    {
        #region Serialized Data members

        [SerializeReference] protected TankModel tankModel;

        #endregion

        #region Protected Data members

        protected TankType tankType = TankType.None;

        #endregion

        #region Getters

        public TankType TankType => tankType;
        public virtual TankView TankView => null;
        public TankModel TankModel => tankModel;

        #endregion
    }
}