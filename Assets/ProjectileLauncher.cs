using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileLauncher : MonoBehaviour
{

    public GameObject projectilePrefab;
    public Transform launchPoint;

    public GameObject skill2Prefab;
    public Transform launchPoint2;

    public GameObject spSkillPrefab;
    public Transform launchPoint3;



    // Start is called before the first frame update
    void Start()
    {
        
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
    public void Skill2()
    {
        GameObject projectile = Instantiate(skill2Prefab, launchPoint2.transform.position, skill2Prefab.transform.rotation);
        Vector3 origScale = projectile.transform.localScale;

        projectile.transform.localScale = new Vector3(
            origScale.x * transform.parent.localScale.x > 0 ? 1 : -1,
            origScale.y,
            origScale.z);
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
    // Update is called once per frame
    void Update()
    {
        
    }
}
