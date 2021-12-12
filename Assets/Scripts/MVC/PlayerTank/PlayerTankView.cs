using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Rigidbody))]
public class PlayerTankView : MonoBehaviour, IDamagable
{
    public GameObject Turret;
    public GameObject ExplosionEffectPrefab;
    public Slider HealthSlider;
    public Image FillImage;

    [HideInInspector]
    public AudioSource explosionSound;
    [HideInInspector]
    public ParticleSystem explosionParticles;

    private PlayerTankController tankController;

    private void Awake()
    {
        explosionParticles = Instantiate(ExplosionEffectPrefab).GetComponent<ParticleSystem>();
        explosionSound = explosionParticles.GetComponent<AudioSource>();
        explosionParticles.gameObject.SetActive(false);
    }

    private void Start()
    {
        tankController.SetHealthUI();
    }

    public void SetTankControllerReference(PlayerTankController controller)
    {
        tankController = controller;
    }

    public void Death()
    {
        Destroy(gameObject);
    }

    public void TakeDamage(int damage)
    {
        tankController.TakeDamage(damage); 
    }
}
