using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayGame : MonoBehaviour
{
    PlayerController player;
    LevelController datas;
    CubeSpawner spawner;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        datas = gameObject.GetComponent<LevelController>();
        spawner = gameObject.GetComponent<CubeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
