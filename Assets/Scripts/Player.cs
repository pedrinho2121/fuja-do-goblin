using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //variavel da velocidade
    public float Velocidade= 10f;
    //variavel altura do pulo
    public float ForcaPulo=10f;
    //variavel sentido movimento
    public float movimento;
    //variavel fisica
    private Rigidbody2D rig;

    private Animator animate;
    public Transform respawn;
    public float AltMin=-16;

    //variavel se ta no ar
    public bool TaVoando= false;
    void Start() 
    {
        rig = GetComponent<Rigidbody2D>();
        animate = GetComponent<Animator>();

    }
    

    // Update is called once per frame
    void Update()
    {
     movimento = Input.GetAxis("Horizontal");
     rig.velocity = new Vector2(Velocidade*movimento,rig.velocity.y);
     VirarSprite(movimento);
     Pulo();
     TaVoando=PeDoPlayer.VoandoCheck;
     if (movimento!=0)
     {
        animate.SetBool("Correndo",true);
     }

     else
     {
         animate.SetBool("Correndo",false);
     }
     if (!TaVoando)
     {
        animate.SetBool("Pulando",false);
     }

     if(gameObject.transform.position.y< AltMin)
     {
        gameObject.transform.position = respawn.transform.position;
        

        
     }

    }

    void VirarSprite(float DirecaoMovimento)
    {
        if(DirecaoMovimento>0)
        {
            gameObject.transform.localScale= new Vector3(1,1,1);
        }  
        else if(DirecaoMovimento<0)
        {
            gameObject.transform.localScale= new Vector3(-1,1,1);
        } 

    }

    void Pulo()
    
    {
      if(Input.GetButton("Jump")&& !TaVoando )
      {
        rig.velocity=new Vector2(rig.velocity.x,ForcaPulo);
        animate.SetBool("Pulando",true);
      }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag=="Enemy")
        {
            gameObject.transform.position = respawn.transform.position;
        }
    }
}
