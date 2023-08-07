using System;
using UnityEngine;

public class EnemyTankController : TankController
{

    EnemyTankModel EnemyTankModel;
    EnemyTankView EnemyTankView;

    float nextDirectionUpdateInterval;

    bool triggerShoot;

    public EnemyTankController(EnemyTankScriptableObject enemyTankScriptableObject) : base((TankScriptableObject)enemyTankScriptableObject)
    {

        EnemyTankModel = new EnemyTankModel(enemyTankScriptableObject);
        TankModel = (TankModel)EnemyTankModel;

        EnemyTankView = GameObject.Instantiate<EnemyTankView>(EnemyTankModel.EnemyTankViewPrefab);
        TankView = (TankView)EnemyTankView;

        EnemyTankView.EnemyTankController = this;
        TankView.TankController = (TankController)this;

        nextDirectionUpdateInterval = UnityEngine.Random.Range(EnemyTankModel.SpawnChance / 2, EnemyTankModel.SpawnChance + 1);

        triggerShoot = false;
    }

    public override void Update()
    {
        if (!EnemyTankModel.IsAlive)
        {
            GameObject.Destroy(EnemyTankView.gameObject);
        }

        nextDirectionUpdateInterval -= Time.fixedDeltaTime;

        if (nextDirectionUpdateInterval <= 0)
        {
            ResetDirection();
        }

        CanSeePlayer();

        base.Update();
    }

    public void FixedUpdate()
    {
        EnemyTankModel.TimeLeftForNextShot -= Time.fixedDeltaTime;

        if (triggerShoot)
        {
            if (EnemyTankModel.TimeLeftForNextShot <= 0)
            {
                EnemyTankModel.TimeLeftForNextShot = EnemyTankModel.FireRate;
                Shoot();
            }
            triggerShoot = false;
        }
    }

    public void OnCollisionEnter(Collision collision)
    {
        ResetDirection();
    }

    void ResetDirection()
    {
        // using random function to generate a random direction
        // Tank moves in random direction and this changes every x random seconds
        // or if tank collides with any objects
        horizontal = UnityEngine.Random.Range(-1f, 1f);
        vertical = UnityEngine.Random.Range(-1f, 1f);

        nextDirectionUpdateInterval = UnityEngine.Random.Range(EnemyTankModel.SpawnChance / 2, EnemyTankModel.SpawnChance + 1);
    }

    void CanSeePlayer()
    {
        Vector3 start = EnemyTankView.BulletSpawnPosition.position;
        Vector3 direction = EnemyTankView.BulletSpawnPosition.forward.normalized; // Normalize the direction vector
        float distance = EnemyTankModel.Speed; // Or the desired distance

        // Calculate the end position based on the start position, direction, and distance
        Vector3 end = start + direction * distance;

        int layerMask = 1 << LayerMask.NameToLayer("Tank");

        // Perform the raycast
        RaycastHit raycastHit;
        bool hasHit = Physics.Raycast(start, end, out raycastHit, layerMask);

        // Now you can check if the raycast hit something and get information from the RaycastHit if needed
        if (hasHit)
        {
            GameObject hitObject = raycastHit.collider.gameObject;
            // Raycast getting hit on tankparts sometimes, so using
            // parent component check too
            if (hitObject.GetComponent<PlayerTankView>() != null || hitObject.GetComponentInParent<PlayerTankView>() != null)
            {
                triggerShoot = true;
            }
        }
    }
}