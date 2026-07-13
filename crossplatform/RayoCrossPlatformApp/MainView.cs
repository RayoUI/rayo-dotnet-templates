using Rayo;
using Rayo.Controls;
using Rayo.Core;
using Rayo.Layout;
using Rayo.Reactivity;
using Rayo.Rendering;

namespace RayoCrossPlatformApp;

public class MainView : Component
{
    private readonly Signal<int> _counter;
    private readonly Computed<string> _counterText;

    public MainView()
    {
        _counter = UseSignal(0);
        _counterText = UseComputed(() => $"Taps: {_counter.Value}");
    }

    public override VisualElement Build()
    {
        return new Frame()
            .Background(new Color(14, 20, 33))
            .Content(
                new VStack()
                    .Spacing(18)
                    .Padding(new Thickness(28))
                    .Alignment(Alignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Stretch)
                    .VerticalAlignment(VerticalAlignment.Stretch)
                    .Children(
                        new Label()
                            .Text("Welcome to Rayo")
                            .FontSize(28)
                            .Foreground(Color.White)
                            .TextHorizontalAlignment(HorizontalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center),
                        new Label()
                            .Text("This UI is shared between the desktop and Android hosts.")
                            .FontSize(16)
                            .Foreground(new Color(180, 188, 204))
                            .TextHorizontalAlignment(HorizontalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center),
                        new Label()
                            .Text(_counterText)
                            .FontSize(20)
                            .Foreground(new Color(125, 211, 252))
                            .TextHorizontalAlignment(HorizontalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center),
                        new Button()
                            .Text("Tap me")
                            .FontSize(20)
                            .Width(160)
                            .Height(48)
                            .OnTapped(() => _counter.Value++)
                    ));
    }
}
