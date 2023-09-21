using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileLauncherBase : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public Transform bulletContainer;
    [SerializeField]
    protected int quantity = 1;
    public Vector2 randomPoints;

    protected DetectionRange targetPoint;

    protected virtual void Start()
    {
        
            targetPoint = this.GetComponent<DetectionRange>();
    }

    public abstract void LaunchProjectiles();
}
