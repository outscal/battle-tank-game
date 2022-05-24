using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ETankController
{
    public ETankView EnemyTankView { get; }
    public ETankModel EnemyTankModel { get; }

    public ETankController(ETankModel tankModel, ETankView tankPrefab, Vector3 spawnPlayer)
    {
        EnemyTankModel = tankModel;
        EnemyTankView = Object.Instantiate(tankPrefab);
        //Debug.Log("Tank View Created", TankView);
        EnemyTankView.EnemyTankController = this;
        tankPrefab.transform.position = spawnPlayer;
        OnEnableFunction();
    }

    //internal void StartFunction()
    //{
    //    EnemyTankModel.ChargeSpeed = (EnemyTankModel.MaxLaunchForce - EnemyTankModel.MinLaunchForce) / EnemyTankModel.MaxChargeTime;
    //}

    public void OnEnableFunction()
    {
        EnemyTankModel.CurrentLaunchForce = EnemyTankModel.MinLaunchForce;
        EnemyTankView.aimSlider.value = EnemyTankModel.MinLaunchForce;
        EnemyTankModel.currentHealth = EnemyTankModel.TankHealth;
        EnemyTankView.enemyTankDead = false;
        SetHealthUI();
    }
    private void SetHealthUI()
    {
        EnemyTankView.sliderHealth.value =  EnemyTankModel.currentHealth / EnemyTankModel.TankHealth;
        EnemyTankView.fillImage.color = Color.Lerp(EnemyTankView.zeroHealthColor, EnemyTankView.fullHealthColor, EnemyTankModel.currentHealth / EnemyTankModel.TankHealth);
    }


    public void ApplyDamage(float damage)
    {
        EnemyTankModel.currentHealth -= damage;
        if (!EnemyTankView.enemyTankDead && EnemyTankModel.currentHealth <= 0f)
        {
            EnemyTankModel.currentHealth = 0;
            SetHealthUI();
            TankDestroy();
            return;
        }
        //Debug.Log("Enemy Take Damage " + EnemyTankModel.currentHealth);
        SetHealthUI();
    }
    private void TankDestroy()
    {
        EnemyTankView.enemyTankDead = true;
        EnemyTankView.gameObject.SetActive(false);
        ETankView.Destroy(EnemyTankView.gameObject);
    }
    public void Fire()
    {
        //Rigidbody shellInstance = Object.Instantiate(EnemyTankView.shellPrefab, EnemyTankView.fireTransform.position, EnemyTankView.fireTransform.rotation) as Rigidbody;
        //shellInstance.velocity = 10f * EnemyTankView.fireTransform.forward;
        //Debug.Log("enemy is shooting");
        BulletService.Instance.FireBullet(EnemyTankView.fireTransform.transform, EnemyTankModel.BulletType) ;

        //shellInstance.AddForce(EnemyTankView.fireTransform.forward * 5f, ForceMode.Impulse);
        //shellInstance.AddForce(EnemyTankView.fireTransform.up * 7, ForceMode.Impulse);
    }
}