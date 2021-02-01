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
    public int floorMin { private get; set; }
    public int floorMax { private get; set; }
    public int holeReMin { private get; set; }
    public int holeReMax { private get; set; }
    public int heightMin { private get; set; }
    public int heightMax { private get; set; }

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
            int cubePosX = (int)lastCube.transform.position.x;
            int floor = Random.Range(floorMin, floorMax);
            int hole = Random.Range(holeReMin, holeReMax);
            int height = Random.Range(heightMin, heightMax);

            if (cubePosX == 0)
            {
                hole = 0;
            }
            for (int i = 0; i < floor; i++)
			{
				lastCube = Instantiate(prefabCube,
				new Vector3(cubePosX + i + 1 + hole, height, lastCube.transform.position.z),
				Quaternion.identity);
			}
		}
    }
}
