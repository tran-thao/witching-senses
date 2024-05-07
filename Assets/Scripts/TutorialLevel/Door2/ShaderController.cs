using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ShaderController : MonoBehaviour
{
    public Material blackWhiteMaterial;
    private bool applyShader = false;

    void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (applyShader)
        {
            Graphics.Blit(src, dest, blackWhiteMaterial);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }

    public void ToggleShader(bool state)
    {
        applyShader = state;
    }
}
