using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    [SerializeField] GameObject RoundCount;

    [SerializeField] GameObject enemies;

    public int enemyWave;

    public int currentWaveEnemies = 1;

    private float enemyStartingXPosition = 15;

    private void Awake()
    {
        enemyWave = PlayerPrefs.GetInt("actualwave");
    }

    void Start()
    {
        
        StartCoroutine(EnemyInstantiator());
    }

    void Update()
    {
        RoundCount.GetComponent<TextMeshProUGUI>().text = (enemyWave).ToString();
        
    }

    IEnumerator EnemyInstantiator()
    {
        yield return new WaitForSeconds(1.5f);

        PlayerPrefs.SetInt("actualwave", enemyWave);

        if (currentWaveEnemies < enemyWave)
        {
            
            float enenmyYPosition = Random.Range(0, 15);

            Instantiate(enemies, new Vector3(enemyStartingXPosition, enenmyYPosition, 0), Quaternion.identity);

            currentWaveEnemies++;

            StartCoroutine(EnemyInstantiator());
        }
        else
        {
            currentWaveEnemies = 0;
            enemyWave++;

            
            StartCoroutine(EnemyInstantiator());
        }

        if (enemyWave == 10)
        {
            PlayerPrefs.SetInt("actualwave", enemyWave);
            SceneManager.LoadScene("Inventary");
        }
        
    }

    
}
