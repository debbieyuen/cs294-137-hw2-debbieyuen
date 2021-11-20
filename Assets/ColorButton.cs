using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColorButton : MonoBehaviour
{

    public GameObject cube;
    public Text messageText;
    private List<string> sequence;
    private bool isCompeleted;
    private int seq_idx;
    private bool isWin; 

    // Start is called before the first frame update
    void Start()
    {
        sequence = cube.GetComponent<ColorChange>().sequence;
        isCompeleted = cube.GetComponent<ColorChange>().isCompleted;
        seq_idx = 0;
        isWin = false; 
    }

    // Update is called once per frame
    void Update()
    {
        isCompeleted = cube.GetComponent<ColorChange>().isCompleted;

        // Update sequence from cube 
        sequence = cube.GetComponent<ColorChange>().sequence;

        //Check for mouse click 
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit raycastHit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out raycastHit, 100f))
            {
                if (raycastHit.transform != null)
                {


                    if (raycastHit.transform.gameObject.tag == "reset_button")
                    {
                        messageText.gameObject.SetActive(true);
                        messageText.text = "Starting Game!";

                        //cube.gameObject.SetActive(false);
                        cube.GetComponent<ColorChange>().reset();
                        cube.GetComponent<Renderer>().material.color = new Color(255, 255, 255);

                        isCompeleted = false;
                        seq_idx = 0;
                        return;
                    }

                    if (raycastHit.transform.gameObject.tag == "red_button")
                    {

                        if (!isCompeleted)
                        {
                            // Don't do anything if the sequence isn't completed
                            return;
                        }

                        if (sequence[seq_idx] == "R")
                        {
                            // User is correct
                            seq_idx += 1;
                            messageText.gameObject.SetActive(true);
                            messageText.text = "Correct!";
                        } else
                        {
                            // User is incorrect
                            messageText.gameObject.SetActive(true);
                            messageText.text = "Incorrect!";
                            seq_idx = 0; 
                        }

                        if(seq_idx >= sequence.Count)
                        {
                            messageText.gameObject.SetActive(true);
                            messageText.text = "YOU WIN!";
                        }
                        return;
                    }

                    if (raycastHit.transform.gameObject.tag == "blue_button")
                    {
                        if (!isCompeleted)
                        {
                            // Don't do anything if the sequence isn't completed
                            return;
                        }

                        if (sequence[seq_idx] == "B")
                        {
                            // User is correct
                            messageText.gameObject.SetActive(true);
                            messageText.text = "Correct!";
                            seq_idx += 1;
                        }
                        else
                        {
                            // User is incorrect
                            messageText.gameObject.SetActive(true);
                            messageText.text = "Incorrect!";
                            seq_idx = 0;
                        }

                        if (seq_idx >= sequence.Count)
                        {
                            messageText.gameObject.SetActive(true);
                            messageText.text = "YOU WIN!";
                        }
                        return;
                    }

                    if (raycastHit.transform.gameObject.tag == "green_button")
                    {
                        if (!isCompeleted)
                        {
                            // Don't do anything if the sequence isn't completed
                            return;
                        }

                        if (sequence[seq_idx] == "G")
                        {
                            // User is correct
                            messageText.gameObject.SetActive(true);
                            messageText.text = "Correct!";
                            seq_idx += 1;
                        }
                        else
                        {
                            // User is incorrect
                            messageText.gameObject.SetActive(true);
                            messageText.text = "Incorrect!";
                            seq_idx = 0;
                        }

                        if (seq_idx >= sequence.Count)
                        {
                            messageText.gameObject.SetActive(true);
                            messageText.text = "YOU WIN!";
                        }
                        return;
                    }

                    }
            }
        }
    }

}
