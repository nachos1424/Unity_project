using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Box : MonoBehaviour
{
    public Material myMaterial;
    bool isDelete = false;
    float time = 0f;
    float maxTime = 3f;
    // Start is called before the first frame update
    void Start()
    {
        myMaterial = GetComponent<MeshRenderer>().material;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            isDelete = true;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if(isDelete)
        {
            if (time <= maxTime)
            {
                time += Time.deltaTime;
                float alpha = Mathf.Max(1 - (time / maxTime), 0f);
                myMaterial.color = new Color(
                    myMaterial.color.r,
                    myMaterial.color.g,
                    myMaterial.color.b,
                    alpha);
            }
        }

        if (myMaterial.color.a <= 0f)
        {
            this.gameObject.SetActive(false);
        }
    }
}
