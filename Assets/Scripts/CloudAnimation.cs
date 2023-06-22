using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudAnimation : MonoBehaviour
{
    private readonly float timeToSwitch = 1f;
    private float timer;
/*
    private bool animate1 = true;
    private bool animate2 = true;
    private bool animate3 = true;
    private bool animate4 = true;
*/
    private bool expand = true;

    // Start is called before the first frame update
    void Start()
    {
 
    }

    // Update is called once per frame
    void Update()
    {
        if (expand)
        {
            timer += Time.deltaTime;
            if (timer >= timeToSwitch) {
                transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y + 0.05f, transform.localScale.z);

                expand = false;
            }
        }
        else
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y - 0.05f, transform.localScale.z);

               expand = true;
            }
        }

        /*

                Debug.Log("Time " + timer);
                if (timer >= 0.5f && timer < 1f)
                {
                    if (animate1)
                    {
                        Debug.Log("Time" + timer);
                        transform.localScale = new Vector3(transform.localScale.x - 0.05f, transform.localScale.y, transform.localScale.z);

                        animate1 = false;
                        animate2 = true;
                        animate3 = true;
                        animate4 = true;
                    }
                }
                else if (timer >= 1f && timer < 1.5f)
                {
                    if (animate2)
                    {
                        Debug.Log("Time" + timer);
                        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.05f, transform.localScale.z);

                        animate1 = true;
                        animate2 = false;
                        animate3 = true;
                        animate4 = true;
                    }
                }
                else if (timer >= 1.5f && timer < 2f)
                {
                    if (animate3)
                    {
                        Debug.Log("Time" + timer);
                        transform.localScale = new Vector3(transform.localScale.x + 0.05f, transform.localScale.y, transform.localScale.z);

                        animate1 = true;
                        animate2 = true;
                        animate3 = false;
                        animate4 = true;
                    }
                }
                else if (timer >= 2f)
                {
                    if (animate4)
                    {
                        Debug.Log("Time" + timer);
                        transform.localScale = new Vector3(transform.localScale.x , transform.localScale.y - 0.05f, transform.localScale.z);

                        animate1 = true;
                        animate2 = true;
                        animate3 = true;
                        animate4 = false;

                        timer = 0;
                    }
                }

         */

    }
}
