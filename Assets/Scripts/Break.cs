using UnityEngine;
using UnityEngine.Events;

public class Break : MonoBehaviour
{
    public UnityEvent clickEvent;

    private void OnMouseDown()
    {
        clickEvent.Invoke();
    }
}
