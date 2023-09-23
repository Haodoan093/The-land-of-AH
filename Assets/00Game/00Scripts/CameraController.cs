using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform Target;
    Vector3 velocity=Vector3.zero;
    [Range(0, 1)]
    public float smoothTime;

    public Vector3 positionOffset;
    public Vector2 xLimit;
    public Vector2 yLimit;
    private void Awake()
    {
        Target = GameManager.Instant.Player.GetComponent<Transform>();
    }
    // Update is called once per frame
    private void LateUpdate()
    {
        Vector3 targetPosition=Target.position+positionOffset;
        targetPosition = new Vector3(Mathf.Clamp(targetPosition.x, xLimit.x, xLimit.y), Mathf.Clamp(targetPosition.y, yLimit.x, yLimit.y), - 10);
        transform.position = Vector3.SmoothDamp(transform.position, targetPosition,ref velocity,smoothTime);
    }
}
