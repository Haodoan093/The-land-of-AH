using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
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
        animator = this.GetComponentInChildren<Animator>();

    }
    // Start is called before the first frame update
    void Start()
    {
        rigi.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            this.gameObject.SetActive(false);
        }
        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            Vector2 deliveredKnockBack = transform.localScale.x > 0 ? knockBack : new Vector2(-knockBack.x, knockBack.y);
            //hit the target
            bool gotHit = damageable.Hit(damage, knockBack);
            rigi.velocity = Vector2.zero;
            if (gotHit)
            {
                Debug.Log(collision.name + "hit for" + damage);
            }
            animator.SetTrigger(AnimationStrings.hitTrigger);

        }
    }
}
