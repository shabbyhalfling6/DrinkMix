using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottlePickup : MonoBehaviour
{
    public bool pickedUp = false;

    //change this on the bottle prefab to change all bottles
    public float smoothFactor;

    public KeyCode pickUpKey = KeyCode.Q;

    private Bottle bottle;
    private Transform tiltPosition;

    private Vector3 startPosition;
    private Vector3 originalPosition;

    void Start ()
    {
        bottle = GetComponent<Bottle>();

        originalPosition = transform.position;
        startPosition = originalPosition;

        tiltPosition = GameObject.Find("BottleTiltPosition").transform;
	}
	
	void Update ()
    {
		if ((Input.GetKeyDown(pickUpKey) && !GameManager.Instance().bottlePickedUp) || SerialHolder.angle[bottle.id] > 15) // fix id to come from bottle.  add put down code when goes below 15
        {
            pickedUp = true;
            bottle.enabled = true;
            GameManager.Instance().bottlePickedUp = true;

            startPosition = transform.position;
        }
        else if ((Input.GetKeyDown(pickUpKey) && GameManager.Instance().bottlePickedUp) || SerialHolder.angle[bottle.id] < 15)
        {
            pickedUp = false;
            bottle.enabled = false;
            GameManager.Instance().bottlePickedUp = false;
        }

        if (pickedUp)
        {
            LerpBetween(startPosition, tiltPosition.position, smoothFactor);
        }
        else if(!pickedUp)
        {
            LerpBetween(startPosition, originalPosition, smoothFactor);
            transform.rotation = new Quaternion(0, 0, 0, 0);
        }
    }

    void LerpBetween(Vector3 start, Vector3 finish, float smooth)
    {
        transform.position = Vector3.Lerp(transform.position, finish, Time.deltaTime * smooth);
    }
}
