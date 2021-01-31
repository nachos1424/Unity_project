using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField]
    GameObject prefabCube;

    Vector3 startPosition;
    GameObject lastCube;
    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        startPosition = new Vector3(player.transform.position.x, 0f, player.transform.position.z);
        lastCube = Instantiate(prefabCube, startPosition, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.x + 10 > lastCube.transform.position.x)
        {
            int lastPosX = (int)lastCube.transform.position.x;

            for(int i = 0; i < 10; i++)
            {
                lastCube = Instantiate(prefabCube,
                    new Vector3(lastPosX + i + 1, lastCube.transform.position.y, lastCube.transform.position.z),
                    Quaternion.identity);
            }
        }
    }
}
