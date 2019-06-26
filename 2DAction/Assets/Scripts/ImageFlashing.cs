using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFlashing : MonoBehaviour {

    public float FlashTiming;

    void Start()
    {
        True();
    }

    void True()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 0f);
        Invoke("False", FlashTiming);
    }

    void False()
    {
        this.GetComponent<SpriteRenderer>().color = new Color(255f, 255f, 255f, 255f);
        Invoke("True", FlashTiming);
    }
}
