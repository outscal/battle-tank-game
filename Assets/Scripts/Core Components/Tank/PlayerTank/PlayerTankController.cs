using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerTankController : TankController
{

    PlayerTankModel PlayerTankModel;
    PlayerTankView PlayerTankView;

    Joystick joystick;
    Button shootButton;

    bool triggerShoot;
    bool DestroyFlag;

    public PlayerTankController(PlayerTankScriptableObject playerTankScriptableObject, Joystick _joystick, Button _shootButton) : base((TankScriptableObject)playerTankScriptableObject)
    {
        if (_joystick == null)
            throw new NullReferenceException("joystick object isn't available");
        if (_shootButton == null)
            throw new NullReferenceException("shootButton object isn't available");

        joystick = _joystick;
        shootButton = _shootButton;

        PlayerTankModel = new PlayerTankModel(playerTankScriptableObject);
        TankModel = (TankModel)PlayerTankModel;

        PlayerTankView = GameObject.Instantiate<PlayerTankView>(PlayerTankModel.PlayerTankViewPrefab);
        TankView = (TankView)PlayerTankView;

        PlayerTankView.PlayerTankController = this;
        TankView.TankController = (TankController)this;

        triggerShoot = false;
        DestroyFlag = false;

        shootButton.onClick.AddListener(ShootButtonAction);
    }

    public override void Update()
    {
        if (DestroyFlag)
            return;

        if (!PlayerTankModel.IsAlive)
        {
            DestroyFlag = true;
            PlayerTankView.Destroy();
            return;
        }

        horizontal = joystick.Horizontal;
        vertical = joystick.Vertical;

        base.Update();
    }

    public void FixedUpdate()
    {
        PlayerTankModel.TimeLeftForNextShot -= Time.fixedDeltaTime;

        if (triggerShoot)
        {
            if (PlayerTankModel.TimeLeftForNextShot <= 0)
            {
                PlayerTankModel.TimeLeftForNextShot = PlayerTankModel.FireRate;
                Shoot();
            }
            triggerShoot = false;
        }
    }

    void ShootButtonAction()
    {
        triggerShoot = true;
    }

    public IEnumerator Destroyer()
    {
        // Wait 1 second before destorying
        yield return new WaitForSeconds(1f);

        // Get Enemy Tanks in the scene
        EnemyTankView[] EnemyTanks = GameObject.FindObjectsOfType<EnemyTankView>();
        foreach (EnemyTankView EnemyTank in EnemyTanks)
        {
            GameObject.Destroy(EnemyTank.gameObject);

            // Wait 0.5 seconds after destorying
            yield return new WaitForSeconds(.5f);
        }

        // Wait 3 seconds before continue destorying
        yield return new WaitForSeconds(3f);

        // Find all GameObjects in the scene
        GameObject[] allObjectsInScene = GameObject.FindObjectsOfType<GameObject>();

        int layerMask = 1 << LayerMask.NameToLayer("Ground");
        foreach (GameObject gameObject in allObjectsInScene)
        {
            if ((layerMask & 1 << gameObject.layer) != 0)
            {
                GameObject.Destroy(gameObject);

                // Wait 0.5 seconds after destorying
                yield return new WaitForSeconds(.5f);
            }
        }

        // Wait 3 seconds before continue destorying
        yield return new WaitForSeconds(3f);

        allObjectsInScene = GameObject.FindObjectsOfType<GameObject>();

        layerMask = 1 << LayerMask.NameToLayer("LevelArt");
        foreach (GameObject gameObject in allObjectsInScene)
        {
            if ((layerMask & 1 << gameObject.layer) != 0)
            {
                GameObject.Destroy(gameObject);

                // Wait 0.5 seconds after destorying
                yield return new WaitForSeconds(.5f);
            }
        }

        // Wait 3 seconds before continue destorying
        yield return new WaitForSeconds(3f);

        // Finally Destory the Player
        GameObject.Destroy(PlayerTankView.gameObject);
    }
}