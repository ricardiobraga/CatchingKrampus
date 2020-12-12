using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow : MonoBehaviour
{
    [SerializeField]
    Transform targetPlayer;
    
    [SerializeField]
    Transform targetFollow;

    [SerializeField]
     float Speed;

    [SerializeField]
    float minDistance;

    [SerializeField]
    float maxDistance;
    
    
    [SerializeField]
    float distance;

    Vector2 setDistance;




    // Start is called before the first frame update
    void Start()
    {
        setDistance = new Vector2(targetFollow.position.x , targetFollow.position.y );
    }

    // Update is called once per frame
    void FixedUpdate()
    { 

        

        distance = Vector2.Distance(transform.position, targetPlayer.position);

        // se  a distancia entre player e o objeto for menor que minDistance, ativa a função Move
       if (Vector2.Distance(transform.position, targetPlayer.position) > minDistance && Vector2.Distance(transform.position, targetPlayer.position) < maxDistance)
        {             
        
               Move();           
        }
        if (Vector2.Distance(transform.position, targetPlayer.position) > maxDistance)
        {
            transform.position = new Vector3(transform.position.x - minDistance, 0.0f, 0.0f);
            //setDistance.x -= minDistance ;
            
        }

        

        

    }




    void Move()
    {    
 
        Vector3 movement =  new Vector3( 60 * Time.deltaTime, 0, 0);
        transform.position += movement * Time.deltaTime * Speed;    
                
        
    }

    
}
