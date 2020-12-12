using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FollowAdaptive : MonoBehaviour
{

   

    [SerializeField]
    float stoppingDistance;

    [SerializeField]
    private float JumpForce = 1;

    [SerializeField]
    float enemyGravity;

    [SerializeField]
    float Yposition;


    [SerializeField]
    Transform targetFolow;

    private Transform target;

    const string LEFT = "left";

    const string RIGHT = "right";

    [SerializeField]
    Transform castPos;

    [SerializeField]
    float baseCastDist;
    [SerializeField]
    float groundCastDist;

    [SerializeField]
    float moveSpeed = 5;

    string facingDirection;

    Vector3 baseScale;

    Rigidbody2D rb2d;



    // Start is called before the first frame update
    void Start()
    {
        baseScale = transform.localScale;
        facingDirection = RIGHT;
        rb2d = GetComponent<Rigidbody2D>();

        // follow reference

        target = GameObject.FindGameObjectWithTag("toFollow").GetComponent<Transform>();
    }


    private void FixedUpdate()
    {

        



        if (Vector2.Distance(transform.position, target.position) > stoppingDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, moveSpeed * Time.deltaTime);
        }



        float vX = moveSpeed;

        if (facingDirection == LEFT)
        {
            vX = -moveSpeed;
        }

        //move the game object
        //rb2d.velocity = new Vector2(vX, rb2d.velocity.y);

        if (IsHittingWall() ||IsNearEdge())
        {
            rb2d.AddForce(new Vector2(0, JumpForce), ForceMode2D.Impulse);
            rb2d.gravityScale = -0.01f;
        }
        else
        {
           rb2d.gravityScale = 1f; 
        }
            // if (facingDirection == LEFT)
            // {
            //     ChangeFacingDirection (RIGHT);
            // }
            // else if (facingDirection == RIGHT)
            // {
            //     ChangeFacingDirection (LEFT);
            // }
        //}




        // if (IsNearEdge()) {
        //     rb2d.gravityScale = -0.01f;
        // }
        // else
        // {
        //    rb2d.gravityScale = 1f; 
        // }
    }


    void ChangeFacingDirection(string newDirection)
    {
        Vector3 newScale = baseScale;

        if (newDirection == LEFT)
        {
            newScale.x = -baseScale.x;
        }
        else if (newDirection == RIGHT)
        {
            newScale.x = baseScale.x;
        }

        transform.localScale = newScale;

        facingDirection = newDirection;
    }

    bool IsHittingWall()
    {
        bool val = false;

        float castDist = baseCastDist;

        if (facingDirection == LEFT)
        {
            castDist = -baseCastDist;
        }
        else
        {
            castDist = baseCastDist;
        }

        //determine th target destination based on the cast distance
        Vector3 targetPos = castPos.position;
        targetPos.x += castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.blue);

        if (
            Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground"))
        )

        {
            val = true;
        }
        else
        {
            val = false;
        }

        return val;
    }

    bool IsNearEdge()
    {
        bool val = true;

        float castDist = groundCastDist;

        //determine th target destination based on the cast distance
        Vector3 targetPos = castPos.position;
        targetPos.y -= castDist;

        Debug.DrawLine(castPos.position, targetPos, Color.red);

        if (
            Physics2D.Linecast(castPos.position, targetPos, 1 << LayerMask.NameToLayer("Ground"))
        )

        {
            val = false;
        }
        else
        {
            val = true;
        }

        return val;
    }
}

