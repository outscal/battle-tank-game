using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class TankHealth : MonoBehaviour, IDamagable
{

    [SerializeField]protected float MaxHealth = 100f;
    [SerializeField]protected Slider healthSlider;
    [SerializeField]protected Image healthFillImage;
    [SerializeField]protected Color fullHealthColor = Color.green;
    [SerializeField]protected Color lowHealthColor= Color.red;
    [SerializeField]protected GameObject ExplosionPrefab;
    [SerializeField]protected ObjectPool objectPool;

    protected ParticleSystem explosionPrefab;
    protected Coroutine explosionCoroutine=null;

  

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
    protected float CurrentHealth;
    protected bool IsDead;
 
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    protected void Awake()
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

    protected void SetHealthColor()
    {
        healthSlider.value=CurrentHealth;
        healthFillImage.color=Color.Lerp(lowHealthColor,fullHealthColor,CurrentHealth/MaxHealth);
    }
    
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    protected void PlayerDead()
    {
        IsDead = true;
        if(explosionCoroutine==null){
            explosionCoroutine = StartCoroutine(playerDeathEffects());
        }
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    protected IEnumerator playExplosionParticleSystem(){
        explosionPrefab.transform.position=transform.position;
        explosionPrefab.gameObject.SetActive(true);
        explosionPrefab.Play();
        yield return new WaitForSeconds(explosionPrefab.duration);
        
    }

//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````
//``````````````````````````````````````````````````````````````````````````````````````````````````````````````````````

    protected IEnumerator playerDeathEffects(){
        
        yield return StartCoroutine(playExplosionParticleSystem());
        //enemy.CleanSlate();
        //levelTerrain.CleanSlate();

        gameObject.SetActive(false);
        explosionCoroutine = null;
    }    

}
