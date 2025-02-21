using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IceBeamLogic : MonoBehaviour
{
    [SerializeField] private float launchVelocity = 150f;
    public GameObject IcebeamParticle;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<Rigidbody>().velocity = transform.forward * launchVelocity;
        Destroy(gameObject, 5);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(Instantiate(IcebeamParticle, transform.position, transform.rotation), 2);
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<VehicleWeaponItemLogic>().Freeze();
            Destroy(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
