using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform launchPoint;

    public GameObject skill2Prefab;
    public Transform launchPoint2;
    private rainPoint rainP;

    public GameObject spSkillPrefab;
    public Transform launchPoint3;

    public GameObject diagonalPrefab;
    public Transform diagonalPoint;


    // Start is called before the first frame update
    void Start()
    {
        rainP=launchPoint2.GetComponent<rainPoint>();
    }
    
    public void FireProjectile()
    {
        GameObject projectile = Instantiate(projectilePrefab, launchPoint.transform.position, projectilePrefab.transform.rotation);
        Vector3 origScale = projectile.transform.localScale;

        projectile.transform.localScale = new Vector3(
            origScale.x * transform.parent.localScale.x > 0 ? 1 : -1,
            origScale.y,
            origScale.z);
    }
    public void DiagonalProjectile()
    {
        GameObject projectile = Instantiate(diagonalPrefab, diagonalPoint.transform.position, diagonalPrefab.transform.rotation);
        Vector3 origScale = projectile.transform.localScale;

        projectile.transform.localScale = new Vector3(
            origScale.x * transform.parent.localScale.x > 0 ? 1 : -1,
            origScale.y,
            origScale.z);
    }
    public void Skill2()
    { Vector3 rainPoint= launchPoint2.GetComponent<rainPoint>().GetClosestEnemyPosition();
        rainPoint=new Vector3(rainPoint.x,rainPoint.y+(2.2f),rainPoint.z);
        if (rainP.HasTarget)
        {

            GameObject projectile = Instantiate(skill2Prefab, rainPoint, skill2Prefab.transform.rotation);
            Vector3 origScale = projectile.transform.localScale;
            projectile.transform.localScale = new Vector3(
             origScale.x * transform.parent.localScale.x > 0 ? 1 : -1,
             origScale.y,
             origScale.z);

        }
        else
        {
            GameObject projectile = Instantiate(skill2Prefab, launchPoint2.transform.position, skill2Prefab.transform.rotation);
            Vector3 origScale = projectile.transform.localScale;
            projectile.transform.localScale = new Vector3(
             origScale.x * transform.parent.localScale.x > 0 ? 1 : -1,
             origScale.y,
             origScale.z);
        }
         
    }
    public void SPSkill()
    {
        GameObject projectile = Instantiate(spSkillPrefab, launchPoint3.transform.position, spSkillPrefab.transform.rotation);
        Vector3 origScale = projectile.transform.localScale;

        projectile.transform.localScale = new Vector3(
            origScale.x * transform.parent.localScale.x > 0 ? 1 : -1,
            origScale.y,
            origScale.z);
    }

}
