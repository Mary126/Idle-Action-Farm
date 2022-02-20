using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1.0f;
    private Vector3 direction;
    private Rigidbody playerRB;
    private Animator anim;
    public ClickTracker clickTracker;

    float m_HorizontalAngle;
    // Start is called before the first frame update
    void Start()
    {
        playerRB = GetComponent<Rigidbody>();
        //anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = clickTracker.playerMovement;
        if (direction.magnitude != 0)
        {
            Vector3 newPos = direction * speed;
        }
    }
    private void FixedUpdate()
    {
        if (clickTracker.playerMoving)
        {
            playerRB.MovePosition(transform.position + direction * Time.fixedDeltaTime);
            //anim.SetBool("IsRunning", true);
        }
        else
        {
            //anim.SetBool("IsRunning", false);
        }
    }
}
