using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy : MonoBehaviour
{
    public float speed = 5;

    private bool grounded;

    public  LayerMask Ground;

    public Transform groundcheck;
    private bool wallhti;

    public  LayerMask wall;

    public Transform wallcheck;

    private Rigidbody2D rig;
    // Start is called before the first frame update
    void Start()
    {
        rig = GetComponent<Rigidbody2D>();        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        grounded = Physics2D.OverlapCircle(groundcheck.position,0.1f,Ground);
        wallhti = Physics2D.OverlapCircle(wallcheck.position,0.1f,wall);
        if(!grounded||wallhti)
        {
            gameObject.transform.localScale=new Vector3(gameObject.transform.localScale.x*-1,1,1);
        }
        if(gameObject.transform.localScale.x<0)
        {
            rig.velocity=new Vector2(speed*-1, rig.velocity.y);
        
        }
        else{

        
        rig.velocity=new Vector2(speed , rig.velocity.y);
        }
    }
}
