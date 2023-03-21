using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro; 

public class PlayerScript : MonoBehaviour
{
  private Rigidbody2D rd2d;

    public float speed;

    public TextMeshProUGUI score;
    public TextMeshProUGUI life; 
    public GameObject winTextObj;
    public GameObject loseTextObj; 

    private int scoreValue = 0;
    private int lifeValue = 3; 


    // Start is called before the first frame update
    void Start()
    {
        rd2d = GetComponent<Rigidbody2D>();

        SetScoreText(); 
        setLifeText();
        winTextObj.SetActive(false); 
        loseTextObj.SetActive(false); 
    }

    // Update is called once per frame
    void Update()
    {
        float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
        rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed));
    }

    void SetScoreText(){

        score.text = "Score: " + scoreValue.ToString();
    }
    void setLifeText(){
        life.text = "Life: " + lifeValue.ToString();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
       if (collision.collider.tag == "GameCoin")
        {
            scoreValue += 1;
            score.text = scoreValue.ToString();
            
            Destroy(collision.collider.gameObject); 
            SetScoreText(); 
            if(scoreValue == 8){
               winTextObj.SetActive(true);
            }
        }
        if(collision.collider.tag == "Enemy"){
            lifeValue -= 1; 
            life.text = lifeValue.ToString();
            Destroy(collision.collider.gameObject);
            setLifeText(); 
            if(lifeValue == 0){
                loseTextObj.SetActive(true);
            }
        }

    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Floor")
        {
            if (Input.GetKey(KeyCode.W))
            {
                rd2d.AddForce(new Vector2(0, 1), ForceMode2D.Impulse); //the 3 in this line of code is the player's "jumpforce," and you change that number to get different jump behaviors.  You can also create a public variable for it and then edit it in the inspector.
            }
        }
    }
}
