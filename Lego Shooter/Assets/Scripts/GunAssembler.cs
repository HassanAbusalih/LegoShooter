using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunAssembler : MonoBehaviour
{
    [SerializeField] GameObject assemblyPoint;
    public List<GunPart> partList;

    // Update is called once per frame
    void Update()
    {
        if (partList.Count == 3)
        {
            CreateGun(partList);
            partList.Clear();
        }
    }


    public void CreateGun(List<GunPart> gunParts)
    {
        GameObject completeGun = new GameObject("Player Gun");
        completeGun.transform.position = assemblyPoint.transform.position;
        completeGun.AddComponent<Gun>();
        completeGun.AddComponent<Rigidbody>();
        completeGun.AddComponent<BoxCollider>();
        completeGun.tag = "Finish";
        GunBody gunBody = (GunBody)gunParts[0];
        //completeGun.GetComponent<BoxCollider>().center = gunBody.gameObject.GetComponent<BoxCollider>().center;
        completeGun.GetComponent<BoxCollider>().size = gunBody.gameObject.GetComponent<BoxCollider>().size * gunBody.gameObject.transform.localScale.magnitude;
        for (int i = 0; i < gunParts.Count; i++)
        {
            if (gunParts[i].partType == PartType.Body)
            {
                completeGun.GetComponent<Gun>().body = (GunBody)gunParts[i];
                gunParts[i].gameObject.GetComponent<BoxCollider>().enabled = false;
                gunParts[i].gameObject.transform.position = assemblyPoint.transform.position;
                gunParts[i].transform.SetParent(completeGun.transform);
                gunParts[i].transform.localPosition = Vector3.zero;
            }
            else if (gunParts[i].partType == PartType.Mag)
            {
                completeGun.GetComponent<Gun>().mag = (GunMag)gunParts[i];
                gunParts[i].gameObject.GetComponent<BoxCollider>().enabled = false;
                gunParts[i].transform.position = gunBody.magAttachPoint.transform.position;
                gunParts[i].transform.SetParent(completeGun.transform);
            }
            else if (gunParts[i].partType == PartType.Barrel)
            {
                completeGun.GetComponent<Gun>().barrel = (GunBarrel)gunParts[i];
                gunParts[i].gameObject.GetComponent<BoxCollider>().enabled = false;
                gunParts[i].transform.position = gunBody.barrelAttachPoint.transform.position;
                gunParts[i].transform.SetParent(completeGun.transform);
            }
            gunParts[i].gameObject.GetComponent<Rigidbody>().isKinematic = true;
            gunParts[i].tag = "Untagged";
        }
    }
}
