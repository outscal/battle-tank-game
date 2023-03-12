using System;
using TankBattle.Tank.PlayerTank.MoveController;
using UnityEngine;
using UnityEngine.UI;

namespace TankBattle.Tank.View
{
    [RequireComponent(typeof(Rigidbody))]

    public class TankView : MonoBehaviour
    {
        [SerializeField] private Slider healthSlider;
        [SerializeField] private Image fillImage;
        [SerializeField] private Color fullHealthColor = Color.green;
        [SerializeField] private Color zeroHealthColor = Color.red;
        [SerializeField] private GameObject explosionPrefab;

        private MeshRenderer[] renderersOnTank;
        private Rigidbody rb;
        private AudioSource explosionAudio;
        private ParticleSystem explosionParticles;
        private float maxHealth;
        private float currentHealth;
        private bool isDead;

        private TankController tankController;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            renderersOnTank = GetComponentsInChildren<MeshRenderer>();

            explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
            explosionAudio = explosionParticles.GetComponent<AudioSource>();
            explosionParticles.gameObject.SetActive(false);
        }

        public void SetTankController(TankController _tankController)
        {
            tankController = _tankController;
        }

        public TankController GetTankController()
        {
            return tankController;
        }

        public void SetMaxHealth(float _maxHealth)
        {
            maxHealth = _maxHealth;
        }

        private void OnEnable()
        {
            isDead = false;
        }

        public void SetHealthUI()
        {
            if(tankController.GetTankModel.GetSetHealth <= 0f && !isDead)
            {
                OnDeath();
            }
            else
            {
            healthSlider.value = tankController.GetTankModel.GetSetHealth;
            fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, tankController.GetTankModel.GetSetHealth / maxHealth);
            }
        }

        private void OnDeath()
        {
            isDead = true;
            explosionParticles.transform.position = transform.position;
            explosionParticles.gameObject.SetActive(true);
            explosionParticles.Play();
            explosionAudio.Play();
            gameObject.SetActive(false);
        }

        public void SetColorOnAllRenderers(Color color)
        {
            for (int i = 0; i < renderersOnTank.Length; i++)
            {
                renderersOnTank[i].material.color = color;
            }
        }

        public Rigidbody getRigidbody()
        {
            return rb;
        }
    }
}