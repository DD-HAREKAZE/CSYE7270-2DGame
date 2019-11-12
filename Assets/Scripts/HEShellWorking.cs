using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HEShellWorking : MonoBehaviour
{
    public int radius;
    public float standardDamage;
    public GameObject explosionParticle;
    System.Random random =new System.Random(1000);


    // Start is called before the first frame update
    void Start()
    {
        standardDamage = 15f;
    }

    // Update is called once per frame
    void Update()
    {
        shellFlyingAngle();
    }

    private void OnCollisionEnter2D(Collision2D collision) 
    {
        Vector3 collisionPoint = new Vector3();
        collisionPoint = transform.position;

        //Transform c_transform = collision.transform;
        Quaternion c_rotation = new Quaternion();
        GameObject _Explode= Instantiate(explosionParticle,collisionPoint,c_rotation);

        int randomNumber = Random.Range(1, 7);
        if (collision.gameObject.tag == "Destructible") 
        {
            collision.gameObject.GetComponent<DestructibleSprite>().ApplyDamage(collision.contacts[0].point,radius);
            FindObjectOfType<audioManager>().Play("Explosion"+randomNumber);
            Debug.Log("Random Explode sound source: "+randomNumber);
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
            FindObjectOfType<audioManager>().Play("Explosion" + randomNumber);
            Destroy(gameObject);
        }
    }

    private void shellFlyingAngle() 
    {
        //TODO
        //this.gameObject.transform.rotation
        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x > 0)
        {
            this.gameObject.transform.Rotate(new Vector3(0,0,-60*Time.deltaTime));
        }
        if (this.gameObject.GetComponent<Rigidbody2D>().velocity.x < 0)
        {
            this.gameObject.transform.Rotate(new Vector3(0, 0, 60 * Time.deltaTime));
        }

    }
}
