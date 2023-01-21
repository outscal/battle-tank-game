using UnityEngine;

public class BulletView : MonoBehaviour
{
    private BulletController bulletController;
    private EnemyView enemyView;
    private PlayerTankView playerTankView;
    public GameObject BulletParticleEffect;
    public bool isPlayerBullet = false;


    public void SetBulletController(BulletController _bulletController)
    {
        bulletController = _bulletController;
    }
    public void SetEnemyView(EnemyView _enemyView)
    {
        enemyView = _enemyView;
    }
    public void SetPlayerTankView(PlayerTankView _playerTankView)
    {
        playerTankView = _playerTankView;
    }


    private void OnCollisionEnter(Collision collision)
    {
        // Destroy the bullet game object when it collides with anything

        GameObject explosion = Instantiate(BulletParticleEffect, transform.position, Quaternion.identity);
        explosion.GetComponent<ParticleSystem>().Play();

        if (bulletController == null)
        {
            Debug.Log("bulletController Null");
            return;
        }
        if (collision.gameObject.GetComponent<PlayerTankView>() != null && !isPlayerBullet)
        {
            playerTankView = collision.gameObject.GetComponent<PlayerTankView>();
            Debug.Log("Bullet Collided");
            playerTankView.TakeDamage(bulletController.bulletModel.bulletDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.GetComponent<EnemyView>() != null && isPlayerBullet)
        {
            enemyView = collision.gameObject.GetComponent<EnemyView>();
            Debug.Log("Bullet Collided");
            enemyView.TakeDamage(bulletController.bulletModel.bulletDamage);
            Destroy(gameObject);
        }
        if (collision.gameObject.layer == 3)
        {
            // Code to destroy the bullet
            Destroy(gameObject);
        }

    }

}

