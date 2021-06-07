using UnityEngine;
public class HealthSliderRotation : MonoBehaviour
{
    
    //this script is to change the healthbar direction according to tank Movement
    public bool m_UseRelativeRotation = true;

    private Quaternion m_RelativeRotation;

    private void Start()
    {
        m_RelativeRotation = transform.parent.localRotation;
    }

    private void Update()
    {
        if (m_UseRelativeRotation)
            transform.rotation = m_RelativeRotation;
    }
}
