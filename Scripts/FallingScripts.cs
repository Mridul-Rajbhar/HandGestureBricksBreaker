using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingScripts : MonoBehaviour
{
    
    List<Animator> animators;
    // Start is called before the first frame update
    void Start()
    {
        animators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(DoAnimation());
    }

    IEnumerator DoAnimation()
    {
        while(true)
        {
            foreach( var animator in animators)
            {
                animator.SetTrigger("startAnim");
                yield return new WaitForSeconds(0.2f);
            }
        }
    }
}
