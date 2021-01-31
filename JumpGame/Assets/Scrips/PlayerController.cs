using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    Rigidbody myRigidbody;
    CapsuleCollider coll;
    Animation anim { get; set; }
    public float jumpPower = 0f;
    public float maxJumpPower = 500f;
    private float addJumpPower = 150f;
    public float speed = 5f;
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody>();
        coll = GetComponent<CapsuleCollider>();
        anim = GetComponent<Animation>();
        anim.Play("01_Idle");
        speed = 5f;
    }

private void OnCollisionEnter(Collision collision)
    {
        // collision이 큐브이면
        if (collision.gameObject.tag == "Block")
        {
            anim.CrossFade("01_Idle", 0.2f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(transform.forward * Time.deltaTime * speed, Space.World);
        if (Input.GetMouseButton(0))
        {
            jumpPower += addJumpPower * Time.deltaTime;
            jumpPower = Mathf.Clamp(jumpPower, 0f, maxJumpPower);

            float scaleY = Mathf.Max(1f - (jumpPower / maxJumpPower), 0.4f);

            coll.radius = scaleY;

            transform.localScale = new Vector3(transform.localScale.x, scaleY, transform.localScale.z);
        }
        else if (Input.GetMouseButtonUp(0))
        {
            myRigidbody.AddForce(jumpPower, jumpPower, 0f);
            jumpPower = 0f;

            coll.radius = 1f;
            transform.localScale = new Vector3(1, 1, 1);

            anim.Play("03_jumpup");
            //anim.CrossFade("03_jumpup", 0.5f);
        }

        if (transform.position.y < -5f)
        {
            SceneManager.LoadScene(0);
        }
    }
}
