using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TankHealth : MonoBehaviour
{
    [SerializeField]private float MaxHealth = 100f;
    [SerializeField]private Slider healthSlider;
    [SerializeField]private Image healthFillImage;
    [SerializeField]private Color fullHealthColor = Color.green;
    [SerializeField]private Color lowHealthColor= Color.red;
    [SerializeField]private GameObject ExplosionPrefab;
    [SerializeField]private ObjectPool objectPool;

    private ParticleSystem explosionPrefab;
    private Coroutine explosionCoroutine=null;

  

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
    private float CurrentHealth;
    private bool IsDead;
 
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void Awake()
    {
        explosionPrefab = Instantiate(ExplosionPrefab).GetComponent<ParticleSystem>();
        explosionPrefab.gameObject.SetActive(false);

        CurrentHealth=MaxHealth;
        IsDead=false;
        SetHealthColor();
    }


//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    public void TakeDamage(float takeDamage)
    {
        CurrentHealth -=takeDamage;
        SetHealthColor();
        if(CurrentHealth<=0f && !IsDead)
        {
            PlayerDead();
        }
    }
    
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void SetHealthColor()
    {
        healthSlider.value=CurrentHealth;
        healthFillImage.color=Color.Lerp(lowHealthColor,fullHealthColor,CurrentHealth/MaxHealth);
    }
    
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private void PlayerDead()
    {
        IsDead = true;
        if(explosionCoroutine==null){
            explosionCoroutine = StartCoroutine(playerDeathEffects());
        }
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private IEnumerator playExplosionParticleSystem(){
        explosionPrefab.transform.position=transform.position;
        explosionPrefab.gameObject.SetActive(true);
        explosionPrefab.Play();
        yield return null;
        
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    private IEnumerator playerDeathEffects(){
        
        yield return StartCoroutine(playExplosionParticleSystem());
        //enemy.CleanSlate();
        //levelTerrain.CleanSlate();

        gameObject.SetActive(false);
        objectPool.spawner();
        explosionCoroutine = null;
    }    

}
