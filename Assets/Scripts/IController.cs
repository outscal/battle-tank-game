using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Tank;

public interface IController
{
    void OnDeath(ParticleSystem m_ExplosionParticles, Vector3 tankPosition);
    IModel GetModel();
}
