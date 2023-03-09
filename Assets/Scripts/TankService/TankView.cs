using System;
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

        private MeshRenderer[] rendererArray;
        private Rigidbody rb;
        private AudioSource explosionAudio;
        private ParticleSystem explosionParticles;
        private float maxHealth;
        private float currentHealth;
        private bool isDead;

        private void Awake()
        {
            rb = GetComponent<Rigidbody>();
            rendererArray = GetComponentsInChildren<MeshRenderer>();

            explosionParticles = Instantiate(explosionPrefab).GetComponent<ParticleSystem>();
            explosionAudio = explosionParticles.GetComponent<AudioSource>();
            explosionParticles.gameObject.SetActive(false);
        }

        public void SetHealthFull(float _maxHealth)
        {
            maxHealth = _maxHealth;
            currentHealth = maxHealth;
            SetHealthUI();
        }

        private void OnEnable()
        {
            isDead = false;
        }

        public void ReduceHealth(float health)
        {
            currentHealth = health;
            SetHealthUI();
        }

        private void SetHealthUI()
        {
            if(currentHealth <= 0f && !isDead)
            {
                OnDeath();
            }
            else
            {
            healthSlider.value = currentHealth;
            fillImage.color = Color.Lerp(zeroHealthColor, fullHealthColor, currentHealth / maxHealth);
            }
        }

        public void TakeDamage(float amount)
        {
            currentHealth -= amount;
            SetHealthUI();
        }

        public void OnDeath()
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
            for (int i = 0; i < rendererArray.Length; i++)
            {
                rendererArray[i].material.color = color;
            }
        }

        public Rigidbody getRigidbody()
        {
            return rb;
        }
    }
}