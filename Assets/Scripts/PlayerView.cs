using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerView : MonoBehaviour {

    private PlayerController playerController;

    [SerializeField]
    private GameObject bulletSpawnPos;

    public GameObject BulletSpawnPos
    {
        get { return bulletSpawnPos; }
    }

    public void SetController(PlayerController playerController)
    {
        this.playerController = playerController;
    }

    public void MoveTank(float hVal, float vVal, float speed, float rotateSpeed)
    {
        transform.Translate(vVal * Vector3.forward * speed * Time.deltaTime);
        transform.Rotate(new Vector3(0, hVal, 0) * rotateSpeed);
    }

    public void Shoot(BulletController bulletController)
    {
        bulletController.SpawnBullet(transform.forward, bulletSpawnPos.transform.position, transform.eulerAngles);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            PlayerManager.Instance.DestroyPlayer(playerController);

            PlayerDie();
        }
    }

    private void PlayerDie()
    {
        Destroy(gameObject);
    }
}

	