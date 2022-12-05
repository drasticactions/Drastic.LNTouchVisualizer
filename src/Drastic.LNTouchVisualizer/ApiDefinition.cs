using System;
using CoreGraphics;
using Foundation;
using ObjCRuntime;
using UIKit;

namespace Drastic.LNTouchVisualizer
{

    // @interface LNTouchConfig : NSObject
    [BaseType(typeof(NSObject))]
    interface LNTouchConfig
    {
        // @property (nonatomic) CGFloat alpha;
        [Export("alpha")]
        nfloat Alpha { get; set; }

        // @property (nonatomic) NSTimeInterval fadeDuration;
        [Export("fadeDuration")]
        double FadeDuration { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable strokeColor;
        [NullAllowed, Export("strokeColor", ArgumentSemantic.Strong)]
        UIColor StrokeColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nullable fillColor;
        [NullAllowed, Export("fillColor", ArgumentSemantic.Strong)]
        UIColor FillColor { get; set; }

        // @property (readonly, nonatomic, strong, class) LNTouchConfig * _Nonnull rippleConfig;
        [Static]
        [Export("rippleConfig", ArgumentSemantic.Strong)]
        LNTouchConfig RippleConfig { get; }

        // @property (readonly, nonatomic, strong, class) LNTouchConfig * _Nonnull touchConfig;
        [Static]
        [Export("touchConfig", ArgumentSemantic.Strong)]
        LNTouchConfig TouchConfig { get; }
    }

    // @interface LNTouchVisualizerWindow : UIWindow
    [BaseType(typeof(UIWindow))]
    interface LNTouchVisualizerWindow
    {
        // @property (getter = isTouchVisualizationEnabled, nonatomic) BOOL touchVisualizationEnabled;
        [Export("touchVisualizationEnabled")]
        bool TouchVisualizationEnabled { [Bind("isTouchVisualizationEnabled")] get; set; }

        // @property (getter = isMorphEnabled, nonatomic) BOOL morphEnabled;
        [Export("morphEnabled")]
        bool MorphEnabled { [Bind("isMorphEnabled")] get; set; }

        // @property (nonatomic, strong) LNTouchConfig * _Nonnull touchContactConfig;
        [Export("touchContactConfig", ArgumentSemantic.Strong)]
        LNTouchConfig TouchContactConfig { get; set; }

        // @property (nonatomic, strong) LNTouchConfig * _Nonnull touchRippleConfig;
        [Export("touchRippleConfig", ArgumentSemantic.Strong)]
        LNTouchConfig TouchRippleConfig { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame touchVisualizationEnabled:(BOOL)touchVisualizationEnabled morphEnabled:(BOOL)morphEnabled contactConfig:(LNTouchConfig * _Nullable)contactConfig rippleConfig:(LNTouchConfig * _Nullable)rippleConfig __attribute__((objc_designated_initializer));
        [Export("initWithFrame:touchVisualizationEnabled:morphEnabled:contactConfig:rippleConfig:")]
        [DesignatedInitializer]
        NativeHandle Constructor(CGRect frame, bool touchVisualizationEnabled, bool morphEnabled, [NullAllowed] LNTouchConfig contactConfig, [NullAllowed] LNTouchConfig rippleConfig);
    }

#if IOS
    // @interface TouchVisualizer (UIWindowScene)
    [Category]
    [BaseType(typeof(UIWindowScene))]
    interface UIWindowScene_TouchVisualizer
    {
        // @property (nonatomic) BOOL touchVisualizerEnabled;
        [Export("touchVisualizerEnabled")]
        bool TouchVisualizerEnabled { get; set; }

        // @property (readonly, nonatomic, strong) LNTouchVisualizerWindow * _Nonnull touchVisualizerWindow;
        [Export("touchVisualizerWindow", ArgumentSemantic.Strong)]
        LNTouchVisualizerWindow TouchVisualizerWindow { get; }
    }
#endif

}
