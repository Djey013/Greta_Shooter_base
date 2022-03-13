using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    
    
    private void Update()
    {
        transform.Translate(transform.forward * 0.02f);
        transform.Rotate(0f,1f,0f);
        
    }
    
}
