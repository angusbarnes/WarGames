using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityData
{

    public string EntityTag;
    public string TargetTag;
    public float Speed;
    //TODO: Move to weapon class
    public int Damage;

    public int Health;

    public static explicit operator EntityData(EntityDataTemplate edo)  // explicit byte to digit conversion operator
    {
        return new EntityData(edo.EntityTag, edo.TargetTag, edo.Speed, edo.Health, edo.Damage);
    }

    public EntityData(string tag, string target, float speed, int health, int damage)
    {
        EntityTag = tag;
        Speed = speed;
        Health = health;
        TargetTag = target;
        Damage = damage;
    }
}
