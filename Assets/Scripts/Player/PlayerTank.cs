using UnityEngine;
public class PlayerTank : MonoBehaviour
{
    public PlayerTankModel playerTankModel;
    public Vector3 currentPosition;


    private void Start()
    {
        PlayerTankService service = GetComponent<PlayerTankService>();
        service.playerTankModel = playerTankModel;
    }

    void Update()
    {
        currentPosition = transform.position;
    }
}
