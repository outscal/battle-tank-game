using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BattleTank
{
    public class TankService : MonoBehaviour
    {
        public TankView tankView;
        public GameObject wrongTankView;

        private ServicePoolTank servicePoolTank;

        //public TankScriptableObject[] tankConfiguration;
        public TankScriptableObjectList tankList;

        private void Start()
        {
            servicePoolTank = GetComponent<ServicePoolTank>();
            StartGame();
        }
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                TankController tankController = CreateNewTank(0);
                StartCoroutine(ReturnTank(tankController));
            }
        }

        public void StartGame()
        {
            for (int i = 0; i < 3; i++)
            {
                TankController tankController = CreateNewTank(i);
                StartCoroutine(ReturnTank(tankController));
            }
        }

        IEnumerator ReturnTank(TankController tankController)
        {
            yield return new WaitForSeconds(5f);
            tankController.Disable();
            servicePoolTank.ReturnItems(tankController);
        }

        private TankController CreateNewTank(int index)
        {
            //TankScriptableObject tankScriptableObject = tankConfiguration[2];
            TankScriptableObject tankScriptableObject = tankList.tanks[index];
            Debug.Log("Creating Tank with Type : " + tankScriptableObject.TankName);

            //TankModel model = new TankModel(TankType.Blue,5, 100f);
            TankModel model = new TankModel(tankScriptableObject);
            //TankController tank = new TankController(model, tankView);

            TankController tank = servicePoolTank.GetTank(model, tankView);
            tank.Enable();
            return tank;
        }
    }
}