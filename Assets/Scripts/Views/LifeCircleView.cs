using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using Sparrow.Rx;

namespace NS.View {
	public class LifeCircleView : Sparrow.View {
		Model.PlayerModel playerModel = Model.PlayerModel.instance;

		const float blankSpeed = 0.02f;
		public Color[] signalColor;
		public Image circleImage;
		float theta = 0.0f;
		int life = 0;

		Observer<int> lifeObserver;

		public void Start(){
			lifeObserver = playerModel.life.subscribe( life => this.life = life );
		}

		public void Update () {
			theta += blankSpeed;

			var colorPoint = Color.Lerp( signalColor[1], signalColor[0], life/100f );
			var curvePoint = Mathf.Abs( Mathf.Sin(theta) );
			circleImage.color = Color.Lerp( colorPoint, Color.white, curvePoint );
		}

		public void OnDestroy(){
			lifeObserver.unsubscribe();
		}
	}
}