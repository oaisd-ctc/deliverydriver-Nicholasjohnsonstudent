using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delivery : MonoBehaviour
{
    [SerializeField] Color32 hasPackageColor = new Color32(0, 255, 255, 255);
    [SerializeField] Color32 noPackageColor = new Color32(255,255,255,255);

    SpriteRenderer spriteRenderer;

    void Start() 
    {
        spriteRenderer = GetComponent<SpriteRenderer>();    
    }
    bool hasPackage;
    [SerializeField] float pickupDelay = 1f;
    void OnCollisionEnter2D(Collision2D other) 
    {
        Debug.Log("Ouch!!");
        
    }
    void OnTriggerEnter2D(Collider2D other) 
    {
            if (other.tag == "Package" && !hasPackage)
            {
                Debug.Log("package picked up");
                hasPackage = true;
                spriteRenderer.color = hasPackageColor;
                Destroy(other.gameObject, pickupDelay);
                
            }

            if (other.tag == "Customer" && hasPackage)
            {
                Debug.Log("droped off at customer");
                hasPackage = false;
                spriteRenderer.color = noPackageColor;
            }
    }
}
