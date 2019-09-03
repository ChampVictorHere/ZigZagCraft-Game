using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScript : MonoBehaviour
{
    //public InputField inputSpeed;

    public Slider sliderSpeed;

    private Vector3 dir;

    public GameObject ps;

    private bool isDead;

    public GameObject restartButton;

    private int score = 0;

    public Text TextScore;
    // Start is called before the first frame update
    void Start()
    {
        dir = Vector3.zero;
        isDead = false;
    }

    // Update is called once per frame
    void Update()
    {       

        if (Input.GetMouseButtonDown(0) && !isDead)
        {
            //score++;
            TextScore.text = score.ToString();

            if (dir == Vector3.forward)
            {
                dir = Vector3.right;
            }
            else
            {
                dir = Vector3.forward;
            }
        }

        float amoutToMove = sliderSpeed.value * Time.deltaTime;

        transform.Translate(dir * amoutToMove);
    }

    void OnTriggerEnter(Collider other)
    {
       if(other.tag == "Coin")
        {
            other.gameObject.SetActive(false);
            Instantiate(ps, transform.position, Quaternion.identity);
            score++;
            TextScore.text = score.ToString();

        }
    }
    void OnTriggerExit(Collider other)
    {
        if(other.tag == "Tile")
        {
            RaycastHit hit;

            Ray downRay = new Ray(transform.position, -Vector3.up);

            if(!Physics.Raycast(downRay,out hit))
            {
                isDead = true;
                restartButton.SetActive(true); 
                transform.GetChild(0).transform.parent = null;
            }
        }
    }
    /*void FixedUpdate()
    {
        
    }*/
}
