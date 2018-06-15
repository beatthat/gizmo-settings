using BeatThat.ColorExtensions;
using BeatThat.Rects;
using UnityEngine;

namespace BeatThat.GizmoSetting
{

    /// <summary>
    /// Component makes it easy to enable/disable gizmos and associated colors on a per-object basis
    /// </summary>
    public class GizmoSettings : MonoBehaviour
	{

		public enum DrawGizmosDirective { Disable = 0, WhenSelected = 1, Always = 2 }
		public DrawGizmosDirective m_drawGizmos = DrawGizmosDirective.WhenSelected;
		public Color m_gizmoLineColor = Color.cyan;
		public Color m_gizmoFillColor = Color.cyan.WithAlpha(0.1f);

		void OnValidate()
		{
			this.gameObject.hideFlags = HideFlags.None;
		}

		#if UNITY_EDITOR
		void OnDrawGizmosSelected()
		{
			if (m_drawGizmos == DrawGizmosDirective.WhenSelected) {
				DoDrawGizmos ();
			}
		}

		void OnDrawGizmos()
		{
			if (m_drawGizmos == DrawGizmosDirective.Always) {
				DoDrawGizmos ();
			}
		}

		private void DoDrawGizmos()
		{
			var rt = this.transform as RectTransform;
			if (rt == null) {
				return;
			}

			Rect r = rt.rect;

			rt.DrawGizmoScreenRect(m_gizmoLineColor);
			rt.DrawGizmoFillScreenRect(m_gizmoFillColor);
		}
		#endif
	}
}

