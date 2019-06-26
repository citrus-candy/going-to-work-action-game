using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UsagiJump : MonoBehaviour {

    Rigidbody2D rigidbody_u;
    private bool flag = false;

    public float timeOut;
    public float JumpResio;
    private float timeElapsed;

    void Start () {
        rigidbody_u = GetComponent<Rigidbody2D>();
    }
	
	void Update () {
        timeElapsed += Time.deltaTime;

        if (timeElapsed >= timeOut)
        {
            // Do anything
            RabbitJump();
            timeElapsed = 0.0f;
        }
    }

    void RabbitJump()
    {
        rigidbody_u.AddForce(transform.up * JumpResio, ForceMode2D.Impulse);
    }

}
