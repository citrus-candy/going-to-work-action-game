using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RisingTrap : MonoBehaviour {

    public float timeOut;
    private float timeElapsed;
    public float RiseSpeed;
    private Vector3 position;

    void Start()
    {
        position = transform.position;
    }

    void Update()
    {
        timeElapsed += Time.deltaTime;
        transform.position += new Vector3(0, RiseSpeed * Time.deltaTime * 150, 0);

        if (timeElapsed >= timeOut)
        {
            // Do anything
            Rising();
            timeElapsed = 0.0f;
        }
    }

    void Rising()
    {
        transform.position = position;
    }
}
