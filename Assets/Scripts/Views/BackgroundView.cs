using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace NS.View {
	public class BackgroundView : Sparrow.View {
		public RawImage texture;
		
		// Update is called once per frame
		void Update () {
			var rect = texture.uvRect;
			rect.y += 0.002f;
			texture.uvRect = rect;
		}
	}
}