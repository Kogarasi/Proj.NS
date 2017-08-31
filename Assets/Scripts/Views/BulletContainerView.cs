using System.Collections.Generic;
using UnityEngine;

using Sparrow.Rx;

namespace NS.View {
	public class BulletContainerView : Sparrow.View {
		Model.BulletModel bulletModel = Model.BulletModel.instance;
		public static BulletContainerView instance;
		List<BulletView> children = new List<BulletView>();
		
		Observer<BulletView> observer;

		void Awake(){
			instance = this;
		}

		void Start(){
			observer = bulletModel.bulletViewSource.subscribe(view => addChild( view ) );
		}

		void OnDestroy(){
			observer.unsubscribe();
			instance = null;
		}

		public void addChild( BulletView child ){
			child.transform.SetParent( transform, false );
			children.Add( child );
		}
	}
}