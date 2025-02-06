using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
   [SerializeField] Animator animator;
    public void CanShake()
    {
        animator.SetTrigger("Shake");
    }
}
