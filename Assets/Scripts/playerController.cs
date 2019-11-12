using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerController : MonoBehaviour
{
    private Rigidbody2D player1;
    public GameObject thisPlayer;
    public float moveSpeed;
    public float maxSpeed;
    public int HP;
    public bool faceRight;//judge where the player faces towards
    public string whichPlayer;

    //UI associated
    public Text HPShown;

    // Start is called before the first frame update
    void Start()
    {
        player1 = GetComponent<Rigidbody2D>();
        moveSpeed = 300;
        faceRight = true;
        HP = 100;
    }

    // Update is called once per frame
    void Update()
    {

        if (this.thisPlayer.GetComponent<playerController>().HP <= 0)
        {
            this.thisPlayer.GetComponent<playerController>().HP=0;
            this.thisPlayer.SetActive(false);
        }
        if (faceRight == false) 
        {
            Vector3 turn = new Vector3(-1,1,1);
            this.gameObject.GetComponent<Transform>().localScale = turn;
            //this.gameObject.GetComponent<SpriteRenderer>().flipX=true;
        }
        if (faceRight == true)
        {
            Vector3 turn = new Vector3(1, 1, 1);
            this.gameObject.GetComponent<Transform>().localScale = turn;
            //this.gameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
        HPShown.text = "HP: " + HP.ToString();
        //ATTENTION! I doubt if there is still a bug here or not. ? "whichPlayer" doesn't actually work!
        float moveHorizontal = Input.GetAxis(whichPlayer);
        if (moveHorizontal > 0) 
        {
            faceRight = true;
        }
        if (moveHorizontal < 0)
        {
            faceRight = false;
        }

        Vector2 movement = new Vector2(moveHorizontal, 0);
        //player1.AddForce(movement * moveSpeed);
        Vector2 playerVector = player1.velocity;
        if ((playerVector.x > maxSpeed)&&(playerVector.x>0)) {
            playerVector.x = maxSpeed;
            player1.AddForce(movement * 20);
        }
        else 
        {
            if ((playerVector.x < ((-1) * maxSpeed)) && (playerVector.x < 0))
            {
                playerVector.x = (-1) * maxSpeed;
                player1.AddForce(movement * 20);
            }
            else 
            {
                player1.AddForce(movement * moveSpeed);
            }
        }
        
        player1.velocity = playerVector;
    }

    public void fullHEDamage() 
    {
        HP = HP - 15;
    }


}
