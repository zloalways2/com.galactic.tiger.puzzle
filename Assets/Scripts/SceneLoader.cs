using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour,IPointerClickHandler
{
    public GameObject loadingScreen;
    public int scene_index;
    public void OnPointerClick(PointerEventData eventData)
    {
        loadingScreen.SetActive(true);
        SceneManager.LoadScene(scene_index);
    }
}
