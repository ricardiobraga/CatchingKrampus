using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDashMove : MonoBehaviour
{
    private Rigidbody2D rb;
    private float dashTime;
    private int direction;
    

    public float dashSpeed;    
    public float startDashTime;
    public GameObject dashEffect;

    bool dashOn = true;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        dashTime = startDashTime;
    }

    // Update is called once per frame
    void Update()        
    {          

        

        if(direction == 0)
        {            
                                       
                if(Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.Q) && dashOn)
                {      
                dashOn = false;   
                  //PARTICLE EFFECT: 
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 1;                         
                
                }          



            else if (Input.GetKey(KeyCode.Space) && Input.GetKeyDown(KeyCode.E) && dashOn)
            {
                dashOn = false;
                //PARTICLE EFFECT: 
                Instantiate(dashEffect, transform.position, Quaternion.identity);
                direction = 2;
                 
            }
            //   else if (Input.GetKeyDown(KeyCode.UpArrow))
            // {
            //     direction = 3;
            // }
            //   else if (Input.GetKeyDown(KeyCode.DownArrow))
            // {
            //     direction = 4;
            // }
        }
        else
        {
            if (dashTime <=0)
            {
                direction = 0;
                dashTime = startDashTime;
                rb.velocity = Vector2.zero;
            }
            else
            {
                dashTime -= Time.deltaTime;

                if(direction == 1)
                {
                    rb.velocity = Vector2.left * dashSpeed;
                }
                else if (direction == 2)
                {
                    rb.velocity = Vector2.right * dashSpeed;
                }
                    //    else if (direction == 3)
                    // {
                    //     rb.velocity = Vector2.up * dashSpeed;
                    // }
                    //    else if (direction == 4)
                    // {
                    //     rb.velocity = Vector2.down * dashSpeed;
                    // }
            }
        }


        
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("DashOnTrue");
            dashOn = true;
            
        }
    }



    



}
