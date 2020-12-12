using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyLevelPartPrefab : MonoBehaviour
{
    private float secondsToDestroy = 20f;
    [SerializeField]
    Transform targetPlayer;

    [SerializeField]
    float distance;

    [SerializeField]
    float maxDistance;



    Vector3 setDistance;

    GameObject player;
    
    void Start()
    {
       // StartCoroutine(DestroySelf());

       player = GameObject.Find("Player");
        //setDistance = new Vector3(player.transform.position.x , player.transform.position.y );
        
    }

    private void FixedUpdate()
    {      

        //distance = Vector3.Distance(transform.position, player.transform.position);

        if (Vector3.Distance(transform.position, player.transform.position ) < maxDistance)
        {
            Destroy(gameObject);
            
        }
    }

    IEnumerator DestroySelf() 
    {
        yield return new WaitForSeconds(secondsToDestroy);
        Destroy(gameObject);
    }
}
