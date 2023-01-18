using UnityEngine;

public class PlayerTankView : MonoBehaviour
{
    private new Renderer renderer;
    private PlayerTankService playerTankService;
    private Transform bulletSpawnPoint;
    private BulletScriptableObject bulletScriptableObject;


    private void Start()
    {
        renderer = GetComponent<Renderer>();
        playerTankService = FindObjectOfType<PlayerTankService>();

        GameObject cam = GameObject.Find("Main Camera");
        cam.transform.SetParent(transform);
        cam.transform.position = new Vector3(0f, 8f, -4f);
    }



    public void FireBullet()
    {
        PlayerTankModel playerTankModel = GetComponent<PlayerTankModel>();
        playerTankModel.Shoot();
    }

    public void UpdateColor(Color color)
    {
        renderer.material.color = color;
    }

    public void UpdatePosition(Vector3 position)
    {
        transform.position = position;
    }
}
