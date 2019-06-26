using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TawashiTrigger : MonoBehaviour {

    public GameObject tawashi;
    public float tawashiGravity = 1.5f;
    private bool tawashiFlag = false;

    void Update()
    {
        if (tawashiFlag)
            tawashi.GetComponent<Rigidbody2D>().gravityScale = tawashiGravity;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
            tawashiFlag = true;
    }
}
