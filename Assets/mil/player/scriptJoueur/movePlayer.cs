using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class movePlayer : MonoBehaviour
{
    public float speed = 5.0f;
    public float jumpForce = 400.0f;
    public bool grounded;
    
    private Rigidbody rb;
    private Animator animatorPlayer;
    private float AxeX;
    private float AxeY;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        animatorPlayer = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(speed * Vector3.back * AxeY * Time.deltaTime);
        transform.Translate(speed * Vector3.right * AxeX * Time.deltaTime);
    }

    void OnHorizontal(InputValue val)
    {
        AxeX = val.Get<float>();
        if(AxeX == -1) // va a gauche
        {
			animatorPlayer.SetBool("walkL",true); 
		}
		else if (AxeX == 1) // va a droite
		{
			animatorPlayer.SetBool("walkR",true);
		}
		else // ne va n'y a gauche ni a droite
		{
			animatorPlayer.SetBool("walkL",false); 
			animatorPlayer.SetBool("walkR",false); 
		}
    }

    void OnVertical(InputValue val)
    {
        AxeY = val.Get<float>();
        if(AxeY == -1) // avance 
        {
			animatorPlayer.SetBool("walkF",true); 
		}
		else if (AxeY == 1) // recule
		{
			animatorPlayer.SetBool("walkB",true);
		}
		else // n'avance pas et ne recule pas
		{
			animatorPlayer.SetBool("walkF",false); 
			animatorPlayer.SetBool("walkB",false); 
		}

    }

    void OnJump()
    {
        if(grounded) 
        {
			animatorPlayer.SetTrigger("jump");
           StartCoroutine(sautDelay(0.7f));
        }
    }
    
    IEnumerator sautDelay(float time)
 {
     yield return new WaitForSeconds(time);
 
     rb.AddForce(Vector3.up * jumpForce);
 }
    
    public void GroundedSet(bool newEtat)
    {
		grounded = newEtat;
	}
}
