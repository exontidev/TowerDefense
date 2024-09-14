using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeGenerator : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField] private int nodeRow = 4;
    [SerializeField] private int nodeCollumn = 4;

    [SerializeField] private float offset = 0.5f;

    [SerializeField]
    private GameObject nodePrefab;

    [ContextMenu("Create Nodes")]
    private void CreateNodes()
    {
        Clear();
        for (int x = 0; x < nodeRow; x++)
        {
            for (int z = 0; z < nodeCollumn; z++)
            {
                Instantiate(nodePrefab, new Vector3(x * offset, 0, z * offset), Quaternion.identity, transform);
            }
        }
    }

    private void Clear()
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
    }
}
