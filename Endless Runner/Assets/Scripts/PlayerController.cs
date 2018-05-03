using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public Animator animator;

	// Use this for initialization
	void Start ()
    {
        animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		
        
	}

    public void PlayDeathAnimation() { animator.SetBool("Death", true); }

    public void StopDeathAnimation() { animator.SetBool("Death", false); }

    public void PlayAirAnimation() { animator.SetBool("InAir", true); }

    public void StopAirAnimation() { animator.SetBool("InAir", false); }
}
