using UnityEngine;
using UnityEngine.EventSystems;

public enum TimerAction
{
    Stop,
    Continue
}
public class SwitchUIWithTimer : MonoBehaviour,IPointerClickHandler
{
    public GameObject off,on;
    public TimerAction action;
    public void OnPointerClick(PointerEventData eventData)
    {
        if (action==TimerAction.Stop)
        {
            TimeManager.Stop();
        }
        else
        {
            TimeManager.Continue();
        }
        off.SetActive(false);
        on.SetActive(true);
    }
}
