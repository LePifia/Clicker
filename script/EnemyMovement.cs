using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public Vector3 targetPosition;
    public float speed = 2;

    //Health
    [SerializeField] int maxHealth;
    [SerializeField] int currentHealth;

    

    private GameObject enemyUnit;
    public bool enemyGoal;
    public GameObject playerClicker;
    public GameObject enemySpawner;

    

    // Start is called before the first frame update
    void Start()
    {

        playerClicker = GameObject.FindGameObjectWithTag("Player");
        enemySpawner = GameObject.FindGameObjectWithTag("Respawn");
        speed = 2;
        enemyUnit = gameObject;
        maxHealth = enemySpawner.GetComponent<Enemy>().enemyWave;
        currentHealth = maxHealth;

        
    }

    // Update is called once per frame
    void Update()
    {

        targetPosition = new Vector3(-10, -2.5F , 0);

        enemyUnit.transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

        if (currentHealth <= 0)
        {
            Destroy(enemyUnit, 1F);
        }

        
    }

    private void OnTriggerEnter2D(Collider2D dataFromCollision)
    {
        if (!enemyGoal && dataFromCollision.gameObject.name == "playerCollider")
        {
            Debug.Log("Player2 Scored");
            Destroy(enemyUnit, 1F);
            playerClicker.GetComponent<Clicker>().Damage(1);
        } 
    }

    public void DamageEnemy(int damage)
    {
        damage = 1;
        currentHealth -= damage;

        
    }
}
