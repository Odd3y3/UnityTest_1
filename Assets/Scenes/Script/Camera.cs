using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public GameObject Player;
    Vector3 v_Playerpos;
    void Start()
    {
        v_Playerpos = new Vector3(0f, 1.1f, -1.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if(Player.transform.position.y > -10)
            transform.position = Player.transform.position + v_Playerpos;
        
    }
}
