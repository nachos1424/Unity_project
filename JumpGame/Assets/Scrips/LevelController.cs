using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LevelData
{
    public float time;
    public float speed;
    public float floorMin;
    public float floorMax;
    public float holeMin;
    public float holeMax;
    public float heightMin;
    public float heightMax;
}

public class LevelController : MonoBehaviour
{
    [SerializeField] public TextAsset levelData;
    public List<LevelData> levelDatas = new List<LevelData>();
    // 현재 레벨
    public int currLevel = 0;
    public float timer { get; set; }
	// Start is called before the first frame update
    void Start()
	{
        LoadData();
        timer = 0f;
    }
    private void Update()
	{
		timer += Time.deltaTime;
		if (timer > levelDatas[0].time && timer <= levelDatas[1].time)
		{
			currLevel = 0;
        }
        else if (timer > levelDatas[1].time && timer <= levelDatas[2].time)
        {
            currLevel = 1;
        }
        else if (timer > levelDatas[2].time && timer <= levelDatas[3].time)
        {
            currLevel = 2;
        }
        else if (timer > levelDatas[3].time && timer <= levelDatas[4].time)
        {
            currLevel = 3;
        }
        else
        {
            currLevel = 4;
        }
        //Debug.Log("time" + timer);
    }
	void LoadData()
    {
        string text = levelData.text;
        string[] lines = text.Split('\n');
        foreach (var line in lines)
        {
            if (line == "")
                break;
            string[] words = line.Split('\t');

            LevelData data = new LevelData();
            int index = 0;
            foreach (var word in words)
            {
                if (word == "") continue;
                if (word[0] == '#') break;
                switch (index)
                {
                    case 0:
                        data.time = float.Parse(word);
                        break;
                    case 1:
                        data.speed = float.Parse(word);
                        break;
                    case 2:
                        data.floorMin = float.Parse(word);
                        break;
                    case 3:
                        data.floorMax = float.Parse(word);
                        break;
                    case 4:
                        data.holeMin = float.Parse(word);
                        break;
                    case 5:
                        data.holeMax = float.Parse(word);
                        break;
                    case 6:
                        data.heightMin = float.Parse(word);
                        break;
                    case 7:
                        data.heightMax = float.Parse(word);
                        break;
                }
                index++;
                if (index >= 8)
                {
                    levelDatas.Add(data);
                    index = 0;
                }
            }
        }
    }
}
