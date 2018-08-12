using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour
{
    [Header("Player settings")]
    public FloatVariable AttackSpeed;
    public UnityEvent AttackEvent;

    [SerializeField]
    private Transform _gunOutput;
    [SerializeField]
    private GameObject _bullet;

	void Update ()
    {
        Attack();
    }

    public void Attack()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(_bullet, _gunOutput.position, _gunOutput.rotation);
        }
    }
}
