using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    public GameObject player;

    public PlayerController playerController;

    private float cameraX;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        Vector3 cameraYZ = this.transform.position;
        cameraX = cameraYZ.x;

        // カメラの追従
        transform.position = new Vector3(player.transform.position.x + 3.5f, cameraYZ.y, cameraYZ.z);
    
        // 背景が見切れないようにする
        if (player.transform.position.x < -3.13f)
        {
            transform.position = new Vector3(0, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x > 474.21f && player.transform.position.x < 488f && player.transform.position.y > -3.62f && player.transform.position.y < 5.0f)
        {
            transform.position = new Vector3(477.71f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x < 474.22f && player.transform.position.x > 450f && player.transform.position.y < -3.63f)
        {
            transform.position = new Vector3(477.72f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x > 526.66f && player.transform.position.y < -6.0f)
        {
            transform.position = new Vector3(530.16f, cameraYZ.y, cameraYZ.z);
        }  
        else if (player.transform.position.x > 561.75f && player.transform.position.x < 600f && player.transform.position.y > -2.5f && player.transform.position.y < 3.48f)
        {
            transform.position = new Vector3(565.21f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x < 561.71f && player.transform.position.y > 3.49f && player.transform.position.y < 15.0f)
        {
            transform.position = new Vector3(565.21f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x > 596.7f && player.transform.position.y > 5.1f && player.transform.position.y < 15.0f)
        {
            transform.position = new Vector3(600.2f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x < 596.7f && player.transform.position.y > 15.1f && player.transform.position.y < 24.0f)
        {
            transform.position = new Vector3(600.2f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x > 631.67f && player.transform.position.y > 15.1f && player.transform.position.y < 24.0f)
        {
            transform.position = new Vector3(635.17f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x < 631.68f && player.transform.position.y > 25.55f)
        {
            transform.position = new Vector3(635.18f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x > 666.64f && player.transform.position.y > 25.55f)
        {
            transform.position = new Vector3(670.14f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x > 650f && player.transform.position.x < 666.8f && player.transform.position.y > -2.5f && player.transform.position.y < 3.48f)
        {
            transform.position = new Vector3(670.3f, cameraYZ.y, cameraYZ.z);
        }
        else if (player.transform.position.x > 701.5f && player.transform.position.y > -2.5f && player.transform.position.y < 3.48f)
        {
            transform.position = new Vector3(705f, cameraYZ.y, cameraYZ.z);
        }

        else if (player.transform.position.x > 0f && player.transform.position.x < 400f && player.transform.position.y < -5.0f)
        {
            transform.position = new Vector3(player.transform.position.x + 3.5f, cameraYZ.y, cameraYZ.z);
            playerController.life = 0;
        }
    }
}
