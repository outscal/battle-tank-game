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

    public GameObject GroundGameObject, LevelArtGameObject;

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

    public IEnumerator DestroyGround()
    {
        // Wait 1 second before destorying
        yield return new WaitForSeconds(1f);

        if (GroundGameObject == null)
            yield return null;

        foreach (Transform childTransform in GroundGameObject.transform)
        {
            GameObject.Destroy(childTransform.gameObject);

            // Wait 0.5 seconds after destorying
            yield return new WaitForSeconds(.5f);
        }

        yield return DestroyLevelArt();
    }

    public IEnumerator DestroyLevelArt()
    {
        // Wait 1 second before destorying
        yield return new WaitForSeconds(1f);

        if (LevelArtGameObject == null)
            yield return null;

        foreach (Transform childTransform in LevelArtGameObject.transform)
        {
            GameObject.Destroy(childTransform.gameObject);

            // Wait 0.5 seconds after destorying
            yield return new WaitForSeconds(.5f);
        }

        yield return DestroyPlayer();
    }

    public IEnumerator DestroyEnemies()
    {
        // Wait 1 second before destorying
        yield return new WaitForSeconds(1f);

        // Get Enemy Tanks in the scene
        // Currently enemies werent created under a parent gameObject 
        // So using object based search instead of string based tag search
        EnemyTankView[] EnemyTanks = GameObject.FindObjectsOfType<EnemyTankView>();
        foreach (EnemyTankView EnemyTank in EnemyTanks)
        {
            GameObject.Destroy(EnemyTank.gameObject);

            // Wait 0.5 seconds after destorying
            yield return new WaitForSeconds(.5f);
        }

        yield return DestroyGround();
    }

    public IEnumerator DestroyPlayer()
    {
        // Wait 1 second before destorying
        yield return new WaitForSeconds(1f);

        // Finally Destory the Player
        GameObject.Destroy(PlayerTankView.gameObject);
    }
}