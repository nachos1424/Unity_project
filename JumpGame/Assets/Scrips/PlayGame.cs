using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayGame : MonoBehaviour
{
    PlayerController player;
    LevelController levelController;
    CubeSpawner spawner;
    int currLevel = -1;
    // text
    public Text timer;
    public Text distance;
    float bestDistance;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        levelController = gameObject.GetComponent<LevelController>();
        spawner = gameObject.GetComponent<CubeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (currLevel == levelController.currLevel) return;
		currLevel = levelController.currLevel;

        player.speed = levelController.levelDatas[currLevel].speed;

		spawner.floorMax = (int)levelController.levelDatas[currLevel].floorMax;
        spawner.floorMin= (int)levelController.levelDatas[currLevel].floorMin;

        spawner.holeReMax = (int)levelController.levelDatas[currLevel].holeMax;
        spawner.holeReMin = (int)levelController.levelDatas[currLevel].holeMin;

        spawner.heightMax = (int)levelController.levelDatas[currLevel].heightMax;
        spawner.heightMin = (int)levelController.levelDatas[currLevel].heightMin;
    }
}
