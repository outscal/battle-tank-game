using UnityEngine;
namespace Tanks.MVC
{
    public class TankController
    {

        public TankModel TankModel { get; }
        public TankView TankView { get; }
        public TankController(TankModel tankModel, TankView tankPrefab, Vector3 spawnPlayer)
        {
            TankModel = tankModel;
            TankView = GameObject.Instantiate<TankView>(tankPrefab);
            TankView.tankController = this;
            Debug.Log("Tank View Created", TankView);
            tankPrefab.transform.position = spawnPlayer;
        }

        public void PlayerTankMovement()
        {
            Vector3 movement = TankModel.tankSpeed * TankView.playerMoveVertical * Time.deltaTime * TankView.transform.forward;
            TankView.rb.MovePosition(TankView.rb.position + movement);
        }
        public void PlayerTankRotation()
        {
            float turn = TankView.playerTurnHorizontal * TankModel.tankTurnSpeed * Time.deltaTime;
            Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
            TankView.rb.MoveRotation(TankView.rb.rotation * turnRotation);
        }
    }
}