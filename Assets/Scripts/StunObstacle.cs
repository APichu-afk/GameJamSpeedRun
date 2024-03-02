using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StunObstacle : MonoBehaviour
{
    private bool die = false;
    private float dieTime = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(die)
        {
            dieTime -= Time.deltaTime;
            if (dieTime <= 0.0f)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            die = true;
        }
    }
}
