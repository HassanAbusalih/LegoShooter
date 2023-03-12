using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAssemblyBox : MonoBehaviour
{
    [SerializeField] GunAssembler gunAssembler;
    [SerializeField] PartType boxType;
    bool partAdded;

    private void OnTriggerEnter(Collider other)
    {
        if (boxType == PartType.Body && !partAdded && other.gameObject.GetComponent<GunBody>() != null && !gunAssembler.partList.Contains(other.gameObject.GetComponent<GunBody>()))
        {
            gunAssembler.partList.Insert(0, other.gameObject.GetComponent<GunBody>());
            partAdded = true;
        }
        else if (boxType == PartType.Mag && !partAdded && other.gameObject.GetComponent<GunMag>() != null && !gunAssembler.partList.Contains(other.gameObject.GetComponent<GunMag>()))
        {
            gunAssembler.partList.Add(other.gameObject.GetComponent<GunMag>());
            partAdded = true;
        }
        else if (boxType == PartType.Barrel && !partAdded && other.gameObject.GetComponent<GunBarrel>() != null && !gunAssembler.partList.Contains(other.gameObject.GetComponent<GunBarrel>()))
        {
            gunAssembler.partList.Add(other.gameObject.GetComponent<GunBarrel>());
            partAdded = true;
        }
    }
}
