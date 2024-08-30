using UnityEngine;
using UnityEngine.EventSystems;

public class SwitchUI : MonoBehaviour, IPointerClickHandler
{
    public GameObject off,on;
    public void OnPointerClick(PointerEventData eventData)
    {
        off.SetActive(false);
        on.SetActive(true);
    }
}
