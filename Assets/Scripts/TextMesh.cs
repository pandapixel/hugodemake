using TMPro;
using UnityEngine;

public class TextTest : MonoBehaviour
{
    public TMP_Text textComponent;

    void Update()
    {
        textComponent.ForceMeshUpdate();

        var charInfo = textComponent.textInfo.characterInfo[0];
        var verts = textComponent.textInfo.meshInfo[charInfo.materialReferenceIndex].vertices;

        var orig = verts[charInfo.vertexIndex + 0];
        verts[charInfo.vertexIndex + 0] = orig + new Vector3(0, 30, 0);

        orig = verts[charInfo.vertexIndex + 1];
        verts[charInfo.vertexIndex + 1] = orig + new Vector3(0, 30, 0);

        orig = verts[charInfo.vertexIndex + 2];
        verts[charInfo.vertexIndex + 2] = orig + new Vector3(0, 30, 0);

        orig = verts[charInfo.vertexIndex + 3];
        verts[charInfo.vertexIndex + 3] = orig + new Vector3(0, 30, 0);

        for (int i = 0; i < textComponent.textInfo.meshInfo.Length; i++)
        {
            var meshInfo = textComponent.textInfo.meshInfo[0];
            meshInfo.mesh.vertices = meshInfo.vertices;
            textComponent.UpdateGeometry(meshInfo.mesh, i);
        }
    }
}
