using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Rx;

namespace NS.View {
	public class PlayerView : Sparrow.View {
		Model.PlayerModel playerModel = Model.PlayerModel.instance;
		Observer<Vector2> observer;
		public void Start(){			
			observer = playerModel.position.subscribe((position)=>{
				transform.localPosition = new Vector3( position.x, position.y, 0 );
			});
		}

		public void OnDestroy(){
			observer.unsubscribe();
		}
	}
}