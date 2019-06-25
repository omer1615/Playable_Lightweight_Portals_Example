using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalGun : MonoBehaviour
{
    public GameObject portalA_prefab, portalB_prefab;
    private GameObject portalA, portalB;
    public UnityStandardAssets.Characters.FirstPerson.RigidbodyFirstPersonController player;

    void Start()
    {
        portalA = Instantiate(portalA_prefab);
        portalB = Instantiate(portalB_prefab);

        portalA.GetComponent<Portal>().pairPortal = portalB.transform;
        portalB.GetComponent<Portal>().pairPortal = portalA.transform;
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            
            if (Physics.Raycast(player.cam.transform.position, player.cam.transform.forward, out RaycastHit hit))
            {
                portalA.transform.position = hit.point;
                portalA.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
            }
        }

        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            
            if (Physics.Raycast(player.cam.transform.position, player.cam.transform.forward, out RaycastHit hit))
            {
                portalB.transform.position = hit.point;
                portalB.transform.rotation = Quaternion.FromToRotation(Vector3.forward, hit.normal);
            }
        }
    }
}
