using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class Restart : MonoBehaviour
{
    
    public void ReLoadScene()
    {
            SceneManager.LoadScene(0);
    }
    
}
