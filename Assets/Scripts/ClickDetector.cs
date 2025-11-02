using UnityEngine;
using UnityEngine.Events;

public class ClickDetector : MonoBehaviour
{
    public UnityEvent clickEvent;

    private void OnMouseDown()
    {
        clickEvent.Invoke();
    }
}
