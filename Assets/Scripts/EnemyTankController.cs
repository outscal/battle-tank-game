using UnityEngine;

public class EnemyTankController : MonoBehaviour
{
    [SerializeField] float moveSpeed;
    const float TURNSPEED=50f;
    private Rigidbody m_tankRigidbody;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] private Transform m_bulletPos;
    [SerializeField] float bulletForce = 1000f;
    [SerializeField] float health;
    [SerializeField] float damage;
    [SerializeField] Color color;
    // Start is called before the first frame update
    void Start()
    {
        m_tankRigidbody= GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void EnemyMovement(float horizontal, float vertical)
    {
        //EnemyMoveForward
        Vector3 Movement = transform.forward * vertical * moveSpeed * Time.deltaTime;
        m_tankRigidbody.AddForce(Movement);

        //EnemyTurnSideways
        float turn = horizontal * TURNSPEED * Time.deltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        m_tankRigidbody.MoveRotation(m_tankRigidbody.rotation * turnRotation);
    }

    public void FireBullet()
    {
        //Debug.Log("Bullet at "+m_bulletPos.position);
        GameObject bullet = Instantiate(bulletPrefab, m_bulletPos.position, m_bulletPos.rotation);
        bullet.GetComponent<Rigidbody>().AddForce(m_bulletPos.forward * bulletForce);
        bullet.GetComponent<Renderer>().material.color = color;
        Destroy(bullet, 3f);
    }

    public void SetEnemyTank(EnemyTankScriptableObject enemyTSO)
    {
        gameObject.name = enemyTSO.name;
        moveSpeed = enemyTSO.Speed;
        health = enemyTSO.Health;
        damage = enemyTSO.Damage;
        GameObject TankRenderers = gameObject.transform.GetChild(0).gameObject;
        string plColor = enemyTSO.TankColor.ToString();
        switch (plColor)
        {
            case "Blue":
                color = new Color32(20, 125, 248, 255);
                break;
            case "Red":
                color = new Color32(167, 22, 22, 255);
                break;
            case "Green":
                color = new Color32(57,116,57,255);
                break;
            case "Yellow":
                color = new Color32(150, 154, 15, 255);
                break;
        }
        for (int i = 0; i < TankRenderers.transform.childCount; i++)
        {
            TankRenderers.transform.GetChild(i).gameObject.GetComponent<Renderer>().material.color = color;
        }
    }
}
