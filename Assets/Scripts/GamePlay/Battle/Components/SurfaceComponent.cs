using UnityEngine;

[RequireComponent(typeof(MeshFilter), typeof(MeshRenderer), typeof(MeshCollider))]
public class SurfaceComponent : MonoBehaviour
{

    private Mesh mesh;
    [SerializeField] private GameObject originPosition;

    private float zOffset = 4;

    private void Start()
    {
        
    }

    public void SetSize(int width, int height, float cellSize)
    {
        gameObject.SetActive(true);
        if (mesh == null)
        {
            mesh = new Mesh();
        }

        float realWidth = width * cellSize;
        float realHeight = height * cellSize;
        var origPos = originPosition.transform.position;
        var z = origPos.z - zOffset;
        var topLeft = new Vector2(origPos.x - realWidth / 2, origPos.y + realHeight / 2);
        var bottomRight = new Vector2(origPos.x + realWidth / 2, origPos.y - realHeight / 2);

        Vector3[] vertices = new Vector3[4]
        {
            new Vector3(topLeft.x, topLeft.y, z),
            new Vector3(bottomRight.x, topLeft.y, z),
            new Vector3(topLeft.x, bottomRight.y, z),
            new Vector3(bottomRight.x, bottomRight.y, z)
        };

        mesh.vertices = vertices;

        int[] tris = new int[6]
        {
            0, 1, 2,
            2, 1, 3
        };
        mesh.triangles = tris;

        Vector3[] normals = new Vector3[4]
        {
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward,
            -Vector3.forward
        };
        mesh.normals = normals;

        Vector2[] uv = new Vector2[4]
        {
            new Vector2(0, 0),
            new Vector2(1, 0),
            new Vector2(0, 1),
            new Vector2(1, 1)
        };
        mesh.uv = uv;

        GetComponent<MeshFilter>().mesh = mesh;
        GetComponent<MeshCollider>().sharedMesh = mesh;
    }
}
