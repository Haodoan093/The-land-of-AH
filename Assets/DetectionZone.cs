using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DetectionZone : MonoBehaviour
{
    public UnityEvent noCollidersRemain;

    public List<Collider2D> detectionColliders;
    BoxCollider2D collider;
    private void Awake()
    {
        detectionColliders = new List<Collider2D>();
        collider = this.GetComponent<BoxCollider2D>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        detectionColliders.Add(collision);
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        detectionColliders.Remove(collision);
        noCollidersRemain.Invoke();
    }
}
