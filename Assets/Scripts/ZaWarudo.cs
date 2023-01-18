using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZaWarudo : MonoBehaviour
{
    bool incerase;
    Vector3 scale;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            other.attachedRigidbody.velocity = Vector3.zero;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        
        Explode();
        
        
    }
    private void OnTriggerExit(Collider other)
    {

    }
    private void OnDestroy()
    {

    }


    void Explode()
    {
        scale = transform.localScale;
        if (scale.x > 10)
        {
            Destroy(gameObject);
        }
        else
        {
            transform.localScale = scale * 1.05f * Time.deltaTime * 50;
        }
    }
}
