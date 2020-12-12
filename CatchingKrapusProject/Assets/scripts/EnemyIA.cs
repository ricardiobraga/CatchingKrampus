using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour
{
    public float Speed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       Move() ;
    }

    void Move(){
        Vector3 movement =  new Vector3( 60 * Time.deltaTime, 0, 0);
        transform.position += movement * Time.deltaTime * Speed;
    }
}

