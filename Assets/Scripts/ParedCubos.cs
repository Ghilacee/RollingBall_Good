using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParedCubos : MonoBehaviour
{
    // Start is called before the first frame update
    private bool iniciarTimer;
    private float timer = 0;
    [SerializeField] private Rigidbody[] rbs;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    private void Update()
    {
        if (iniciarTimer == true)
        {
            timer += 1 * Time.unscaledDeltaTime;
            if (timer >= 2)
            {
               Time.timeScale = 1;
                for (int i = 0; i < rbs.Length; i++)
                {
                    rbs[i].useGravity = true;
                
                }
            
            
            }




        
        }




    }
}