using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Transform[] transforms;
    public Transform[] spawn_transforms;
    public GameObject[] pieces;
    public Transform YLimit;
    public GameObject gameExt,winExt;
    int placed_count = 0;
    public Transform usedGroup, unusedGroup;
    public Text timeTxt;
    public AudioClip winSound;
    void Start()
    {
        var positions = new List<Vector3>();
        foreach(var st in spawn_transforms){
            positions.Add(st.position);
        }
        while(positions.Count!=9){
            positions.RemoveAt(UnityEngine.Random.Range(0, positions.Count-1));
        }
        var res=new List<Vector3>();
        while (positions.Count != 0){
            int ind = UnityEngine.Random.Range(0, positions.Count-1);
            res.Add(positions[ind]);
            positions.RemoveAt(ind);
        }
        for (int i = 0; i < 9; ++i)
        {
            pieces[i].transform.position = res[i];
        }
        TimeManager.Init();
        TimeManager.Stop();
    }
    private void Update()
    {
        var time = TimeManager.Get();
        timeTxt.text = time.minutes + ":" + time.seconds;
    }

    public void PushPuzzle(GameObject puzzle)
    {
        float dist = float.PositiveInfinity;
        Transform nearest=null;
        foreach(var t in transforms)
        {
            float d = (new Vector2(t.position.x, t.position.y) - 
                new Vector2(puzzle.transform.position.x, puzzle.transform.position.y)).magnitude;
            if(d<dist)
            {
                dist = d;
                nearest = t;
            }
        }
        if (puzzle.transform.position.y > YLimit.position.y)
        {
            if (Array.IndexOf(transforms, nearest) == Array.IndexOf(pieces, puzzle))
            {
                puzzle.GetComponent<PuzzlePart>().placed=true;
                puzzle.GetComponent<PuzzlePart>().Interpolate(nearest.position);
                puzzle.transform.SetParent(usedGroup);
                placed_count++;
                if (placed_count == 9)
                {
                    usedGroup.gameObject.SetActive(false);
                    gameExt.SetActive(false);
                    winExt.SetActive(true);
                    FindObjectOfType<AudioManager>().PlaySound(winSound);
                    PlayerPrefs.SetInt("level",Mathf.Max(PlayerPrefs.GetInt("level"),SceneManager.GetActiveScene().buildIndex-1));
                }
            }
            else
            {
                puzzle.GetComponent<PuzzlePart>().Interpolate(new Vector3(
                    puzzle.transform.position.x,
                    Mathf.Min(puzzle.transform.position.y, YLimit.position.y),
                    puzzle.transform.position.z));
            }
        }
    }
}
