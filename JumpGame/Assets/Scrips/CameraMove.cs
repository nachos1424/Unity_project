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
        transform.LookAt(target.transform);
    }
}
