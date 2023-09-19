using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingEyeController : MonoBehaviour
{
    public float flightSpeed = 3f;
    public float waypointReachedDistance = 0.1f;
    public DetectionZone biteDetectionZone;
    public List<Transform> wayPoints;
    public Collider2D deathCollider;


    Damageable damageable;
    Animator animator;
    Rigidbody2D rigi;


    Transform nextWayPoint;
    int wayPointNum = 0;

    private bool _hasTarget;
    public bool HasTarget
    {
        get
        {
            return _hasTarget;
        }
        private set
        {
            _hasTarget = value;
            animator.SetBool(AnimationStrings.hasTarget, value);
        }
    }
    public bool CanMove
    {
        get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }

    }

    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        rigi = GetComponent<Rigidbody2D>();
        damageable = GetComponent<Damageable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        nextWayPoint = wayPoints[wayPointNum];
    }

    // Update is called once per frame
    void Update()
    {
        HasTarget = biteDetectionZone.detectionColliders.Count > 0;

    }
    private void FixedUpdate()
    {
        if (damageable.IsAlive)
        {
            if (CanMove)
            {
                Flight();
            }
            else
            {
                rigi.velocity = Vector2.zero;
            }
        }


    }
    public void Flight()
    {
        //Fly to next waypoint
        Vector2 directionToWayponit = (nextWayPoint.position - transform.position).normalized;

        //check if we have reached the waypoint already

        float distance = Vector2.Distance(nextWayPoint.position, transform.position);

        rigi.velocity = directionToWayponit * flightSpeed;

        UpdateDirection();

        if (distance <= waypointReachedDistance)
        {
            wayPointNum++;
            if (wayPointNum >= wayPoints.Count)
            {
                wayPointNum = 0;
            }
            nextWayPoint = wayPoints[wayPointNum];
        }
    }

    private void UpdateDirection()
    {
        Vector3 localScale = transform.localScale;

        //Facing the right
        if (transform.localScale.x > 0f)
        {
            if (rigi.velocity.x < 0f)
            {

                transform.localScale = new Vector3(-1 * localScale.x, localScale.y, localScale.z);
            }

        }   //Facing the left
        else
        {
            if (rigi.velocity.x > 0f)
            {

                transform.localScale = new Vector3(-1 * localScale.x, localScale.y, localScale.z);
            }
        }
    }

    public void OnDeath()
    {

        rigi.gravityScale = 1f;
        rigi.velocity = new Vector2(0, rigi.velocity.y);
        deathCollider.enabled = true;

    }
}
