using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUps : MonoBehaviour
{
    bool isSlow = false;
    float n;
    private void Start()
    {
        isSlow = false;
    }
    private void Update()
    {
        
        if (isSlow)
        {
            n += Time.deltaTime;
            if (n <= 2)
            {
                Time.timeScale = 0.2f;  

            }
            if (n > 2)
            {
                isSlow = false;
                Time.timeScale = 1;
                n = 0;
            }
        }
         
    }
    public void SlowFlow()
    {
        isSlow = true;

    }
}
