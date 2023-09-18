using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CountDownTime : MonoBehaviour
{
    private float attackTimer = 0f;
    private float fireBowTimer = 0f;
    private float rainOfArrowsTimer = 0f;
    private float splazeTimer = 0f;

    // Target cooldown times for each skill
    [SerializeField]
    float attackCooldown = 1f;
    [SerializeField]
    float fireBowCooldown = 2f;
    [SerializeField]
    float rainOfArrowsCooldown = 5f;
    [SerializeField]
    float splazeCooldown = 15f;

    [SerializeField]
    private bool _canAttack = true;
    public bool CanAttack
        {
            get
            {
                return _canAttack;
            }
            set
            {
                _canAttack = value;
            }
        }

    private bool _canFireBow = true;
    public bool CanFireBow
        {
            get
            {
                return _canFireBow;
            }
            set
            {
                _canFireBow = value;
            }
        }

    private bool _canRainOfArrows = true;
    public bool CanRainOfArrows
        {
            get
            {
                return _canRainOfArrows;
            }
            set
            {
                _canRainOfArrows = value;
            }
        }

    private bool _canSPLaze = true;
    public bool CanSPLaze
        {
            get
            {
                return _canSPLaze;
            }
            set
            {
                _canSPLaze = value;
            }
        }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            // Countdown timer for Attack skill
            if (!_canAttack)
            {
                attackTimer += Time.deltaTime;
                if (attackTimer >= attackCooldown)
                {
                    _canAttack = true;
                    attackTimer = 0f;
                }
            }

            // Countdown timer for FireBow skill
            if (!_canFireBow)
            {
                fireBowTimer += Time.deltaTime;
                if (fireBowTimer >= fireBowCooldown)
                {
                    _canFireBow = true;
                    fireBowTimer = 0f;
                }
            }

            // Countdown timer for RainOfArrows skill
            if (!_canRainOfArrows)
            {
                rainOfArrowsTimer += Time.deltaTime;
                if (rainOfArrowsTimer >= rainOfArrowsCooldown)
                {
                    _canRainOfArrows = true;
                    rainOfArrowsTimer = 0f;
                }
            }

            // Countdown timer for SPLaze skill
            if (!_canSPLaze)
            {
                splazeTimer += Time.deltaTime;
                if (splazeTimer >= splazeCooldown)
                {
                    _canSPLaze = true;
                    splazeTimer = 0f;
                }
            }
        }
}
