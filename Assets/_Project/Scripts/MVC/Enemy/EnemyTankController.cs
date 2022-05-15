using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyTankController
{
    public EnemyTankView EnemyTankView { get; }
    public EnemyTankModel EnemyTankModel { get; }

    public EnemyTankController(EnemyTankModel tankModel, EnemyTankView tankPrefab, Vector3 spawnPlayer)
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
        EnemyTankView.sliderHealth.value = EnemyTankModel.currentHealth;
        EnemyTankView.fillImage.color = Color.Lerp(EnemyTankView.zeroHealthColor, EnemyTankView.fullHealthColor, EnemyTankModel.currentHealth / EnemyTankModel.TankHealth);
    }
    

    public void ApplyDamage(float damage)
    {
        EnemyTankModel.currentHealth -= damage;
        if (!EnemyTankView.enemyTankDead && EnemyTankModel.currentHealth <= 0)
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
        EnemyTankView.Destroy(EnemyTankView.gameObject);
    }
    public void Fire()
    {
        Rigidbody shellInstance = Object.Instantiate(EnemyTankView.shellPrefab, EnemyTankView.fireTransform.position, EnemyTankView.fireTransform.rotation) as Rigidbody;
        //EnemyTankModel.CurrentLaunchForce = EnemyTankModel.MaxLaunchForce;
        shellInstance.velocity = 10f * EnemyTankView.fireTransform.forward;
        //EnemyTankModel.CurrentLaunchForce = EnemyTankModel.MinLaunchForce;

        //shellInstance.AddForce(EnemyTankView.fireTransform.forward * 5f, ForceMode.Impulse);
        //shellInstance.AddForce(EnemyTankView.fireTransform.up * 7, ForceMode.Impulse);
    }
}

    //public void FireControl()
    //{
    //    EnemyTankView.aimSlider.value = EnemyTankModel.MinLaunchForce;

    //    if (EnemyTankModel.CurrentLaunchForce >= EnemyTankModel.MaxLaunchForce && !EnemyTankView.fired)
    //    {
    //        EnemyTankModel.CurrentLaunchForce = EnemyTankModel.MaxLaunchForce;
    //        Fire();
    //    }
    //    else if (EnemyTankView.fire1)
    //    {
    //        EnemyTankView.fired = false;
    //        EnemyTankModel.CurrentLaunchForce = EnemyTankModel.MinLaunchForce;
    //    }
    //    else if (EnemyTankView.fire0 && !EnemyTankView.fired)
    //    {
    //        EnemyTankModel.CurrentLaunchForce += EnemyTankModel.ChargeSpeed * Time.deltaTime;

    //        EnemyTankView.aimSlider.value = EnemyTankModel.CurrentLaunchForce;
    //    }
    //    else if (EnemyTankView.fire3 && !EnemyTankView.fired)
    //    {
    //        Fire();
    //    }
    //}

    //public void Fire()
    //{
    //    EnemyTankView.fired = true;

    //    Rigidbody shellInstance = GameObject.Instantiate(EnemyTankView.shellPrefab, EnemyTankView.fireTransform.position, EnemyTankView.fireTransform.rotation) as Rigidbody;

    //    //shellInstance.velocity = EnemyTankModel.CurrentLaunchForce * EnemyTankView.fireTransform.forward;
    //    shellInstance.velocity = 30f * EnemyTankView.fireTransform.forward;

    //    EnemyTankModel.CurrentLaunchForce = EnemyTankModel.MinLaunchForce;
    //}
