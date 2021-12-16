using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public float speedWalk;

    private Vector2 input;
    public Animator animator;
    private Rigidbody2D rb2d;
    public Vector2 newSpeed;
    
    // da outra implementacao
    public float moveSpeed = 2f;
    public Rigidbody2D rb;
    Vector2 movement;
    public BombController bombPrefab;

    // Start is called before the first frame update/*
    void Start()
    {
        //#animator = GetComponentInChildren<Animator>();
       //rb2d = GetComponent<Rigidbody2D>();

       // setando posicao do player
      //# spawn = new Vector2(0,0);
       //transform.position = new Vector3(10f,10f,0f);

    }

    // Update is called once per frame
    void Update()
    {/*
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
*/
        //input
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);

        if(Input.GetKeyDown(KeyCode.Space)){
            Instantiate(bombPrefab.gameObject, transform.position, transform.rotation);
        }
    }

    void FixedUpdate() {
        // movement
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OnCollissionEnter(Collider2D collision) {
        Debug.Log("hitou");
        if(collision.gameObject.CompareTag("Enemy")){
            //Debug.Log(vidas + "--------------------------------------------------------------------------------");
            if(ExplosionBehaviour.vidas == 3){
                Destroy(GameObject.FindWithTag("coracao03"));
                ExplosionBehaviour.vidas--;
            }else if(ExplosionBehaviour.vidas == 2){
                Destroy(GameObject.FindWithTag("coracao02"));
                ExplosionBehaviour.vidas--;
            }else if (ExplosionBehaviour.vidas == 1){
                Destroy(GameObject.FindWithTag("coracao01"));
                ExplosionBehaviour.vidas--;
            }else {
                SceneManager.LoadScene (sceneName:"Menu");
                ExplosionBehaviour.vidas = 3;
            }
            //SceneManager.LoadScene (sceneName:"Menu");
        }
    }
}
