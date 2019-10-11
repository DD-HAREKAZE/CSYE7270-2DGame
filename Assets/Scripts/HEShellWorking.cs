using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEShellWorking : MonoBehaviour
{
    public int radius;
    public float standardDamage;


    // Start is called before the first frame update
    void Start()
    {
        standardDamage = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        if (collision.gameObject.tag == "Destructible") 
        {
            collision.gameObject.GetComponent<DestructibleSprite>().ApplyDamage(collision.contacts[0].point,radius);
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Boundary")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Deadline")
        {
            Destroy(gameObject);
        }
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<playerController>().fullHEDamage();
            Destroy(gameObject);
        }
    }
}
