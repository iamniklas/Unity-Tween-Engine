# Unity-Tween-Engine

The Unity Tween Engine is a plug-in for the Unity Engine that provides interpolated transitions.

Available interpolations are:
- **Linear**
- **Sine**
- **Quad**
- **Cubic**
- **Quart**
- **Quint**
- **Expo**
- **Circ**
- **Back**
- **Elastic**
- **Bounce**
- **Custom** (Custom interpolation with user-set bezier curve)

All interpolations except Linear and Custom provide the 3 common types (In, Out, InOut).

To create a new *Tween Operation* the following code is required:

```
TweenOperation operation = new TweenOperation();
operation.SetDuration(1.0f);
operation.SetInterpolation(SimpleTweenEngine.InterpolationType.EaseInOutSine);
```

The following methods are used for tween **callbacks**:
```
operation.RegisterTweenStartCallback(Action callback);
operation.RegisterTweenUpdateCallback(Action <float> callback);
operation.RegisterTweenCompleteCallback(Action callback);
```

To start a TweenOperation, it must be attached to the TweenCore:
```
TweenCore.AddNewOperation(operation);
```
