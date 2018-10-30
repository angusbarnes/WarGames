using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hub : Entity {
    [Space(10)]
    [Header("Hub Attributes:")]
    public float SpawnRate = 1f;
    private float m_SpawnRate;
    public GameObject soldier;
    public GameObject otherBase;


    public Color SuperBaseColor;

    public GameObject SuperSoldier;

    public SpriteRenderer sr;

    public void SetSpawnRate(float rate)
    {
        SpawnRate = rate;
        m_SpawnRate = rate;
    }

    public void SuperBase()
    {
        SpawnRate = 3f;
        m_SpawnRate = 3f;
        health = 250;
 
        GetComponent<SpriteRenderer>().color = SuperBaseColor;
        soldier = SuperSoldier;
    }

    // Use this for initialization
    void Start () {
        m_SpawnRate = SpawnRate;
        if (Random.Range(0, 5) == 0) {
            SuperBase();
        }
        else SetSpawnRate(Random.Range(1f, 4f));
	}
	
	// Update is called once per frame
	void Update () {
        SpawnRate -= Time.deltaTime;
        CheckHealth();

        if(SpawnRate <= 0) {
            Instantiate(soldier, transform.position, Quaternion.identity);
            SpawnRate = m_SpawnRate;
        }

        sr.size = new Vector2(4.71f * ((float)health/m_Entity.Health), sr.size.y);

	}

    protected override void Die()
    {
        Instantiate(otherBase, transform.position, Quaternion.identity);
        CombatManager.RemoveEntity(m_Entity.EntityTag, this);
        Destroy(this.gameObject);
    }
}
