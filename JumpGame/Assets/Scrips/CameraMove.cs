using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    GameObject target;
    // Start is called before the first frame update
    void Start()
    {
        target = FindObjectOfType<PlayerController>().gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        //float resultX = Mathf.Lerp(transform.position.x, target.transform.position.x, 10f * Time.deltaTime);
        //float resultY = Mathf.Lerp(transform.position.y, target.transform.position.y + 1, 10f * Time.deltaTime);
		transform.position = new Vector3(target.transform.position.x,
           target.transform.position.y + 1, transform.position.z);
	}
}
