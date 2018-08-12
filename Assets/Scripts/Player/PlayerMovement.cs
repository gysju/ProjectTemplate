using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : UnitMovement
{
    void Start ()
    {
		
	}
	
	void Update ()
    {
        Orientation();
        Movement();
    }

    public override void Orientation()
    {
        float hor = Input.GetAxis("Horizontal");
        float ver = Input.GetAxis("Vertical");

        if (Mathf.Abs(hor + ver) > 0.0f)
            transform.rotation = Quaternion.AngleAxis( Mathf.Rad2Deg * Mathf.Atan2(-ver, hor), -transform.forward);
    }

    public override void Movement()
    {

    }
}
