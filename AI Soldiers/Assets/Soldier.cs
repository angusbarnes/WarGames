using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier : Entity {

    Entity target;
    Animator anim;
    SpriteRenderer spriteRenderer;
    bool facingLeft = false;
    
    public Transform firePoint;

    //TODO: This needs to be implemeted in a seperate data class
    public GameObject bullet;
    public float shootCoolDown = 1f;

    // Use this for initialization
    void Start () {

        target = CombatManager.GetRandomTarget("Soldier");
        anim = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        DoCombatAI();
        CheckHealth();

        if (shootCoolDown > 0) {
            shootCoolDown -= Time.deltaTime;
        }

        //TODO: Could be farmed out to extension method
        if (rb2d.velocity.AlmostZero()) {
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

        //VITAL: Remove this god awful tenery expression
        float x = Mathf.Abs(target.GetPositionX() - transform.position.x) <= Random.Range(20f, 35f) ? 0f : target.GetPositionX() - transform.position.x;
        if(Mathf.Abs(x) <= 0.5f) {
            x = 0f;
        }
        if(x < 0f && !facingLeft) {
            Flip(180f);
            facingLeft = true;
        } else if(x > 0 && facingLeft){
            Flip(0f);
            facingLeft = false;
        }
        float y = target.GetPositionY() - transform.position.y;
        if(Mathf.Abs(y) <= 0.5f) {
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

    private void Flip(float amount)
    {
        transform.rotation = Quaternion.Euler(new Vector2(0, amount));
        
    }

}
