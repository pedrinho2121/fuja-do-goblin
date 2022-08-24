using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PeDoPlayer : MonoBehaviour
{
    public static bool VoandoCheck;

    private void OnTriggerEnter2D(Collider2D other) 
    {
          if(other.gameObject.tag == "Chao")
          {
            VoandoCheck=false;
          }  
    }
    private void OnTriggerExit2D(Collider2D other) 
    {
        if(other.gameObject.tag == "Chao")
          {
            VoandoCheck=true;
          }  
    
    
    
    
    
    
    
    }
}
