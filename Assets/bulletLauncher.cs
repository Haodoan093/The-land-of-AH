﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLauncher : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform launchPoint;
    public int quanlity=1;
  
   
    // Start is called before the first frame update
    DetectionRange targetPoint;

    private void Start()
    {
        targetPoint = this.GetComponent<DetectionRange>();
    }

    // Update is called once per frame
    public void ShootBullets()
    {
        Vector3 point = launchPoint.transform.position;



       for (int i = 1; i < quanlity; i++)
        {
            if(quanlity > 2) {
                point = new Vector3(
               point.x + Random.Range(-2f, 2f),
               point.y + Random.Range(-1f, 1f),
               point.z);
            }
            GameObject projectile = Instantiate(projectilePrefab, point, Quaternion.identity);
           
            Vector3 origScale = projectile.transform.localScale;
            projectile.transform.localScale = new Vector3(
               origScale.x * transform.parent.localScale.x > 0 ? 1 : -1,
               origScale.y ,
               origScale.z);
        }

       
    }

}