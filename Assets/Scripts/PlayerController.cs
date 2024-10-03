using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject trait;
    float playerYPos;

    // Start is called before the first frame update
    void Start()
    {
        playerYPos = transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {

        if(GameManager.instance.gameStarted)
        {
            if(!trait.activeInHierarchy)
            {
                trait.SetActive(true);
            }

            if(Input.GetMouseButtonDown(0))
            {
                SwitchPosition();
            }
        }
    }

    void SwitchPosition()
    {
        playerYPos = -playerYPos;

        transform.position = new Vector3(transform.position.x, playerYPos, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if(other.gameObject.CompareTag("Obstacle"))
        {
            GameManager.instance.UpdateLives();
            GameManager.instance.Shake();
        }
    }
}
