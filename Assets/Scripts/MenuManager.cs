using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public Image[] buttons;
    void Start()
    {
        if (!PlayerPrefs.HasKey("level"))
            PlayerPrefs.SetInt("level", 0);
        int passed = PlayerPrefs.GetInt("level");
        for(int i = passed+1; i < buttons.Length; ++i)
        {
            buttons[i].transform.GetChild(0).GetComponent<Image>().color = Color.gray;
            Destroy(buttons[i].GetComponent<SceneLoader>());
        }
    }
}
