using System;
using UnityEngine;

[Serializable]
public class HandObjectFalls : MonoBehaviour
{
    public GameObject Granny;
    public Transform spawnObject;
    public GameObject ParentObject;
    public AudioClip ObjectLjud;
    public Transform objectResetPos;

    public virtual void Start()
    {
        Granny = GameObject.Find("GrannyParent");
        objectResetPos = GameObject.Find("ObjectResetPoint").transform;
        Debug.Log("Granny found: " + (Granny != null));
        Debug.Log("Object Reset Position found: " + (objectResetPos != null));
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Triggered by: " + other.gameObject.name + " with tag: " + other.gameObject.tag);

        if (other.gameObject.CompareTag("golv"))
        {
            var grannyAI = Granny.GetComponent<EnemyAIGranny>();
            grannyAI.grannyHearObject = true;
            grannyAI.startTimerSearch = false;
            grannyAI.GrannySearching = false;
            grannyAI.resetSafeTimer = false;
            grannyAI.timerSearch = 0f;

            Debug.Log("Granny AI updated for hearing object.");

            if (GameObject.Find("TempNavObjects(Clone)") != null)
            {
                GameObject.Find("TempNavObjects(Clone)").name = "TempNavObjects(Clone)Old";
                Instantiate(spawnObject, transform.position, transform.rotation);
                GetComponent<AudioSource>().PlayOneShot(ObjectLjud);
                Debug.Log("Spawned new object and played sound.");
                Destroy(GameObject.Find("TempNavObjects(Clone)Old"), 0.5f);
            }
            else if (GameObject.Find("TempNavObjects(Clone)Old") != null)
            {
                Destroy(GameObject.Find("TempNavObjects(Clone)Old"));
                Debug.Log("Destroyed old TempNavObjects.");
            }
            else
            {
                Instantiate(spawnObject, transform.position, transform.rotation);
                GetComponent<AudioSource>().PlayOneShot(ObjectLjud);
                Debug.Log("Spawned object as no TempNavObjects found.");
            }
        }
        else if (other.gameObject.CompareTag("Player"))
        {
            Physics.IgnoreCollision(ParentObject.GetComponent<Collider>(), other.GetComponent<CharacterController>(), true);
            Debug.Log("Ignored collision with Player.");
        }
        else if (other.gameObject.CompareTag("resetfloor"))
        {
            ParentObject.transform.position = objectResetPos.position;
            Debug.Log("Reset ParentObject position to: " + objectResetPos.position);
        }
    }
}
