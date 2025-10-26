using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class FullScreenCRT : ScriptableRendererFeature
{
    class FullScreenCRTRenderPass : ScriptableRenderPass
    {
      private Material m_FullScreenCRT;

      public FullScreenCRTRenderPass(Material fullscreenCRTShader)
      {
            renderPassEvent = RenderPassEvent.BeforeRenderingPostProcessing;
          m_FullScreenCRT = fullscreenCRTShader;
      }
        public override void OnCameraSetup(CommandBuffer cmd, ref RenderingData renderingData)
        {
            
        }

        public override void Execute(ScriptableRenderContext context, ref RenderingData renderingData)
        {
        }

        public override void OnCameraCleanup(CommandBuffer cmd)
        {
        }
    }
    [SerializeField] private Material m_FullScreenCRT;
    FullScreenCRTRenderPass m_ScriptablePass;

    private bool MaterialVaild => m_FullScreenCRT&&m_FullScreenCRT.shader;
    /// <inheritdoc/>
    public override void Create()
    {
        if (!MaterialVaild)
            return;
        m_ScriptablePass = new FullScreenCRTRenderPass(m_FullScreenCRT);

        m_ScriptablePass.renderPassEvent = RenderPassEvent.AfterRenderingOpaques;
    }

    public override void AddRenderPasses(ScriptableRenderer renderer, ref RenderingData renderingData)
    {
        if (!MaterialVaild)
            return;
        renderer.EnqueuePass(m_ScriptablePass);
    }
}


