using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PuzzlePart : MonoBehaviour, IDragHandler, IBeginDragHandler, IEndDragHandler
{
    Canvas canvas;
    RectTransform rectTransform;
    GameManager game;
    public bool placed = false;

    Vector3 startPoint,destPoint;
    bool interpolated=false;
    float interp_time;
    private void Start()
    {
        rectTransform = GetComponent<RectTransform>();
        game = FindObjectOfType<GameManager>();
        canvas = FindObjectOfType<Canvas>();
    }
    public void OnBeginDrag(PointerEventData eventData)
    {
        if (placed)
            return;
        //start_pos = new Vector2(transform.position.x,transform.position.y);
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (placed)
            return;
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        if (placed)
            return;
        game.PushPuzzle(gameObject);
    }

    private void Update()
    {
        if (!interpolated)
            return;
        interp_time += Time.deltaTime*20;
        if (interp_time > 1.0f)
        {
            interp_time = 1.0f;
            interpolated = false;
        }
        transform.position = Vector3.Lerp(startPoint, destPoint, interp_time);
    }
    public void Interpolate(Vector3 dest)
    {
        startPoint = transform.position;
        destPoint = dest;
        interp_time = 0.0f;
        interpolated = true;
    }
}
