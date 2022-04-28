using UnityEngine;

public class HealthUI : MonoBehaviour
{
    public bool useRelativeRotaion = true;

    private Quaternion relativeRotation;
    
    void Start()
    {
        relativeRotation = transform.parent.localRotation;
    }

    void update()
    {
        if(useRelativeRotaion)
            transform.rotation = relativeRotation;
    }
}
