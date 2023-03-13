using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    public GunBody body;
    public GunMag mag;
    public GunBarrel barrel;
    bool reload;
    [SerializeField] GameObject bullet;

    // Start is called before the first frame update
    void Start()
    {
        bullet = FindObjectOfType<Bullet>().gameObject;
        mag.bullets = mag.totalBullets;
    }

    // Update is called once per frame
    void Update()
    {
        if (reload)
        {
            body.shotInterval -= Time.deltaTime;
            if (body.shotInterval <= 0)
            {
                reload = false;
                mag.bullets = mag.totalBullets;
                body.shotInterval = 0;
            }
        }
        else
        {
            body.shotInterval += Time.deltaTime;
            if (Input.GetKey(KeyCode.Mouse0) && body.shotInterval > body.rateOfFire)
            {
                Shoot();
                body.shotInterval = 0;
                mag.bullets--;
                if (mag.bullets == 0)
                {
                    reload = true;
                    body.shotInterval = mag.reloadTime;
                }
            }
        }
    }

    void Shoot()
    {
        for (int i = 0; i < mag.pellets; i++)
        {
            GameObject newBullet = Instantiate(bullet, transform.position, transform.rotation);
            Vector3 bulletAccuracy = transform.forward + new Vector3(Random.Range(-body.accuracy, body.accuracy), Random.Range(-body.accuracy, body.accuracy), 0);
            newBullet.GetComponent<Rigidbody>().AddForce(bulletAccuracy.normalized * barrel.bulletSpeed);
            newBullet.GetComponent<Bullet>().damage = mag.damage;
            newBullet.GetComponent<Bullet>().minRange = barrel.minRange;
            newBullet.GetComponent<Bullet>().maxRange = barrel.maxRange;
        }
    }
}


