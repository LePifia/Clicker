using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneSituation : MonoBehaviour
{
    public GameObject playerClicker;
    public bool BossScene;
    public bool MainScene;
    // Start is called before the first frame update
    void Start()
    {
        playerClicker = GameObject.FindGameObjectWithTag("Player");
    }

    
}
