using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shakeButton : MonoBehaviour
{

    private float speed = 90;


    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        float shake = Input.GetAxis("Vertical") * Time.deltaTime * speed;
        transform.Translate(0f, shake, 0f);
       
        Vector3 clampedPosition = transform.position;            //initial vector value = player pos
        
        clampedPosition.y = Mathf.Clamp(transform.position.y, -20f, 20f);  //y value clamps
      
        transform.position = clampedPosition;   //object position clamped between set values




        //float translation = Input.GetAxis("Vertical") * speed;

        // translation *= Time.time;

        //transform.Translate(0, translation, 0 );

    }
}