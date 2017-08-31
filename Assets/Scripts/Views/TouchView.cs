using UnityEngine;
using UnityEngine.EventSystems;

namespace NS.View {
	public class TouchView: Sparrow.View, IPointerDownHandler, IPointerUpHandler, IDragHandler {
		Model.PlayerModel playerModel = Model.PlayerModel.instance;

		public void OnPointerDown(PointerEventData eventData){
			playerModel.setEmitStatus( true );
		}

		public void OnPointerUp(PointerEventData eventData){
			playerModel.setEmitStatus( false );
		}

		public void OnDrag(PointerEventData eventData){
			playerModel.move( eventData.delta );
		}
	}
}