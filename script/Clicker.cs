using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Clicker : MonoBehaviour
{
    //Clicker
    public GameObject score;
    public float currentScore;
    [SerializeField] float clickPower = 1;
    [SerializeField] float scorePerSecond = 0;
    float scoreIncreasedPerSecond;
    private GameObject enemyAttacked;
    private GameObject enemyBoss;
    [SerializeField] GameObject SceneSituation;


    //MaxScoreTableAcces
     float scoreMax;
     string nameRanker;

    //Health
    public int maxHealth = 5;
    public int currentHealth;
    public HealthBar healthBar;

    //Different Items
    private bool Inciense;
    private bool Buda;
    private bool Sandals;
    private bool Counts;
    private bool Ropes;
    private bool Ilumination;

    // Start is called before the first frame update
    void Start()
    {
        //Clicker
        currentScore = 0;
        clickPower = 1;
        scorePerSecond = 0;
        score = GameObject.Find("ShownScore");
        SceneSituation = GameObject.Find("SceneSituation");

        //ItemsOperative
        Buda = PlayerPrefs.GetInt("Buda") == 1 ? true : false;
        Counts = PlayerPrefs.GetInt("Counts") == 1 ? true : false;
        Ilumination = PlayerPrefs.GetInt("Ilumination") == 1 ? true : false;
        Inciense = PlayerPrefs.GetInt("Inciense") == 1 ? true : false;
        Ropes = PlayerPrefs.GetInt("Ropes") == 1 ? true : false;
        Sandals = PlayerPrefs.GetInt("Sandals") == 1 ? true : false;

        // Different Items
        if (Inciense == true)
        {
            clickPower = 5;
        }

        if (Buda == true)
        {
            scorePerSecond = 5;
        }

        if (Counts == true)
        {
            maxHealth = 10;
        }

        //Health

        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);

    }

    void Update()
    {
        //Clicker

        
        score.GetComponent<TextMeshProUGUI>().text = ((int)currentScore).ToString();

        scoreIncreasedPerSecond = scorePerSecond * Time.deltaTime;

        currentScore = currentScore + scoreIncreasedPerSecond;

        //Different Items

        if (Ilumination == true)
        {
            clickPower++;
            scorePerSecond++;
        }

        //SAVE
  
        
        if (currentHealth <= 0)
        {
            PlayerPrefs.SetFloat("scoreMax", (int)currentScore);
            SceneManager.LoadScene("HighScores");
        }

    }

    public void BreathClick()
    {
        currentScore += clickPower;
        DamageEnemies();

        //Different ITEMS

        if (Sandals == true)
        {
            clickPower++;
        }

        if (Ropes == true)
        {
            GameObject EnemyRopped = GameObject.FindGameObjectWithTag("enemy");

            float enemySpeed = EnemyRopped.GetComponent<EnemyMovement>().speed;

            enemySpeed -= 0.01f;
        }

        
    }

    public void Damage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void DamageEnemies()
    {
        enemyAttacked = GameObject.FindGameObjectWithTag("enemy");
     
        if (enemyAttacked != null)
        {
            enemyAttacked.GetComponent<EnemyMovement>().DamageEnemy(1);
        }
       

        if (SceneSituation.GetComponent<SceneSituation>().BossScene == true)
        {
            enemyBoss = GameObject.FindGameObjectWithTag("Boss");
            enemyBoss.GetComponent<EnemyBoss>().DamageEnemy(1);
        }
    }
}
