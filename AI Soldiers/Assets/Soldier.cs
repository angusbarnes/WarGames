using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Entity {

    Entity target;
    Animator anim;

    public Transform firePoint;
    public GameObject bullet;
    public float shootCoolDown = 1f;
    // Use this for initialization
    void Start () {

        target = CombatManager.GetRandomTarget("Soldier");
        anim = GetComponent<Animator>();
    }
	
	// Update is called once per frame
	void Update () {
        DoCombatAI();
        CheckHealth();

        if (shootCoolDown > 0) {
            shootCoolDown -= Time.deltaTime;
        }

        //TODO: Could be farmed out to extension method
        if (Mathf.Approximately(rb2d.velocity.x, 0f) && Mathf.Approximately(rb2d.velocity.y, 0f)) {
            anim.SetBool("Walking", false);
        } else {
            anim.SetBool("Walking", true);
        }
	}

    public virtual void DoCombatAI()
    {
        if(target == null) {
            target = CombatManager.GetRandomTarget(targetTag);
            return;
        }

        //TODO: Remove this god awful tenery expression
        float x = target.GetPositionX() - transform.position.x <= Random.Range(20f, 35f) ? 0f : target.GetPositionX() - transform.position.x;
        if(Mathf.Abs(x) <= 0.05f) {
            x = 0f;
        }
        float y = target.GetPositionY() - transform.position.y;
        if(Mathf.Abs(y) <= 0.05f) {
            y = 0f;
        }
        Vector2 direction = new Vector2(x, y).normalized;
        rb2d.velocity = direction * speed;
        Shoot();
    }

    private void Shoot()
    {
        if(shootCoolDown <= 0) {
            GameObject obj = Instantiate(bullet, firePoint.position, firePoint.rotation, firePoint);
            Bullet b = obj.GetComponent<Bullet>();
            b.Immunity = entityTag;
            b.Damage = m_Entity.Damage;
            shootCoolDown = 1f;
        }
    }

}
