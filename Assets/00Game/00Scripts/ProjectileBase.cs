using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public abstract class ProjectileBase : Singleton<ProjectileBase>
{
    public float damage = 10;
    public Vector2 moveSpeed = new Vector2(3f, 0);
    public Vector2 knockBack = Vector2.zero;
    public float timer = 2f;
    protected Animator animator;
    protected Rigidbody2D rigi;

    protected virtual void Awake()
    {
        rigi = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    protected virtual void Start()
    {
        rigi.velocity = new Vector2(moveSpeed.x * transform.localScale.x, moveSpeed.y);
    }

    protected virtual void Update()
    {
        timer -= Time.deltaTime;
        if (timer < 0)
        {
            gameObject.SetActive(false);
        }
    }
    protected virtual void HitTarget(Collider2D collision)
    {
        if (collision.CompareTag("Ground"))
        {
            gameObject.SetActive(false);
        }

        Damageable damageable = collision.GetComponent<Damageable>();
        if (damageable != null)
        {
            Vector2 deliveredKnockBack = transform.localScale.x > 0 ? knockBack : new Vector2(-knockBack.x, knockBack.y);
            //hit the target
            bool gotHit = damageable.Hit(damage, deliveredKnockBack);
            rigi.velocity = Vector2.zero;
            if (gotHit)
            {
                Debug.Log(collision.name + " hit for " + damage);
            }
            animator.SetTrigger(AnimationStrings.hitTrigger);
        }
    }
}
