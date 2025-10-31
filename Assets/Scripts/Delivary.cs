using NUnit.Framework;
using Unity.VisualScripting;
using UnityEngine;

public class Delivary : MonoBehaviour
{
    bool isHavePackage;
    [SerializeField] float delay = 0.3f;
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Package") && isHavePackage == false)
        {
            Debug.Log("Picked up package!");
            isHavePackage = true;
            GetComponent<ParticleSystem>().Play();
            Destroy(collision.gameObject, delay);
        }

        if (collision.CompareTag("Customer") && isHavePackage)
        {
            Debug.Log("Package Delivared!");
            GetComponent<ParticleSystem>().Stop();
            Destroy(collision.gameObject, delay);
            isHavePackage = false;
            
        }
    }
}
