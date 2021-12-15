using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombController : MonoBehaviour
{

    public float timeToExplode;
    public int power;
    private float currentTimeToExplode;
    public Transform[] angles;
    public ExplosionBehaviour explosionPrefab;
    public float distanceExplosion;

    // Start is called before the first frame update
    void Start()
    {
        foreach (Transform side in angles)
        {
            Debug.Log(side.position);
            
        }       
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTimeToExplode += Time.deltaTime;

        if(currentTimeToExplode > timeToExplode){
            Explode();
        }
    }

    public void Explode(){
        int i = 0;
        int currentPower = power;
        foreach (Transform side in angles)
        {
            i++;

            RaycastHit2D hitInfo = Physics2D.Linecast(transform.position, side.position);
            if(hitInfo.collider != null){
                currentPower = 0;
            }else{
                currentPower = power;

            }

            Vector2 direction = new Vector2();
                string position = "vertical";

                if(i == 1){
                    direction = Vector2.up;
                }else if(i == 2){
                    direction = Vector2.down;
                }else if(i == 3){
                    direction = Vector2.left;
                }else if(i == 4){
                    direction = Vector2.right;
                }

               // if(i == 3 || i == 4) position = "horizontal";

                
                Vector2 newDistance = distanceExplosion * direction;

                InstantiateExplosion(position, currentPower, newDistance);
                
                
                //Debug.Log(hitInfo);
        }        

        //GameObject explosion = Instantiate(explosionPrefab.gameObject, transform.position, transform.rotation) as GameObject;

        //explosion.GetComponent<ExplosionBehaviour>().Detonate("center",0, Vector2.zero);

        InstantiateExplosion("center", 0, Vector2.zero);
        Destroy(gameObject);
    }

    public void InstantiateExplosion(string position, int power, Vector2 distance){
        Vector3 newPosition = transform.position;
        newPosition += new Vector3(distance.x,distance.y, 0);
        GameObject explosion = Instantiate(explosionPrefab.gameObject, newPosition, transform.rotation) as GameObject;

        explosion.GetComponent<ExplosionBehaviour>().Detonate(position,power, distance);
    }
}
