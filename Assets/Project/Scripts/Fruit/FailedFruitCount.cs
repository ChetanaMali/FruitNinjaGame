using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FailedFruitCount : MonoBehaviour
{
    int count =0;
    int chance = 2;
    [SerializeField] GameObject[] hearts;
    CameraShake _Shake;
    private void Start()
    {
        _Shake = GameObject.FindGameObjectWithTag("ShakeScreen").GetComponent<CameraShake>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            if(count < chance)
            {
                Debug.Log(count);
                for (int i = 0; i < hearts.Length; i++)
                {
                    if (i == count)
                    {   
                        hearts[i].SetActive(false);
                        
                    }
                    _Shake.CanShake();
                }
                count++;
                //chance--;
            }
            else 
            {
                hearts[2].SetActive(false);
                GameEvent.GameOver();
                Time.timeScale = 0;
                gameObject.GetComponent<BoxCollider>().enabled = false;
                gameObject.SetActive(false);
            }
            
        }
    }
}
