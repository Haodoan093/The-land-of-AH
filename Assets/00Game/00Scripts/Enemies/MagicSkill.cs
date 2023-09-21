using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSkill : MonoBehaviour
{


    public GameObject projectilePrefab;
   
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
                point.y+0.2f,
                point.z);
            GameObject projectile = Instantiate(projectilePrefab, point, projectilePrefab.transform.rotation);
           

          
        }

    }



}
