using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

public class ColliderZone : Editor {

    public BoxCollider collider;
    public Color color;
    public bool isVisible;

    public static Mesh capsuleMesh;
    public static Mesh cubeMesh;
    public static Mesh sphereMesh;

    public void Init(BoxCollider _collider, Color _color, bool _isVisible = true)
    {
        collider = _collider;
        color = _color;
        isVisible = _isVisible;
    }

    public void Draw()
    {
        if (collider == null)
            DestroyImmediate(this);

        Vector3 center = ColliderCenterAsWorldPostion();
        Gizmos.color = color;
        Gizmos.DrawWireCube(center, collider.size);
        Handles.Label(collider.gameObject.transform.position, collider.gameObject.name);
        // if capsule
        // Gizmos.DrawMesh(mesh);
    }

    private Vector3 ColliderCenterAsWorldPostion()
    {
        return collider.gameObject.transform.position + collider.center;
    }

    private void OnAwake()
    {
        if (capsuleMesh == null)
        {
            GameObject go = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            capsuleMesh = go.GetComponent<MeshFilter>().sharedMesh;
            Destroy(go);
        }
    }
}
