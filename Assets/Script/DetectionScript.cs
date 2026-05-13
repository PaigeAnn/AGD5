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

    public Transform[] waypoint  = new Transform[2];


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        countdown.countdownTime = 5;
    }

    // Update is called once per frame
    void Update()
    {
        enemy.transform.Rotate(0, 1, 0);
    }
    
    public void openDoor()
    {
        door.transform.position = new Vector3(door.transform.position.x, door.transform.position.y, door.transform.position.z + 1);
        StartCoroutine(Detect());
    }


    IEnumerator Detect()
    {
        while (Vector3.Distance(enemy.transform.position, waypoint[1].position) > 0.1f)
        {
            enemy.transform.position = Vector3.MoveTowards(
                enemy.transform.position,
                waypoint[1].position,
                2f * Time.deltaTime
            );

            yield return null;
        }

        yield return new WaitForSeconds(4f);

        while (Vector3.Distance(enemy.transform.position, waypoint[0].position) > 0.1f)
        {
            enemy.transform.position = Vector3.MoveTowards(
                enemy.transform.position,
                waypoint[0].position,
                2f * Time.deltaTime
            );

            yield return null;
        }

        door.transform.position = new Vector3(
            door.transform.position.x,
            door.transform.position.y,
            door.transform.position.z - 1
        );

        countdown.active = false;
        countdown.gameObject.SetActive(false);
        countdown.countdownTime = 5;
    }
}
