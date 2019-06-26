using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGround : MonoBehaviour {

    bool flag = false;
    public float moveSpeed;
    public float moveDistance = 1.0f;

	// Use this for initialization
	void Start () {
        move_right();
	}
	
	// Update is called once per frame
	void Update () {
        if(flag)
            transform.position -= new Vector3(moveSpeed * Time.deltaTime * 150, 0, 0);
        else
            transform.position += new Vector3(moveSpeed * Time.deltaTime * 150, 0, 0);
    }

    void move_right()
    {
        flag = false;
        Invoke("move_left", moveDistance);
    }

    void move_left()
    {
        flag = true;
        Invoke("move_right", moveDistance);
    }
}
