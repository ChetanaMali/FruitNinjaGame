using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ExplosionparticleSystem;
    CameraShake _Shake;
    private void Start()
    {
        _Shake = GameObject.FindGameObjectWithTag("ShakeScreen").GetComponent<CameraShake>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            _Shake.CanShake();
                Debug.Log("GameOver");
            //Time.timeScale = 0f;
            GameObject explosionPS = Instantiate( _ExplosionparticleSystem.gameObject, transform.position, Quaternion.identity);
            explosionPS.GetComponent<ParticleSystem>().Play();
            other.GetComponent<Blade>().enabled = false;
            GameEvent.GameOver();
            Destroy(gameObject);
            
        }
    }
    
}
