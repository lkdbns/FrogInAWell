using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DealDamageComponent : MonoBehaviour {

    public GameObject hitFX;
	public GameObject aimPart;
    public GameObject projectile;
    public float xForce;
    public float yForce;
    public GameObject fireEffect;
    [SerializeField] private Transform gunTip;
    private Enemy enemy;
    private GameObject target;
    private float nextShootTime = 0;
    //private bool hasShot = false;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        InvokeRepeating("SelectTarget", 0f, 0.5f);
    }

    private void Update()
    {
        
        // Lock on the target - make my enemy follow (rotation) the target
        if(target != null) {
            LockOnTarget();
        }
        // Shoot the target
        if(Time.time > nextShootTime && target != null)
        {
            ShootProjectile();
            // apply damage to the target
            
            if(gameObject.GetComponent<AudioSource>() != null) {
                gameObject.GetComponent<AudioSource>().Play();
            }
            nextShootTime = Time.time + 1f / enemy.shootRate;
        }
    }

    private void LockOnTarget()
    {
        Vector3 dir = target.transform.position - transform.position;
        //enemy.transform.rotation = Quaternion.LookRotation(dir);
        aimPart.transform.rotation = Quaternion.LookRotation(dir);
    }

    private void ShootProjectile()
    {
        if(fireEffect != null) {
            GameObject effectInstance = Instantiate(fireEffect, gunTip.position, Quaternion.LookRotation(gunTip.transform.up, Vector3.up));
            Destroy(effectInstance, 1f);
        }

        GameObject projectileInstance = Instantiate(projectile, gunTip.position, Quaternion.LookRotation(gunTip.transform.forward, Vector3.up));
        projectileInstance.GetComponent<Projectile>().damage = enemy.enemyDamage;
        projectileInstance.GetComponent<Rigidbody>().AddRelativeForce(new Vector3(0, yForce, xForce));
    }  

    private void SelectTarget()
    {
        // get player
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        float dist = Vector3.Distance(transform.position, player.transform.position);

        // select that as target if within range
        if (dist <= enemy.enemyRange)
            target = player;
        else
            target = null;
    }
	

}
