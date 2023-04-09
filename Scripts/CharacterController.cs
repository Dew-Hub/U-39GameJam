using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;


public class CharacterController : MonoBehaviour
{
    public int maxHealth = 100; 
    public int maxEnergy = 100; 
    public int maxAttack = 50;  
    public int maxShield = 50;  
    public int attackCheck = 0;

    public int maxWormHealth = 150; 

    private int currentHealth;  
    private int currentEnergy; 
    private int currentAttack; 
    private int currentShield; 

    private int currentWormHealth;  

    public Button healthButton;  
    public Button energyButton;   
    public Button attackButton;     
    public Button shieldButton;  

    public Text healthText;  
    public Text energyText; 

    public Text WormhealthText;  

    public Animator animatorHero;
    public Animator animatorWorm;
    public Animator animatorDeath;

    Scene sahne;
    void Start()
    {
        currentHealth = maxHealth;
        currentEnergy = maxEnergy;
        currentWormHealth = maxWormHealth;
        currentAttack = 0;
        currentShield = 0;
        healthButton.onClick.AddListener(OnHealthButtonClick);
        energyButton.onClick.AddListener(OnEnergyButtonClick);
        attackButton.onClick.AddListener(OnAttackButtonClick);
        shieldButton.onClick.AddListener(OnShieldButtonClick);
        animatorHero.GetComponent<Animator>();
        animatorWorm.GetComponent<Animator>();
        animatorDeath.GetComponent<Animator>();
        sahne = SceneManager.GetActiveScene();
    }

    void Update()
    {
        
        healthText.text = currentHealth + "/" + maxHealth + " HP";
        energyText.text = currentEnergy + "/" + maxEnergy + " ENG";
        WormhealthText.text = currentWormHealth + "/" + maxWormHealth + " HP";

        if (currentEnergy < 16)
            attackButton.interactable = false;
        else
            attackButton.interactable = true;

        if (currentEnergy < 21)
            healthButton.interactable = false;
        else
            healthButton.interactable = true;

        if (currentEnergy < 21)
            shieldButton.interactable = false;
        else
            shieldButton.interactable = true;
    }

    void OnHealthButtonClick()
    {
        Heal();
        EnemyTurn();
    }

    void OnEnergyButtonClick()
    {
        ChargeAttack();
        EnemyTurn();
    }

    void OnAttackButtonClick()
    {
        int heroRandom = Random.Range(0, 3);
        animatorHero.SetTrigger("Attack0" + heroRandom.ToString());
        Attack();
        EnemyTurn();
    }

    void OnShieldButtonClick()
    {
        UseShield();
        if(currentShield != 1)
            EnemyTurn();
    }
    
    public void Heal()
    {
        int healAmount = Random.Range(18, 41); 
            
        if (currentEnergy > 5)  
            currentHealth += healAmount;
            
        if (currentHealth > maxHealth)
            currentHealth = maxHealth;
      
        currentEnergy -= 20;
        if (currentEnergy < 0)
            currentEnergy = 0;
    }

    public void ChargeAttack()
    {
        int energyAmount = Random.Range(40, 61); 
        currentEnergy += energyAmount;
        if (currentEnergy > maxEnergy)
            currentEnergy = maxEnergy;

    }

    public void Attack()
    {
            int attackAmount = Random.Range(10, 21);  
            currentAttack += attackAmount;
            if (currentAttack > maxAttack)
                currentAttack = maxAttack;
            currentEnergy -= 15;
    }

    public void UseShield()
    {
        int shieldAmount = Random.Range(1, 3);  
        currentShield = shieldAmount;
        currentEnergy -= 20;
    }
  
    public void EnemyTurn()
    {
        StartCoroutine(PlayAnimationWithDelay());
        int enemyWormAttack = Random.Range(10, 21);
        currentHealth -= enemyWormAttack;
        if (currentHealth < 0)
            currentHealth = 0;
        currentWormHealth -= currentAttack;
        if (currentWormHealth <= 0)
        {
            currentWormHealth = 0;
            animatorWorm.SetTrigger("KillWorm");
            animatorDeath.SetTrigger("kill");
            StartCoroutine(WaitPlayer());
        }
        currentAttack = 0;
        currentShield = 0;
    }
    IEnumerator WaitPlayer()
    {
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene(sahne.buildIndex + 1);

    }
    IEnumerator PlayAnimationWithDelay()
    {
        yield return new WaitForSeconds(0.15f);
        animatorWorm.SetTrigger("AttackWorm");

        yield return new WaitForSeconds(0.15f);
        animatorDeath.SetTrigger("attack");

        yield return new WaitForSeconds(0.17f);
        animatorHero.SetTrigger("Hit00");
    }
}