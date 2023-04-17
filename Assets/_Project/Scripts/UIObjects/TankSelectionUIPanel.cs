using BattleTank.Enum;
using BattleTank.Services;
using UnityEngine;
using UnityEngine.UI;

namespace BattleTank.UI
{
    public class TankSelectionUIPanel : MonoBehaviour
    {
        [SerializeField] private Button blueTank;
        [SerializeField] private Button greenTank;
        [SerializeField] private Button redTank;

        private void Awake()
        {
            blueTank.onClick.AddListener(CreateBlueTank);
            greenTank.onClick.AddListener(CreateGreenTank);
            redTank.onClick.AddListener(CreateRedTank);
        }

        private void CreateBlueTank()
        {
            PlayerTankService.Instance.SpawnPlayerTank(TankType.Blue);
            gameObject.SetActive(false);
        }

        private void CreateGreenTank()
        {
            PlayerTankService.Instance.SpawnPlayerTank(TankType.Green);
            gameObject.SetActive(false);
        }

        private void CreateRedTank()
        {
            PlayerTankService.Instance.SpawnPlayerTank(TankType.Red);
            gameObject.SetActive(false);
        }
    }
}