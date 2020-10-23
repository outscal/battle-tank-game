using Tank;
using UnityEngine;

public class GameController : MonoBehaviour
{
    private TankController playerTank;

    void Start()
    {
        CreatePlayer();
    }

    void CreatePlayer()
    {
        playerTank = TankService.Instance.CreateTank();
    }
}
