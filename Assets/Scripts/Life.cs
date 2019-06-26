using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Life : MonoBehaviour {

    public GameController gameController;
    public PlayerController playerController;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" && gameController.gameStart)
        {
            if (playerController.life + 1 != 5)
            {
                playerController.life += 1;
            }
            gameObject.SetActive(false);
        }
    }
}
