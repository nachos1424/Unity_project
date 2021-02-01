using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRigidbody;
    CapsuleCollider coll;
    Animation anim;
    public float jumpPower = 300f;
    //public float maxJumpPower = 500f;
    //float addJumpPower = 150f;
    public float speed = 5f;
    int jumpCount;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animation>();
        anim.Play("01_Idle");
        speed = 5f;
        jumpCount = 0;
    }

private void OnCollisionEnter(Collision collision)
    {
        // collision이 큐브이면
        if (collision.gameObject.tag == "Block")
        {
            anim.CrossFade("12_walk", 0.2f);
        }
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {

        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;
        //    jumpPower += addJumpPower * Time.deltaTime;
        //    jumpPower = Mathf.Clamp(jumpPower, 0f, maxJumpPower);
        //
        //    float scaleY = Mathf.Max(1f - (jumpPower / maxJumpPower), 0.4f);
        //
        //    coll.radius = scaleY;
        //
        //    transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
        //}
        //else if (Input.GetMouseButtonUp(0))
        //{
            myRigidbody.AddForce(0f, jumpPower, 0f);
         //   jumpPower = 0f;
         //
         //   coll.radius = 1f;
         //   transform.localScale = new Vector3(1, 1, 1);
         //
            anim.Play("03_jumpup");
            //anim.CrossFade("03_jumpup", 0.5f);
        }
        Debug.Log("jumpCount" + jumpCount);
        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
