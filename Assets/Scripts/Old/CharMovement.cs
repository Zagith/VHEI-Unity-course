using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharMovement : MonoBehaviour
{
    private Rigidbody2D body;
    private Animator anim;
    float horizontal;

    public float runSpeed = 10.0f;
    public float jumpSpeed = 50f;
    public Transform checkpointPos;


    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        body.velocity = new Vector2(horizontal * runSpeed, 0f);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            body.velocity = new Vector2(body.velocity.x, jumpSpeed);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            Debug.Log("Collido " + col.gameObject.name);
            anim.SetBool("Die", true);
        }
    }

    public void TeleportToCheckPoint()
    {
        transform.position = new Vector3(checkpointPos.position.x, checkpointPos.position.y, checkpointPos.position.z);
    } 
}
