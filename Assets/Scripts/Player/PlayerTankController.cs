using UnityEngine;

public class PlayerTankController
{
    public PlayerTankModel playerModel;
    public PlayerTankView PlayerView;

    public PlayerTankController(PlayerTankModel _playerTankModel, PlayerTankView _playerView)
    {
        this.playerModel = _playerTankModel;
        this.PlayerView = _playerView;
        PlayerView.SetPlayerTankController(this);
    }


    public void Update()
    {
        playerModel.playerPosition = PlayerView.transform.position;

        if (Input.GetKey(KeyCode.UpArrow))
        {
            Move(1);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            Move(-1);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            Rotate(-1);
        }
        if (Input.GetKey(KeyCode.RightArrow))
        {
            Rotate(1);
        }
        // if (Input.GetMouseButtonDown(0))
        // {
        //     //Shoot();
        // }
    }

    public void Move(float direction)
    {
        PlayerView.transform.position += PlayerView.transform.forward * direction * playerModel.Speed * Time.deltaTime;
    }

    public void Rotate(float direction)
    {
        PlayerView.transform.Rotate(Vector3.up * direction * playerModel.RotationSpeed * Time.deltaTime);
    }

    public void Shoot(Transform spawnPoint)
    {
        BulletService.Instance.SpawnBullet(spawnPoint, spawnPoint.transform.rotation);
    }

    
}
