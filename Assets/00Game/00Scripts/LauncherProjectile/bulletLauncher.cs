using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletLauncher : ProjectileLauncherBase
{
    private ObjectPooling objectPooling; // Tham chiếu đến lớp ObjectPooling

    protected override void Start()
    {
        base.Start();

        // Lấy tham chiếu đến lớp ObjectPooling
        objectPooling = ObjectPooling.Instant;
    }

    public override void LaunchProjectiles()
    {
        Vector3 point = launchPoint.transform.position;

        for (int i = 0; i < quantity; i++)
        {
            if (quantity > 1)
            {
                point = new Vector3(
                    point.x + Random.Range(-randomPoints.x, randomPoints.x),
                    point.y + Random.Range(-randomPoints.y, randomPoints.y),
                    point.z);
            }

            // Sử dụng ObjectPooling để lấy một viên đạn từ pool
            GameObject projectile = objectPooling.GetObj(projectilePrefab);

            // Đặt viên đạn thành active để nó hiển thị
            projectile.SetActive(true);

            // Đặt vị trí và xoay viên đạn
            projectile.transform.position = point;
            projectile.transform.rotation = Quaternion.identity;

            Vector3 origScale = projectile.transform.localScale;
            projectile.transform.localScale = new Vector3(
                origScale.x * transform.parent.localScale.x > 0 ? 1 : -1,
                origScale.y,
                origScale.z);

            // Đặt cha của viên đạn là bulletContainer
            projectile.transform.parent = bulletContainer;
        }
    }
}

