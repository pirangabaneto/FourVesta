using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyIA : MonoBehaviour {

    public GameObject player;
    public float speed;


    // Update is called once per frame
    void Update() {
        if (Vector2.Distance(transform.position, player.transform.position) < 2.5f) {
            transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1.1f * speed * Time.deltaTime);
        }
    }
}
