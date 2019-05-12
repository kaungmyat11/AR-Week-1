using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;

public class TargetScript : MonoBehaviour, ITrackableEventHandler
{

    private TrackableBehaviour trackableBehaviour;

    public GameObject ARObject;
    public GameObject ArObjPos;

    public void OnTrackableStateChanged(TrackableBehaviour.Status previousStatus, TrackableBehaviour.Status newStatus)
    {
        if(newStatus == TrackableBehaviour.Status.DETECTED || 
            newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED 
            || newStatus == TrackableBehaviour.Status.TRACKED)
        {
            //foundTarget
            Debug.Log("Founded");
            ARObject.SetActive(true);
            ARObject.transform.localPosition = new Vector3(0, 0, 0);  //cannot use transform.position because it is child object and use localPosition for the child
        }
        else
        {
            //lostTarget
            Debug.Log("Lost Target");
            gameObject.transform.rotation = Quaternion.identity;   //do not use vector3 in the 3d rotation is really bad so unity has a library Quaternion.identity = 0,0,0
            ARObject.transform.position = ArObjPos.transform.position;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        trackableBehaviour = GetComponent<TrackableBehaviour>();

        //To Prevent Error
        if(trackableBehaviour != null)
        {
            trackableBehaviour.RegisterTrackableEventHandler(this);
        }

        //Disable the object
        ARObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
