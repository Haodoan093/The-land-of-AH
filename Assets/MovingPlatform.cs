using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MovingPlatform : MonoBehaviour
{
    public bool onGra=false;
    public float speed;
    Vector3 targetPos;

    PlayerController playerController;
    Rigidbody2D rigi;
    Vector3 moveDirection;
    Rigidbody2D playerRB;

    public GameObject ways;
    public Transform[] waypoints;
    int pointIndex;
    int pointCount;
    int direction = 1;

    public float waitDuration;
    private void Awake()
    {
        playerController = GameManager.Instant.Player.GetComponent<PlayerController>();
        rigi=GetComponent<Rigidbody2D>();
        playerRB = GameManager.Instant.Player.GetComponent<Rigidbody2D>();
        waypoints = new Transform[ways.transform.childCount];
        for(int i = 0; i < ways.transform.childCount; i++)
        {
            waypoints[i]=ways.transform.GetChild(i).gameObject.transform;
        }
    }
    private void Start()
    {
        pointIndex = 1;
        pointCount=waypoints.Length;
        targetPos = waypoints[1].transform.position;
      
        DirectionCalculate();
    }
    private void Update()
    {
        if(Vector2.Distance(transform.position, targetPos) < 0.05f)
        {
            NextPoint();
        }
      
    }
    void NextPoint()
    {
        transform.position = targetPos;
        moveDirection = Vector3.zero;
        if (pointIndex == pointCount - 1)
        {
            direction = -1;
        }
        if (pointIndex == 0)
        {
            direction = 1;
        }
        pointIndex += direction;
        targetPos = waypoints[pointIndex].transform.position;
            StartCoroutine(WaitNextPoint());
    }

    IEnumerator WaitNextPoint()
    {
        yield return new WaitForSeconds(waitDuration);
        DirectionCalculate();
    }
    private void FixedUpdate()
    {
        rigi.velocity = moveDirection * speed;
    }
    void DirectionCalculate()
    {
        moveDirection=(targetPos-transform.position).normalized;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerController.isOnPlatform = true;
            playerController.platformrg = rigi;
            collision.transform.parent = transform;

        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.transform.parent = null;
            playerController.isOnPlatform=false;
           
        }
    }
}
