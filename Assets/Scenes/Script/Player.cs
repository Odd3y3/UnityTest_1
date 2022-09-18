using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player: MonoBehaviour
{
    new Rigidbody rigidbody;
    public bool jumptrigger;
    GameObject ButtonImage;
    
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();
        jumptrigger = true;
        ButtonImage = GameObject.Find("ButtonEnableImage");
    }

    void Update()
    {
        if (Input.GetButtonDown("Jump") && jumptrigger)
        {
            rigidbody.AddForce(new Vector3(0, 5, 0), ForceMode.Impulse);
            jumptrigger = false;
        }
        if(ButtonImage != null)
        {
            if(jumptrigger)
                ButtonImage.SetActive(true);
            else
                ButtonImage.SetActive(false);
        }
    }

    private void FixedUpdate()
    {
        float forceX = 10 * Input.GetAxisRaw("Horizontal") * Time.deltaTime;
        float forceY = 10 * Input.GetAxisRaw("Vertical") * Time.deltaTime;

        if (rigidbody != null)
            rigidbody.AddForce(forceX, 0, forceY, ForceMode.Impulse);

        // GameOver
        if(transform.localPosition.y < -10)
        {
            Debug.Log("died....");
            GameObject.Find("Canvas").transform.FindChild("YOUDIED").gameObject.SetActive(true);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name == "Floor")
            jumptrigger = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Item>() != null)
            jumptrigger = true;
    }
}
