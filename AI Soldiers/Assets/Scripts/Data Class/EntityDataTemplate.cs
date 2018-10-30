using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Entity Data Template", menuName = "New Entity Data", order = 0)]
public class EntityDataTemplate : ScriptableObject
{

    public string EntityTag;
    [Tooltip("The tag of this entity's main target")]
    public string TargetTag = "(optional)";
    public float Speed;

    public int Health;
    public int Damage;

    //TODO: Does this need to be here
    //public static EntityDataTemplate CreateInstance(string tag, float speed, int health)
    //{
    //    EntityDataTemplate data = CreateInstance<EntityDataTemplate>();
    //    data.EntityTag = tag;
    //    data.Speed = speed;
    //    data.Health = health;

    //    return data;
    //}

}
