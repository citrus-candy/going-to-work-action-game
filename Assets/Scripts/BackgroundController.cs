using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundController : MonoBehaviour {

    public GameObject gameobject;
    public GameObject cameraYZ;

    void Update()
    {
        int cameraY = gameobject.GetComponent<PlayerController>().cameraY;

        // カメラの上下移動
        Vector3 cameraX = cameraYZ.transform.position;

        switch (cameraY)
        {
            case 0 : cameraYZ.transform.position = new Vector3(cameraX.x, 0, -0.3f); break;
            case -5 : cameraYZ.transform.position = new Vector3(cameraX.x, -10.0f, -0.3f); break;
            case 5: cameraYZ.transform.position = new Vector3(cameraX.x, 10.0f, -0.3f); break;
            case 10: cameraYZ.transform.position = new Vector3(cameraX.x, 10.0f + 10.0f, -0.3f); break;
            case 15: cameraYZ.transform.position = new Vector3(cameraX.x, 10.0f + 10.0f + 10.0f, -0.3f); break;
            default: break;
        }
    }


}
