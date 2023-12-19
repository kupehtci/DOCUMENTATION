# COMBINE MESHES - STATIC BATCHING
#CSHARP #UNITY

public void CombineMeshes(CombineInstance[] combine, bool mergeSubMeshes = true, bool useMatrices = true, bool hasLightmapData = false);
Parameters

*   `combine`	Descriptions of the Meshes to combine.
*   `mergeSubMeshes`	Defines whether Meshes should be combined into a single sub-mesh.
*   `useMatrices`	Defines whether the transforms supplied in the CombineInstance array should be used or ignored.
*   `hasLightmapData`	Defines whether to transform the input Mesh lightmap UV data using the lightmap scale offset data in CombineInstance structs.

## DESCRIPTION 

Combines several Meshes into this Mesh.

Combining Meshes is useful for performance optimization.

If mergeSubMeshes is true, all the Meshes are combined together into a single sub-mesh. Otherwise, each Mesh is placed in a different sub-mesh. If all Meshes share the same Material, this property should be set to true.

If useMatrices is true, the transform matrices in CombineInstance structs are used. Otherwise, they are ignored.

Set hasLightmapData to true to transform the input Mesh lightmap UV data using the lightmap scale offset data in CombineInstance structs. The Meshes must share the same lightmap texture.

For the combined Meshes to be in the same position as the parent Mesh occupies before the use of the method, save the parent Mesh's position and rotation then set these values to zero before you combine the Meshes. Once the combination is complete, set the parent Mesh's position and rotation back to the original values.


## CODE EXAMPLE OF COMBINING MESHES 

```csharp
using UnityEngine;
using System.Collections;

// Copy meshes from children into the parent's Mesh.
// CombineInstance stores the list of meshes.  These are combined
// and assigned to the attached Mesh.

[RequireComponent(typeof(MeshFilter))]
[RequireComponent(typeof(MeshRenderer))]
public class ExampleClass : MonoBehaviour
{
    void Start()
    {
        MeshFilter[] meshFilters = GetComponentsInChildren<MeshFilter>();
        CombineInstance[] combine = new CombineInstance[meshFilters.Length];

        int i = 0;
        while (i < meshFilters.Length)
        {
            combine[i].mesh = meshFilters[i].sharedMesh;
            combine[i].transform = meshFilters[i].transform.localToWorldMatrix;
            meshFilters[i].gameObject.SetActive(false);

            i++;
        }

        Mesh mesh = new Mesh();
        mesh.CombineMeshes(combine);
        transform.GetComponent<MeshFilter>().sharedMesh = mesh;
        transform.gameObject.SetActive(true);
    }
}
```