using UnityEngine;

public class AddressableTest : MonoBehaviour
{


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            EventCenter.Instance.EventTrigger(E_EventType.E_ArrowAppear,2);
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            EventCenter.Instance.EventTrigger(E_EventType.E_ArrowHide);
        }

    }

   
}
