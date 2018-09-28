using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Bullet : MonoBehaviour {

    public int Damage = 10;
    public float Speed = 5f;
    public string Immunity = "null";

    Rigidbody2D m_RigidBody;

	// Use this for initialization
	void Start () {
        m_RigidBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        m_RigidBody.velocity = transform.right.normalized * Speed;
        StartCoroutine("WaitForDestroy");
	}

    public IEnumerator WaitForDestroy()
    {
        yield return new WaitForSeconds(4.5f);
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Entity hit = collision.gameObject.GetComponent<Entity>();
        if(hit && hit.GetEntity().EntityTag != Immunity)
        {
            hit.DoDamage(Damage);
            Destroy(gameObject);
        }
    }
}
