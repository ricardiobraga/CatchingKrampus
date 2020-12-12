using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFollow : MonoBehaviour
{

    

    public float moveSpeed;
    public float stoppingDistance;

    private Transform target;


    // Start is called before the first frame update
    void Start()
    {       

        target = GameObject.FindGameObjectWithTag("toFollow").GetComponent<Transform>();
    }

    void FixedUpdate()
    {
        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {  
        transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }
    }


}
