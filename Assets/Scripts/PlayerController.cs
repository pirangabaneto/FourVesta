using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speedWalk;

    private Vector2 input;
    private Animator animator;
    private Rigidbody2D rb2d;
    public Vector2 newSpeed;
    
    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        input.x = Input.GetAxisRaw("Horizontal");

        //Debug.Log(input.x);
        //Debug.Log(input.x);
        input.y = Input.GetAxis("Vertical");

        // se ele receber valor de vector2, entao esta caminhando
        if(input != Vector2.zero){
            animator.SetBool("inWalk", true);
        }else{
            animator.SetBool("inWalk", false);

        }

        // setando os vetores de velocidade para as variaveis definidas
        //animator.SetFloat("velocityY", input.y);
        animator.SetFloat("velocityY", input.x);      

        //newSpeed = input * speedWalk * Time.deltaTime;
        //Debug.Log(newSpeed);
        //rb2d.velocity = newSpeed;

    }
}
