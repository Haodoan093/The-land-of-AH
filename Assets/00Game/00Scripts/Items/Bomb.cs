 using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Bomb : MonoBehaviour
{
    public float damage = 10;
    public Vector2 moveSpeed = new Vector2(3f, 0);
    public Vector2 knockBack = Vector2.zero;
    Animator animator;
    public float timer = 2f;
    Rigidbody2D rigi;




    private void Awake()
    {
        rigi = this.GetComponent<Rigidbody2D>();
       

    }
    // Start is called before the first frame update
    void Start()
    {
        rigi.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
        animator = this.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        timer -= Time.deltaTime;
        if (timer < 0)
        {
            this.gameObject.SetActive(false);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
       
            animator.SetTrigger(AnimationStrings.hitTrigger);

        
    }

}
