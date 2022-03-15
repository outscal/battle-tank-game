using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Tank
{
    public class Tank_Service : MonoBehaviour
    {
        [SerializeField] private Joystick joystick;
        [SerializeField] private Tank_View tankview;
        private Tank_Controller tankcontroller;
        [SerializeField] private Tank_ScriptableObject[] tank_ScriptableObjects;
        void Start()
        {
            StartGame();
        }
        void StartGame()
        {
            CreateNewTank();
        }
        private Tank_Controller CreateNewTank()
        {
            Tank_ScriptableObject tank_ScriptableObject = tank_ScriptableObjects[Random.Range(0, tank_ScriptableObjects.Length)];
            Tank_Model model = new Tank_Model(tank_ScriptableObject);
            Tank_Controller tankController = new Tank_Controller(model, tankview, joystick);
            return tankController;
        }
    }
}