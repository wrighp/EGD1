using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

[RequireComponent (typeof(EventTrigger))]
public class ScreenTapDrag : MonoBehaviour {

	public Transform moveTarget;
	public Vector3 scrollSpeed = Vector3.up; //Negative for moving other direction

	int down = 0;

	void Start()
	{
		if(moveTarget == null){
			moveTarget = Camera.main.transform;
		}

		EventTrigger trigger = GetComponent<EventTrigger>();


		EventTrigger.Entry downEntry = new EventTrigger.Entry();
		downEntry.eventID = EventTriggerType.PointerDown;
		downEntry.callback.AddListener((data) => OnPointerDownDelegate ((PointerEventData)data));
		trigger.triggers.Add(downEntry);

		EventTrigger.Entry upEntry = new EventTrigger.Entry();
		upEntry.eventID = EventTriggerType.PointerUp;
		upEntry.callback.AddListener((data) => OnPointerUpDelegate ((PointerEventData)data));
		trigger.triggers.Add(upEntry);

		EventTrigger.Entry clickEntry = new EventTrigger.Entry();
		clickEntry.eventID = EventTriggerType.PointerClick;
		clickEntry.callback.AddListener((data) => OnPointerClickDelegate ((PointerEventData)data));
		trigger.triggers.Add(clickEntry);

		EventTrigger.Entry enterEntry = new EventTrigger.Entry();
		enterEntry.eventID = EventTriggerType.PointerEnter;
		enterEntry.callback.AddListener((data) => OnPointerEnterDelegate ((PointerEventData)data));
		trigger.triggers.Add(enterEntry);

		EventTrigger.Entry exitEntry = new EventTrigger.Entry();
		exitEntry.eventID = EventTriggerType.PointerExit;
		exitEntry.callback.AddListener((data) => OnPointerExitDelegate ((PointerEventData)data));
		trigger.triggers.Add(exitEntry);

	}

	void Update(){
		if(down > 0){
			moveTarget.transform.position += Time.deltaTime * scrollSpeed;
		}
	}


	public void OnPointerDownDelegate(PointerEventData data)
	{
		//Debug.Log("OnPointerDownDelegate called.");
		down++;
	}

	public void OnPointerUpDelegate(PointerEventData data)
	{
		//Debug.Log("OnPointerUpDelegate called.");
		down = 0;
	}

	public void OnPointerClickDelegate(PointerEventData data)
	{
		Debug.Log("OnPointerClickDelegate called.");
		down = 0;
	}

	public void OnPointerEnterDelegate(PointerEventData data)
	{
		//Debug.Log("OnPointerEnterDelegate called.");
		if(data.eligibleForClick){
			down++;
		}
	}

	public void OnPointerExitDelegate(PointerEventData data)
	{
		//Debug.Log("OnPointerExitDelegate called.");
		down = 0;
	}

}
