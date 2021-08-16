using UnityEngine;
using UnityEngine.EventSystems;

public class EventTriggerExample : EventTrigger
{
    void Update()
    {
        //Debug.Log(GameObject.FindGameObjectsWithTag("Player"));
        if (GameObject.FindGameObjectsWithTag("UI") != null)
        {
            Debug.Log("None");
        }
        else if (GameObject.FindGameObjectsWithTag("UI") == null)
        {
            Debug.Log("True");
        }
    }
    public override void OnPointerDown(PointerEventData data)
    {
        Debug.Log("OnPointerDown called.");
    }
    
    public override void OnPointerUp(PointerEventData data)
    {
        Debug.Log("OnPointerUp called.");
    }
}