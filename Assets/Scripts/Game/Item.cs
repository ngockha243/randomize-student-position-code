using TMPro;
using UnityEngine;

public class Item : MonoBehaviour
{
    [SerializeField] private TMP_InputField input;
    public void Init(float width)
    {
        input.text = string.Empty;
        RectTransform rectTransform = input.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(width, rectTransform.sizeDelta.y);
    }
}
