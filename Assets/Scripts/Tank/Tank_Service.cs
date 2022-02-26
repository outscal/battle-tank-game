using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank_Service : MonoBehaviour
{
    public Tank_View tankview;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }
    public void StartGame()
    {
        for (int i = 0; i < 1; i++)
        {
            CreateNewTank();
        }

    }

    private Tank_Controller CreateNewTank()
    {
        Tank_Model model = new Tank_Model(5, 100f);
        Tank_Controller tankController = new Tank_Controller(model, tankview);
        return tankController;
    }

}
