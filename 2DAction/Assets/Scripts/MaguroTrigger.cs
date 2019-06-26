using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MaguroTrigger : MonoBehaviour {

    public GameObject Maguro1;
    public GameObject Maguro2;
    public GameObject Maguro3;
    public GameObject Maguro4;
    public GameObject Maguro5;

    private bool MaguroFlag = false;
    public float MoveSpeed = -0.2f;
    private int x = 150;

    void Update()
    {
        if (MaguroFlag)
        {
            Maguro1.transform.position += new Vector3(MoveSpeed * Time.deltaTime * x, 0, 0);
            Maguro2.transform.position += new Vector3(MoveSpeed * Time.deltaTime * x, 0, 0);
            Maguro3.transform.position += new Vector3(MoveSpeed * Time.deltaTime * x, 0, 0);
            Maguro4.transform.position += new Vector3(MoveSpeed * Time.deltaTime * x, 0, 0);
            Maguro5.transform.position += new Vector3(MoveSpeed * Time.deltaTime * x, 0, 0);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            MaguroFlag = true;
        }
    }
}
