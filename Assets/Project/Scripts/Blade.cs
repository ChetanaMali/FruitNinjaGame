using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blade : MonoBehaviour
{
    bool isCutting = false;
    Camera cam;
    Rigidbody rigidbody;
    TrailRenderer trailRenderer;
    BoxCollider boxCollider;


    private void Start()
    {
        cam = Camera.main;
        rigidbody = GetComponent<Rigidbody>();
        boxCollider = GetComponent<BoxCollider>();
        trailRenderer = GetComponent<TrailRenderer>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartCutting();
        }
        else if (Input.GetMouseButtonUp(0))
        {
            StopCutting();
        }

        UpdateBladePos();

        if (isTrigger)
        {
            if (gameObject.name == "Apple")
            {
                Debug.Log(gameObject.name);
                SoundController.Instance.AppleCutPlay();
            }
            if (gameObject.name == "Coconut")
            {
                Debug.Log(gameObject.name);
                SoundController.Instance.CoconutCutPlay();
            }
            if (    gameObject.name == "Orange")
            {
                Debug.Log(gameObject.name);
                SoundController.Instance.OrangeCutPlay();
            }
            if (    gameObject.name == "Pear")
            {
                Debug.Log(gameObject.name);
                SoundController.Instance.PearCutPlay();
            }
            if (gameObject.name == "Watermelon")
            {
                Debug.Log(gameObject.name);
                SoundController.Instance.WatermelonCutPlay();
            }
        }
    }
    bool isTrigger;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Fruit"))
        {
            isTrigger = true;
        }
       
    }
    void StartCutting()
    {
        boxCollider.enabled = true;
        trailRenderer.enabled = true;
        //isCutting = true;
    }
    void StopCutting()
    {
        boxCollider.enabled = false;
        trailRenderer.enabled = false;
       // isCutting = false;
    }
    void UpdateBladePos()
    {
        Vector3 mousePos = Input.mousePosition;
        mousePos.z = 9.5f;
        rigidbody.position = cam.ScreenToWorldPoint(mousePos);
    }
}
