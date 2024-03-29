using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {

	private CharacterController characterController;
	private Animator animator;

	[SerializeField]
	private float movespeed = 100;
	[SerializeField]
	private float turnSpeed = 5f;

	private void Awake()
	{
		characterController = GetComponent<CharacterController>();
		animator = GetComponentInChildren<Animator> ();

	}

	private void update()
	{
		var horizontal = Input.GetAxis ("Horizontal");
		var vertical = Input.GetAxis ("Vertical");

		var movement = new Vector3 (horizontal, 0, vertical);

		characterController.SimpleMove (movement * Time.deltaTime * movespeed);

		animator.SetFloat("Speed", movement.magnitude);

		if (movement.magnitude > 0)
		{
			
			Quaternion newDiretion = Quaternion.LookRotation (movement);

			transform.rotation = Quaternion.Slerp (transform.rotation, newDiretion, Time.deltaTime * turnSpeed);   ;
		}

	}
}
