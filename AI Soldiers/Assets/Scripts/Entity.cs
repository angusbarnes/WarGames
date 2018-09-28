using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Collider2D))]
public class Entity : MonoBehaviour {

    #region Members
    // Members should be kept private were possible
    public EntityDataTemplate EntityTemplate;
    protected EntityData m_Entity;

    #endregion

    #region Class Variables
    protected string entityTag; //CANNOT be 'tag' as that is reserved by the unity component class
    protected string targetTag;
    protected float speed;
    protected int health;

    protected Collider2D entityCollider;
    protected Rigidbody2D rb2d;

    #endregion

    #region Interface Methods
    public void SetEntity(EntityData entity)
    {
        m_Entity = entity;
    }

    public EntityData GetEntity()
    {
        return m_Entity;
    }

    public float GetPositionX()
    {
        return transform.position.x;
    }

    public float GetPositionY()
    {
        return transform.position.y;
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }
    #endregion

    #region Gameplay Methods
    public void Move(float x, float y)
    {

    }

    public void Move(Vector2 amount)
    {

    }

    public void DoDamage(int health)
    {
        m_Entity.Health -= health;
    }
    #endregion

    public void Awake()
    {
        // Initalize state. See 'EntityData' for more info
        m_Entity = (EntityData)EntityTemplate;
        entityTag = m_Entity.EntityTag;
        targetTag = m_Entity.TargetTag;
        speed = m_Entity.Speed;
        health = m_Entity.Health;

        entityCollider = GetComponent<Collider2D>();
        rb2d = GetComponent<Rigidbody2D>();

        // TODO: Ensure that when instantiating entities that we add an incremental ID
        CombatManager.RegisterEntity(this, m_Entity.EntityTag);
    }

    protected virtual void CheckHealth()
    {
        if (m_Entity.Health <= 0) {
            print("Die");
            CombatManager.RemoveEntity(entityTag, this);
            Destroy(gameObject);
        }
    }

    public override string ToString()
    {
        return "Entity: " + m_Entity.EntityTag + "("+m_Entity.Health.ToString()+")";
    }
}
