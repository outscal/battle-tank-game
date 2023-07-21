using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

public class EnemyTankFightState : EnemyTankState
{
    private PlayerTankView playerTank;
    private int fireRate = 2;

    private CancellationTokenSource cancellationTokenSource;
    public override void OnStateEnter()
    {
        base.OnStateEnter();
        playerTank = tankView.PlayerTank;
        cancellationTokenSource = new CancellationTokenSource();
        FireBullet();
    }
    private void Update()
    {
        tankController.RotateTank(playerTank.transform.position);
        
    }

    private async void FireBullet()
    {
        try {
            BulletService.Instance.GenerateBullet(tankView.BulletShooter.transform.position, tankView.transform.rotation);
            int waitTime = 1000 / fireRate;
            await Task.Delay(waitTime, cancellationTokenSource.Token);
            FireBullet();
        }
        catch(TaskCanceledException) { }
        
    }
    public override void OnStateExit()
    {
        base.OnStateExit();
        cancellationTokenSource.Cancel();
    }
}
