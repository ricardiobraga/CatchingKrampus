using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class takeRock : MonoBehaviour
{
    public bool take;

    public void TakeItem(){
        if(!take)
        {
            take = true;
            Debug.Log("TAKE TRUE");

        }
        else
        {
            take = false;
            Debug.Log("TAKE FALSE");
        }
    }

}
