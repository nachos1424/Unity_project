using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test : MonoBehaviour
{
    Rigidbody myRigidbody;
    Vector3 rotation;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        rotation = transform.rotation.eulerAngles;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            rotation += Vector3.right * 90 * Time.deltaTime;
            myRigidbody.MoveRotation(Quaternion.Euler(rotation));
        }
    }
}
