using UnityEngine;
using System.Collections;

public class HeroMovement : MonoBehaviour 
{
    //how powerful we want the dodge force to be, set in inspector
    public int power = 2000;
    Ray ray;

	public Vector2 speed = new Vector2(50, 50);
	private Vector2 movement;
    Animator anim;


	void Start()
	{
        anim = GetComponent<Animator>();
        anim.SetBool("Space", false);
	}


	void Update()
	{
        //hero looks toward mouse cursor
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        transform.LookAt(ray.GetPoint(-1000), Vector3.forward);

        //movement controls
		float inputX = Input.GetAxis("Horizontal");
		float inputY = Input.GetAxis("Vertical");
 
		movement = new Vector2(
				speed.x * inputX,
				speed.y * inputY);
			
        //play movement animation as long as player is moving
        anim.SetFloat("Speed", movement.magnitude);
        
	}
		
	void FixedUpdate()
	{

		rigidbody2D.velocity = movement;

        //calculate the direction of roll, turning mouse position into world coordinates
        Vector2 worldMousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (worldMousePos - new Vector2(transform.position.x, transform.position.y)).normalized;

        //Vector2 mouseLook = (Input.mousePosition - transform.position).normalized;

         //teleport controls; when space is pressed, add force in direction hero is facing
        if (Input.GetKeyDown(KeyCode.Space))
        {
            anim.SetTrigger("Space");
            rigidbody2D.AddForce(direction * power);
            
        }
        //if (Input.GetKeyUp(KeyCode.Space)) //&& anim.IsInTransition(0) == false)
        



        //swing sword if LMB pressed down
        if (Input.GetMouseButton(0))
        {
            anim.SetBool("LMBclick", true);
        }
        else
            anim.SetBool("LMBclick", false);
        

	}

}