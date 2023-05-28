using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fade : MonoBehaviour
{
    public Animator animator;


    void Start()
    {
        Invoke("fadeOut", 2);
    }



    public void fadeOut()
    {
        animator.Play("FadeOut");
    }
}
