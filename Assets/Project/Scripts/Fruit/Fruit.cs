using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Fruit : MonoBehaviour
{
    [SerializeField] private GameObject cutFruit, fruitJuice;
    bool isTrigger;
    //private void Update()
    //{
    //    if(isTrigger)
    //    {
    //        if (gameObject.name == "Apple")
    //        {
    //           // isTrigger = false;
    //            Debug.Log(gameObject.name);
    //            SoundController.Instance.AppleCutPlay();
    //        }
    //        if (gameObject.name == "Coconut")
    //        {
    //           // isTrigger = false;
    //            Debug.Log(gameObject.name);
    //            SoundController.Instance.CoconutCutPlay();
    //        }
    //        if (gameObject.name == "Orange")
    //        {
    //           // isTrigger = false;
    //            Debug.Log(gameObject.name);
    //            SoundController.Instance.OrangeCutPlay();
    //        }
    //        if (gameObject.name == "Pear")
    //        {
    //            //isTrigger = false;
    //            Debug.Log(gameObject.name);
    //            SoundController.Instance.PearCutPlay();
    //        }
    //        if (gameObject.name == "Watermelon")
    //        {
    //            //isTrigger = false;
    //            Debug.Log(gameObject.name);
    //            SoundController.Instance.WatermelonCutPlay();
    //        }
    //    }
    //}
    private void SpawnCutFruit()
    {
        GameObject spawnCutFruit = Instantiate(cutFruit, transform.position, transform.rotation); //Spawn the cut fruit after cut the 

        Vector3 spawnJuicePosition = new Vector3(transform.position.x, transform.position.y, 0);
        GameObject spawnJuice = Instantiate(fruitJuice, spawnJuicePosition, fruitJuice.transform.rotation);

        Rigidbody[] cutFruitRigidBody = spawnCutFruit.GetComponentsInChildren<Rigidbody>();
        foreach(Rigidbody rigidbody in cutFruitRigidBody)
        {
            rigidbody.AddExplosionForce(130f, transform.position, 10);
        }
        Destroy(spawnCutFruit, 5);
        Destroy(spawnJuice, 5);
        
    }
   
    void LoadGameLevel()
    {
        SceneManager.LoadScene(1);
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag("Blade"))
    //    {
    //        isTrigger = true;
    //        GameEvent.Score();
    //        SpawnCutFruit();
    //        Destroy(gameObject);
    //    }
    //}
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Blade"))
        {
            isTrigger = true;

            // Play sound before destroying the object
            //switch (gameObject.name)
            //{
            //    case "Apple":
            //        SoundController.Instance.AppleCutPlay();
            //        break;
            //    case "Coconut":
            //        SoundController.Instance.CoconutCutPlay();
            //        break;
            //    case "Orange":
            //        SoundController.Instance.OrangeCutPlay();
            //        break;
            //    case "Pear":
            //        SoundController.Instance.PearCutPlay();
            //        break;
            //    case "Watermelon":
            //        SoundController.Instance.WatermelonCutPlay();
            //        break;
            //}
            SoundController.Instance.PlayFruitSound(gameObject.name);
            GameEvent.Score();
            SpawnCutFruit();
            Destroy(gameObject); 
        }
    }

}
