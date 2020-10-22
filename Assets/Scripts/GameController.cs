using Tank;
using UnityEngine;

public class GameController : MonoBehaviour
{
    TankController playerTank;
    // Start is called before the first frame update
    void Start()
    {
       playerTank = TankService.Instance.CreateTank();
    }

}
