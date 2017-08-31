using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Sparrow.Binding;

namespace NS.Scene {

  [ManageModel( typeof(Model.PlayerModel) )]
  [ManageModel( typeof(Model.BulletModel) )]
  public class MainScene : Sparrow.Scene<MainScene> {

    [InjectView("Player")]
    public View.PlayerView playerView;

    [InjectView("Touch")]
    public View.TouchView touchView;

    [InjectView("Bullet Container")]
    public View.BulletContainerView bulletContainerView;
  }
}