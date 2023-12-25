using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Boss : MonoBehaviour
{
    [SerializeField] GameObject RoundCount;

    [SerializeField] GameObject enemies;

    public int enemyWave = 1;

    public int currentWaveEnemies = 1;

    private float enemyStartingXPosition = 15;


    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(EnemyInstantiator());
    }

    // Update is called once per frame
    void Update()
    {
        RoundCount.GetComponent<TextMeshProUGUI>().text = (enemyWave).ToString();
        
    }

    IEnumerator EnemyInstantiator()
    {
        yield return new WaitForSeconds(1.5f);

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

            PlayerPrefs.SetInt("actualwave", enemyWave);
            StartCoroutine(EnemyInstantiator());
        }

        if (enemyWave == 10)
        {
            SceneManager.LoadScene("Inventary");
        }
        
    }

    
}
