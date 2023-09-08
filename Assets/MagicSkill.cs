using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSkill : MonoBehaviour
{


    public GameObject projectilePrefab;
    public Transform launchPoint;
  
    // Start is called before the first frame update


    public void FireProjectile()
    {
      
        for (int i = 0; i < 3; i++) {
            Vector3 point = launchPoint.transform.position;

            launchPoint.transform.position = new Vector3(
                point.x + Random.Range(-4,4),
                point.y,
                point.z);
            GameObject projectile = Instantiate(projectilePrefab, launchPoint.transform.position, projectilePrefab.transform.rotation);
           

          
        }

    }
}
