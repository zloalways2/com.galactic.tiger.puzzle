using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class NextLevel : MonoBehaviour,IPointerClickHandler
{
    public GameObject loadingScreen;
    public void OnPointerClick(PointerEventData eventData)
    {
        loadingScreen.SetActive(true);
        if (SceneManager.GetActiveScene().buildIndex != 4)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
        }
        else
        {
            SceneManager.LoadScene(1);
        }
    }
}
