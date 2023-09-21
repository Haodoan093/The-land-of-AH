using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicSkill : ProjectileLauncherBase
{


    protected override void Start()
    {

        base.Start();


    }
    public override void LaunchProjectiles()
    {
      
        for (int i = 0; i < quantity; i++) {
            Vector3 point = targetPoint.playerPosition;

            point = new Vector3(
                point.x + Random.Range(-4,4),
                point.y+0.2f,
                point.z);
            GameObject projectile = Instantiate(projectilePrefab, point, projectilePrefab.transform.rotation);

            projectile.transform.parent = bulletContainer;

        }

    }



}
