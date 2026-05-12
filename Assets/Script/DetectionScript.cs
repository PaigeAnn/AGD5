using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class DetectionScript : MonoBehaviour
{
    public Countdown countdown;
    public GameObject door;
    public GameObject enemy;
    public GameObject endPanel;

    public float raycastDistance = 10f;

    public Transform doorTrans;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        doorTrans = door.transform;
        countdown.countdownTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.transform.Rotate(0, 1, 0);
        Debug.DrawRay(transform.position, transform.forward * raycastDistance, Color.green);
    }
    
    public void openDoor()
    {
        door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z + 1);
        watch();
    }
    public void watch()
    {
        enemy.SetActive(true);

        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, raycastDistance))
        {
            if (hit.collider.CompareTag("Player"))
            {
                endPanel.SetActive(true);
            }
        }
        StartCoroutine(wait());
    }

    IEnumerator wait()
    {
        yield return new WaitForSeconds(4f);
        enemy.SetActive(false);
        door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z - 1);
        countdown.active = false;
        countdown.gameObject.SetActive(false);
        countdown.countdownTime = 5;
    }
}
