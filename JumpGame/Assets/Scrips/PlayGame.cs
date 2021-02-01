using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayGame : MonoBehaviour
{
    PlayerController player;
    LevelController levelController;
    CubeSpawner spawner;
    int currLevel = -1;
    // text
    public Text t_Timer;
    public Text t_Distance;
    public Text t_BestDistance;
    public GameObject gameover;
    float currTime = 0f;
    float currDistance = 0f;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindWithTag("Player").GetComponent<PlayerController>();
        levelController = gameObject.GetComponent<LevelController>();
        spawner = gameObject.GetComponent<CubeSpawner>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y < -5f)
            EndGame();

		// 시간과 거리 설정
		currTime = levelController.timer;
		currDistance = player.transform.position.x;
		// 텍스트에 저장
		t_Timer.text = "Time : " + (int)currTime;
		t_Distance.text = "Distance : " + (int)currDistance;
        if (Input.GetKeyDown(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }

		#region set level
		if (currLevel != levelController.currLevel)
        {
            currLevel = levelController.currLevel;

            player.speed = levelController.levelDatas[currLevel].speed;

            spawner.floorMax = (int)levelController.levelDatas[currLevel].floorMax;
            spawner.floorMin = (int)levelController.levelDatas[currLevel].floorMin;

            spawner.holeReMax = (int)levelController.levelDatas[currLevel].holeMax;
            spawner.holeReMin = (int)levelController.levelDatas[currLevel].holeMin;

            spawner.heightMax = (int)levelController.levelDatas[currLevel].heightMax;
            spawner.heightMin = (int)levelController.levelDatas[currLevel].heightMin;
        }
		#endregion
	}
    void EndGame()
    {
        gameover.SetActive(true);
        player.gameObject.SetActive(false);
        float bestDistance = PlayerPrefs.GetFloat("BestDistance");

        if (bestDistance <= currDistance)
        {
            bestDistance = currDistance;
            PlayerPrefs.SetFloat("BestDistance", bestDistance);
        }
        t_BestDistance.text = "Best Score : " + (int)bestDistance;
    }
}
