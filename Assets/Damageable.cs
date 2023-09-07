using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Damageable : MonoBehaviour
{
    public UnityEvent<float, Vector2> damageableHit;
    public UnityEvent damageableDeath;
    public UnityEvent<float, float> changeHealth;
    Animator animator;


    //mau toi da
    [SerializeField]
    private float _maxHealth = 100;

    public float MaxHealth
    {
        get
        {
            return _maxHealth;
        }
        set
        {
            _maxHealth = value;
        }
    }

    //mau thuc the
    [SerializeField]
    private float _health = 100;
    public float Health
    {
        get
        {
            return _health;
        }
        set
        {
            _health = value;
            changeHealth?.Invoke(_health, MaxHealth);
            if (_health >= MaxHealth)
            {
                _health = MaxHealth;
            }
            if (_health <= 0)
            {
                IsAlive = false;
            }
        }
    }


    private bool _isAlive = true;
    private bool isInvincible = false;//bat kha chien bai

    public float timeSinceHit = 0;
    public float invincibilityTime = 0.25f;
    public bool IsAlive
    {
        get
        {
            return _isAlive;
        }
        set
        {
            _isAlive = value;
            animator.SetBool(AnimationStrings.isAlive, value);

            if (value == false)
            {
                damageableDeath.Invoke();
            }

        }
    }

    public bool LockVelocity
    {
        get
        {
            return animator.GetBool(AnimationStrings.lockVelocity);
        }
        set
        {
            animator.SetBool(AnimationStrings.lockVelocity, value);
        }
    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
    }
    void Update()
    {

        if (isInvincible)
        {//neu dang vo dich
            if (timeSinceHit > invincibilityTime)
            {
                //remove invincibility;
                isInvincible = false;
                timeSinceHit = 0;
            }
            timeSinceHit += Time.deltaTime;

        }

    }

    public bool Hit(float damage, Vector2 knockBack)
    {

        if (IsAlive && !isInvincible)
        {
            isInvincible = true;
            //Notify other subscribed components that the damageble was hit to handle the knockback and such
            damageableHit?.Invoke(damage, knockBack);
            //    CharacterEvents.characterDamaged.Invoke(gameObject, damage);

            Health -= damage;
            animator.SetTrigger(AnimationStrings.hitTrigger);

            return true;
        }
        //Unable to be hit
        return false;
    }

    // Returns whether the charcater was healed or not
    public bool Heal(float healthRestore)
    {//hoi mau
        if (IsAlive && Health < MaxHealth)
        {
            float maxHeal = Mathf.Max(MaxHealth - Health, 0);
            float actualHeal = Mathf.Min(maxHeal, healthRestore);

            Health += actualHeal;
            //    CharacterEvents.characterHealed.Invoke(this.gameObject, actualHeal);
            return true;
        }

        return false;
    }
}