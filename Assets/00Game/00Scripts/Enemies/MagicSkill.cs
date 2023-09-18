using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSkill : MonoBehaviour
{


    public GameObject projectilePrefab;
    public Transform launchPoint;

    // Start is called before the first frame update
    public DetectionRange targetPoint;

    private void Awake()
    {
        targetPoint=this.GetComponent<DetectionRange>();
    }

    public void FireProjectile()
    {
      
        for (int i = 0; i < 3; i++) {
            Vector3 point = targetPoint.playerPosition;

            point = new Vector3(
                point.x + Random.Range(-4,4),
                point.y,
                point.z);
            GameObject projectile = Instantiate(projectilePrefab, point, projectilePrefab.transform.rotation);
           

          
        }

    }
}
