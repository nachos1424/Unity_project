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
        float result = Mathf.Lerp(transform.position.x, target.transform.position.x, 1f * Time.deltaTime);
        transform.position = new Vector3(result,
            transform.position.y, transform.position.z);
        transform.LookAt(target.transform);
    }
}
