using UnityEngine;

public class BulletView : MonoBehaviour
{
    public GameObject prefab;

    public void Fire(Vector3 position, Quaternion rotation, float speed)
    {
        GameObject bullet = Instantiate(prefab, position, rotation);
        bullet.GetComponent<Rigidbody>().AddForce(bullet.transform.forward * speed);
    }

}