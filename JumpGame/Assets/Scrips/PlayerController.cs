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
    public float speed = 5f;
    int jumpCount;
    float prevPosY;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animation>();
        anim.Play("01_Idle");
        speed = 5f;
        jumpCount = 0;
        prevPosY = transform.position.y;
    }

private void OnCollisionEnter(Collision collision)
    {
        // collision이 큐브이면
        if (collision.gameObject.tag == "Block")
        {
            anim.CrossFade("02_Move", 0.2f);
        }
        jumpCount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        ChangeAnim();
        Jump();
    }
		//점프 최고치에서 애니메이션 전환
    private void ChangeAnim()
    {
        if (transform.position.y - prevPosY < 0)
        {
            if (Mathf.Abs(transform.position.y - prevPosY) < 0.001f)
            {
                anim.CrossFade("02_Move", 0.2f);
            }
            else
                anim.CrossFade("04_jumpdown", 0.2f);
        }
        prevPosY = transform.position.y;
    }
    // 점프
    private void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && jumpCount < 2)
        {
            jumpCount++;

            myRigidbody.AddForce(0f, jumpPower, 0f);

            anim.Play("03_jumpup");
        }
    }
}
