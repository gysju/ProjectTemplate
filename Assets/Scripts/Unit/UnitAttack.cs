using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnitAttack : MonoBehaviour
{
    [Header("Unit settings")]

    public FloatVariable AttackAmount;
    public UnityEvent AttackEvent;

    void Start ()
    {
		
	}
	
	void Update ()
    {
		
	}

    public virtual void Attack()
    {

    }
}
