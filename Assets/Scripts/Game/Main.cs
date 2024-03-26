using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Main : MonoBehaviour
{
    [SerializeField] private TMP_InputField column;
    [SerializeField] private TMP_InputField row;
    [SerializeField] private TMP_InputField student;
    [SerializeField] private GridLayoutGroup gridLayoutGroup;
    [SerializeField] private GameObject item;
    private Transform parent;
    private void Start()
    {
        parent = gridLayoutGroup.transform;
    }
    public void Generate()
    {
        int c = 0;
        int r = 0;
        int stud = 0;
        try
        {
            c = Int32.Parse(column.text);
            r = Int32.Parse(row.text);
            stud = Int32.Parse(student.text);
        }
        catch
        {
            c = 4;
            r = 4;
            stud = 16;
        }
        gridLayoutGroup.constraint = GridLayoutGroup.Constraint.FixedColumnCount;
        gridLayoutGroup.constraintCount = c;

        for (int i = 0; i < parent.childCount; i++)
        {
            Transform child = parent.GetChild(i);

            SimplePool.Despawn(child.gameObject);
        }
        float cellWidth = (Screen.width - (10 * 2 + (c - 1) * 20)) / c;
        gridLayoutGroup.cellSize = new Vector2(cellWidth, gridLayoutGroup.cellSize.y);

        for (int i = 0; i < stud; i++)
        {
            GameObject go = SimplePool.Spawn(item, Vector2.zero, Quaternion.identity);
            go.GetComponent<Item>().Init(cellWidth - 35);
            Transform tf = go.transform;
            tf.SetParent(parent);
            tf.localScale = Vector3.one;
        }
    }
    public void Random()
    {
        int childCount = parent.childCount;
        for (int i = 0; i < childCount - 1; i++)
        {
            int randomIndex = UnityEngine.Random.Range(i, childCount);
            if (randomIndex != i)
            {
                // Swap child positions
                Transform temp = parent.GetChild(i);
                parent.SetSiblingIndex(randomIndex);
                temp.SetSiblingIndex(randomIndex);
            }
        }
    }
}
