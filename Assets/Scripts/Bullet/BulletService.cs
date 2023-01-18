using UnityEngine;

public class BulletService : MonoSingletonGeneric <BulletService>
{
    public BulletScriptableObjectList bulletScriptableObjectList;

    public BulletService(BulletScriptableObjectList _bulletScriptableObjectList)
    {
        bulletScriptableObjectList = _bulletScriptableObjectList;
    }

    public void SpawnBullet(BulletType bulletType, Vector3 position, Quaternion rotation)
    {
        BulletScriptableObject bulletScriptableObject = GetBulletScriptableObject(bulletType);
        if (bulletScriptableObject != null)
        {
            GameObject bullet = Object.Instantiate(bulletScriptableObject.prefab, position, rotation);
        }
    }

    private BulletScriptableObject GetBulletScriptableObject(BulletType bulletType)
    {
        // Iterate through the list of bullet scriptable objects and return the one that matches the bulletType
        for (int i = 0; i < bulletScriptableObjectList.BulletList.Length; i++)
        {
            if (bulletScriptableObjectList.BulletList[i].bulletType == bulletType)
            {
                return bulletScriptableObjectList.BulletList[i];
            }
        }
        return null;
    }
}
