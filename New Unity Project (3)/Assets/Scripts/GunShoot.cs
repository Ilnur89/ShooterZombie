using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GunShoot : MonoBehaviour
{
    public float damage = 10f;
    public float range = 100f;
    public ParticleSystem flash;
    public Camera fpscam;
    public GameObject impacteffect;
    public float NextTimeFire=0f;
    public float firetime = 15f;

    void Update()
    {
        if (Input.GetButton("Fire1")&&Time.time>=NextTimeFire) 
        {
            NextTimeFire = Time.time +1 / firetime;
            Shoot();
        }
    }
    void Shoot()
    {
        flash.Play();
        RaycastHit hit;
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            Zombie target = hit.transform.GetComponent<Zombie>();
            if (target != null)
            {
                target.TakeDamage(damage);
            }
            Instantiate(impacteffect, hit.point, Quaternion.LookRotation(hit.normal));
        }
       // mazoflash.Play();
    }
}
