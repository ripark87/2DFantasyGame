﻿using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour 
{	
		
		public Vector2 speed = new Vector2(50, 50);
		private Vector2 movement;
		Animator anim;

		void Start()
	{
		anim = GetComponent<Animator>();
	}


		void Update()
	{
			float inputX = Input.GetAxis("Horizontal");
			float inputY = Input.GetAxis("Vertical");

            //enable animation for both horizontal and vertical.
            float temp = Mathf.Abs(inputX + inputY);

			movement = new Vector2(
				speed.x * inputX,
				speed.y * inputY);
			
			anim.SetFloat("Speed", temp);


		//Mouse control 
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition); 
			transform.LookAt(ray.GetPoint(-1000),Vector3.forward);

	}
		
		void FixedUpdate()
	{
			rigidbody2D.velocity = movement;
	}
}