using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BallScript : MonoBehaviour, OnTouch3D
{
    private Rigidbody rb;
    private int Points = 0;
    Vector3 tablePos;
    Vector3 tablePos1 = new Vector3(-5.55f, -2.38f, -5.414f);
    Vector3 tablePos2 = new Vector3(-7.205f, -2.38f, -5.414f);
    float x_offset = 0.7f;
    float z_offset = 0.5f;
    public Text messageText;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
	    rb.useGravity = false;

        //Randomly select a table
        if(Random.Range(0, 1f) > 0.5)
        {
            tablePos = tablePos1;
        } else
        {
            tablePos = tablePos2;
        }

        transform.position = new Vector3(tablePos.x + Random.Range(-1.0f * x_offset, x_offset), tablePos.y, tablePos.z + Random.Range(-1.0f * z_offset, z_offset)); 


    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("COLLISION DETECTED!");
        if (Random.Range(0, 1f) > 0.5)
        {
            tablePos = tablePos1;
        }
        else
        {
            tablePos = tablePos2;
        }

        transform.position = new Vector3(tablePos.x + Random.Range(-1.0f * x_offset, x_offset), tablePos.y, tablePos.z + Random.Range(-1.0f * z_offset, z_offset));
        rb.useGravity = false;
        rb.velocity = Vector3.zero;


        if (collision.gameObject.name == "Game Board")
        {
            Points += 1;
            messageText.gameObject.SetActive(true);

            if (Points == 5)
            {
                messageText.text = "You  Win!";
            }
            else
            {
                messageText.text = "You have " + Points + " points!";
            } 
        }

    }

    public void OnTouch()
    {
       		rb.useGravity = true;
    }
}
