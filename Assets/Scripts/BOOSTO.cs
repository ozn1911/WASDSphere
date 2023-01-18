using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOOSTO : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionStay(Collision collision)
    {
        PlayerCollision(collision);
    }

    #region Functions
    void PlayerCollision(Collision collision)
    {
        if (collision.transform.CompareTag("Player"))
        {
            float t = Time.deltaTime * 50;

            //Debug.Log(t);
            collision.rigidbody.velocity *= 1.05f * t;
        }
    }
    #endregion
}
