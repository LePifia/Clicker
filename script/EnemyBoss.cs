using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyBoss : MonoBehaviour
{

    //Health

    [SerializeField] HealthBar healthBar;
    [SerializeField] int maxHealth = 2;
    [SerializeField] int currentHealth;

    public GameObject enemySpawner;
    private GameObject enemyUnit;
    public bool enemyGoal;

    public GameObject playerClicker;



    // Start is called before the first frame update
    void Start()
    {
        enemyUnit = gameObject;
        enemySpawner = GameObject.FindGameObjectWithTag("Respawn");
        playerClicker = GameObject.FindGameObjectWithTag("Player");

        //Health
        maxHealth = maxHealth + enemySpawner.GetComponent<Enemy>().enemyWave * 25;
        currentHealth = maxHealth;
       
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(DamageTime());
    }

    // Update is called once per frame
    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(enemyUnit, 1F);
            SceneManager.LoadScene("MainGame");
        }
    }

    public void DamageEnemy(int damage)
    {
        damage = 1;
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void DamagePlayer()
    {
        playerClicker.GetComponent<Clicker>().Damage(1);
        StartCoroutine(DamageTime());
    }

    public IEnumerator DamageTime()
    {
        yield return new WaitForSeconds(3f);
        Debug.Log("attacked");
        DamagePlayer();

    }
}
