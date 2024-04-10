using UnityEngine;

public class PlasmaGun : Weapon
{
    public override void Shoot(Transform shootPoint)
    {
        if (Time.time >= NextFireTime)
        {
            Instantiate(Bullet, shootPoint.position, Quaternion.identity);
            NextFireTime = Time.time + FireDelay;
        }
    }
}
