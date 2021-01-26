using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    public GameObject childPrefab;
    GameObject childTransform1;
    GameObject childTransform2;
    GameObject childTransform3;
    GameObject childTransform4;
    GameObject childTransform5;
    GameObject childTransform6;
    GameObject childTransform7;
    GameObject childTransform8;
    // Start is called before the first frame update
    void Start()
    {
        childTransform1 = Instantiate(childPrefab, transform);
        childTransform2 = Instantiate(childPrefab, transform);
        childTransform3 = Instantiate(childPrefab, transform);
        childTransform4 = Instantiate(childPrefab, transform);
        childTransform5 = Instantiate(childPrefab, transform);
        childTransform6 = Instantiate(childPrefab, transform);
        childTransform7 = Instantiate(childPrefab, transform);
        childTransform8 = Instantiate(childPrefab, transform);
        // 자신의 전역 위치를 (0,-1,0)으로 변경
        //transform.position = new Vector3(0, -1, 0);
        // 자식의 지역위치를 (0,2,0)으로 변경
        childTransform1.transform.localPosition = new Vector3(0, 4, 0);
        childTransform2.transform.localPosition = new Vector3(0, -4, 0);
        childTransform3.transform.localPosition = new Vector3(4, 0, 0);
        childTransform4.transform.localPosition = new Vector3(-4, 0, 0);
        childTransform5.transform.localPosition = new Vector3(-2.8f, -2.8f, 0);
        childTransform6.transform.localPosition = new Vector3(-2.8f, 2.8f, 0);
        childTransform7.transform.localPosition = new Vector3(2.8f, 2.8f, 0);
        childTransform8.transform.localPosition = new Vector3(2.8f, -2.8f, 0);

        // 자신의 전역 회전을 (0,0,30)으로 변경
        //transform.rotation = Quaternion.Euler(0, 0, 30);
        // 자식의 전역 회전을 (0,60,0)으로 변경
        childTransform1.transform.localRotation = Quaternion.Euler(0, 30, 0);
        childTransform2.transform.localRotation = Quaternion.Euler(0, 60, 0);
        childTransform3.transform.localRotation = Quaternion.Euler(0, 90, 0);
        childTransform4.transform.localRotation = Quaternion.Euler(0, 120, 0);
        childTransform5.transform.localRotation = Quaternion.Euler(0, 150, 0);
        childTransform6.transform.localRotation = Quaternion.Euler(0, 180, 0);
        childTransform7.transform.localRotation = Quaternion.Euler(0, 210, 0);
        childTransform8.transform.localRotation = Quaternion.Euler(0, 240, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.LeftArrow))
        {
        }
            transform.Rotate(new Vector3(0, 0, 180) * Time.deltaTime);
            childTransform1.transform.Rotate(new Vector3(0, 180, 60) * Time.deltaTime, Space.World);
            childTransform2.transform.Rotate(new Vector3(0, 180, 60) * Time.deltaTime, Space.World);
            childTransform3.transform.Rotate(new Vector3(0, 180, 60) * Time.deltaTime, Space.World);
            childTransform4.transform.Rotate(new Vector3(0, 180, 60) * Time.deltaTime, Space.World);
            childTransform5.transform.Rotate(new Vector3(0, 180, 60) * Time.deltaTime, Space.World);
            childTransform6.transform.Rotate(new Vector3(0, 180, 60) * Time.deltaTime, Space.World);
            childTransform7.transform.Rotate(new Vector3(0, 180, 60) * Time.deltaTime, Space.World);
            childTransform8.transform.Rotate(new Vector3(0, 180, 60) * Time.deltaTime, Space.World);
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(new Vector3(0, 0, -180) * Time.deltaTime);
            childTransform1.transform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime, Space.World);
            childTransform2.transform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime, Space.World);
            childTransform3.transform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime, Space.World);
            childTransform4.transform.Rotate(new Vector3(0, -180, 0) * Time.deltaTime, Space.World);
        }
    }
}
