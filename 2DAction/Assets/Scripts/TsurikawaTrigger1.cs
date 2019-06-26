using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TsurikawaTrigger1 : MonoBehaviour {

    public GameObject tsurikawa1;
    public float tsurikawaGravity = 1.5f;
    private bool tsurikawaFlag = false;

    void Update()
    {
        if (tsurikawaFlag)       
            tsurikawa1.GetComponent<Rigidbody2D>().gravityScale = tsurikawaGravity;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
             tsurikawaFlag = true;
    }
}
