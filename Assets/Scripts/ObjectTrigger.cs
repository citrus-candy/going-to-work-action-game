using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectTrigger : MonoBehaviour {

    public GameObject car;
    public GameObject tsurikawa1;
    public GameObject tsurikawa2;
    public GameObject tsurikawa3;

    public float tsurikawaGravity = 1.5f;

    private bool carTrigger = false;
    private bool tsurikawaTrigger1 = false;
    private bool tsurikawaTrigger2 = false;
    private bool tsurikawaTrigger3 = false;

    void Update()
    {
        if (carTrigger)
        {
            car.transform.position += new Vector3(-0.1f, 0, 0);
        }
        if (tsurikawaTrigger1)
        {
            tsurikawa1.GetComponent<Rigidbody2D>().gravityScale = tsurikawaGravity;
        }
        if (tsurikawaTrigger2)
        {
            tsurikawa2.GetComponent<Rigidbody2D>().gravityScale = tsurikawaGravity;
        }
        if (tsurikawaTrigger3)
        { 
            tsurikawa3.GetComponent<Rigidbody2D>().gravityScale = tsurikawaGravity;
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
           if (transform.position.x == 10)
                carTrigger = true;
          /*  else if (transform.position.x == 33.44)
                tsurikawaTrigger1 = true;
            else if (transform.position.x == 34.871)
                tsurikawaTrigger2 = true;
            else if (transform.position.x == 36.293)
                tsurikawaTrigger3 = true;*/
        }
    }
}
