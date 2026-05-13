using UnityEngine;

public class FallingFix : MonoBehaviour
{
    public GameObject obj;
    public Vector3 startPos;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (obj != null)
        {
            startPos = obj.transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        ResetPosition();
    }

    public void ResetPosition()
    {
        if (obj != null && obj.transform.position.y < startPos.y)
        {
            obj.transform.position = new Vector3(obj.transform.position.x, startPos.y, obj.transform.position.z);
        }
    }
}
