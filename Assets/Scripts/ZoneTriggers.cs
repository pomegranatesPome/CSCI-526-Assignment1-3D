using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoneTriggers : MonoBehaviour
{
    public delegate void ObjectEnteredTrigger(GameObject enteredObject);
    //Delegate: encapsulates a method and allows it to be passed like a variable


    public static event ObjectEnteredTrigger OnObjEnteredLava;
    public static event ObjectEnteredTrigger OnObjEnteredWin;

    public enum ZoneType { WinZone, LavaZone }
    public ZoneType zoneType;

    private void OnTriggerEnter(Collider other)
    {
        switch(zoneType)
        {
            case ZoneType.WinZone:
                OnObjEnteredWin?.Invoke(other.gameObject); // ?. checks first if OnObjEnteredWin is null
                break;
            case ZoneType.LavaZone:
                OnObjEnteredLava?.Invoke(other.gameObject);
                break;
        }
    }
}
