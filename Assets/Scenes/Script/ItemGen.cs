using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemGen : MonoBehaviour
{
    float Timer;
    void Start()
    {
        Timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Timer += Time.deltaTime;
        if (Timer > 5)
        {
            gameObject.GetComponent<Item>().enabled = true;
            gameObject.GetComponent<MeshRenderer>().enabled = true;
            gameObject.GetComponent<ItemGen>().enabled = false;
            Timer = 0;
        }
    }
}
