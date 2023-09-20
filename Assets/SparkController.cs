using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class SparkController : MonoBehaviour
{
    public float damage = 10;
    
    Animator animator;
    public float timer = 2f;
    public float timerFire = 0f;
   



    private void Awake()
    {
      
        animator = this.GetComponentInChildren<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        timerFire -= Time.deltaTime;
        if (timer < 0)
        {
            this.gameObject.SetActive(false);
        }
        if (timerFire < 0)
        {
            animator.SetTrigger(AnimationStrings.hitTrigger);
        }


    }
 

}
