using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSkill : MonoBehaviour
{


    public GameObject projectilePrefab;
    public Transform launchPoint;
    public int quanlity = 3;
    public Vector2 ranPonits;


    // Start is called before the first frame update
    DetectionRange targetPoint;

    private void Start()
    {
        targetPoint = this.GetComponent<DetectionRange>();
    }

    public void FireProjectile()
    {
      
        for (int i = 0; i < quanlity; i++) {
            Vector3 point = targetPoint.playerPosition;

            point = new Vector3(
                point.x + Random.Range(-4,4),
                launchPoint.transform.position.y,
                point.z);
            GameObject projectile = Instantiate(projectilePrefab, point, projectilePrefab.transform.rotation);
           

          
        }

    }



}
