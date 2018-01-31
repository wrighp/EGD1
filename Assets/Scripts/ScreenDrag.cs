using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof(EventTrigger))]
public class ScreenDrag : MonoBehaviour {

	public Transform moveTarget;
	public Vector3 scrollSpeed = Vector3.up; //Negative for moving other direction

	void Start()
	{
		if(moveTarget == null){
			moveTarget = Camera.main.transform;
		}

		EventTrigger trigger = GetComponent<EventTrigger>();
	
		EventTrigger.Entry dragEntry = new EventTrigger.Entry();
		dragEntry.eventID = EventTriggerType.Drag;
		dragEntry.callback.AddListener((data) => OnDragDelegate ((PointerEventData)data));
		trigger.triggers.Add(dragEntry);
	}
		
	public void OnDragDelegate (PointerEventData data)
	{
		//Debug.Log("OnDragDelegate called. ");
		moveTarget.position += Vector3.Scale(scrollSpeed,(Vector3)data.delta * Time.deltaTime);
	}

}
