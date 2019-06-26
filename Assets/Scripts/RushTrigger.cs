using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RushTrigger : MonoBehaviour {

    public GameObject RushObject;

    private bool Flag = false;
    public float RushSpeed;

    void Update()
    {
        if (Flag)
            RushObject.transform.position += new Vector3(RushSpeed * Time.deltaTime * 150, 0, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            Flag = true;
        }
    }
}
