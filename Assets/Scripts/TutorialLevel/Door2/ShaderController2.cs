using UnityEngine;

[RequireComponent(typeof(Camera))]
public class ShaderController2 : MonoBehaviour
{
    public Material blackWhiteMaterial;
    private bool applyShader = true;

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
