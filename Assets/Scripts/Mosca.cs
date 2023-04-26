using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Mosca : MonoBehaviour
{
    Vector3 initialPosition;
    public bool hasKey;
    public int livesCount = 3;
      public int scoreCount = 0;
    public TextMeshProUGUI txtLives;
    public TextMeshProUGUI txtScore;
   

    // Start is called before the first frame update
    void Start()
    {
        txtLives.text = livesCount.ToString();
        txtScore.text = scoreCount.ToString();
        initialPosition = transform.position;
    }

    private void Update()
    {
        if (livesCount == 0)
        {
            Destroy(gameObject);
            livesCount = -1 ;
        }

    }


    //Destruir la mosca si colisiona con el ventilador
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ventilador" )
        {
            transform.position = initialPosition;
            livesCount = livesCount - 1;
            txtLives.text = livesCount.ToString();
        } else if (collision.gameObject.tag == "moneda")
        {
            hasKey = true;
            Destroy(collision.gameObject);
            scoreCount = scoreCount + 1;
            txtScore.text = scoreCount.ToString();
        }  
    }

    void PlayerDeath()
    {

    }
}
