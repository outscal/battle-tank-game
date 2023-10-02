using UnityEngine;
using UnityEngine.UI;

public class HealthViewer : MonoBehaviour
{
    [SerializeField] private bool isEnemy = false;
    [SerializeField] private TankView tankView;
    [SerializeField] private EnemyView enemyView;
    [SerializeField] private Image fillImage;
    [SerializeField] private Color fillColor, emptyColor;

    private Slider m_Slider;
    // Start is called before the first frame update
    void Start()
    {
        m_Slider = GetComponent<Slider>();
    }

    // Update is called once per frame
    void Update()
    {
        // Get Health & Max Health
        float health = isEnemy ? enemyView.Health : tankView.GetHealth;
        float maxhealth = isEnemy ? enemyView.MaxHealth : tankView.GetMaxHealth;

        // Clamp health from 0 to 100.
        float interpolate = (health / maxhealth);
        m_Slider.value = interpolate * 100f;

        // Lerp color based on health value.
        fillImage.color = Color.Lerp(emptyColor, fillColor, interpolate);
    }
}
