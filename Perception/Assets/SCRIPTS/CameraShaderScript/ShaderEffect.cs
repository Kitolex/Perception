using UnityEngine;

[ExecuteInEditMode]
public class ShaderEffect : MonoBehaviour {

  public Material GrayScaleAndColorCanal;

  void OnRenderImage (RenderTexture source, RenderTexture destination) {
    Graphics.Blit(source, destination, GrayScaleAndColorCanal);
  }
}