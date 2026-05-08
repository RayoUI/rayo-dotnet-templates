using Rayo;
using Rayo.Controls;
using Rayo.Core;
using Rayo.Layout;
using Rayo.Rendering;

namespace RayoDesktopApp;

public class MainView : UserControl
{
    private int _clickCount;

    public override VisualElement Build()
    {
        return new Frame()
            .Background(new Color(18, 24, 38))
            .Content(
                new VStack()
                    .Spacing(18)
                    .Padding(new Thickness(32))
                    .Alignment(Alignment.Center)
                    .HorizontalAlignment(HorizontalAlignment.Stretch)
                    .VerticalAlignment(VerticalAlignment.Stretch)
                    .Children(
                        new Label()
                            .Text("Welcome to Rayo")
                            .FontSize(30)
                            .Foreground(Color.White)
                            .TextHorizontalAlignment(HorizontalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center),
                        new Label()
                            .Text("Your first Rayo desktop app is running with the published NuGet packages.")
                            .FontSize(16)
                            .Foreground(new Color(180, 188, 204))
                            .TextHorizontalAlignment(HorizontalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center),
                        new Label()
                            .Text($"Clicks: {_clickCount}")
                            .FontSize(20)
                            .Foreground(new Color(110, 231, 183))
                            .TextHorizontalAlignment(HorizontalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center),
                        new Button()
                            .Text("Click me")
                            .Width(160)
                            .Height(48)
                            .OnTapped(OnButtonTapped)
                    ));
    }

    private void OnButtonTapped()
    {
        _clickCount++;
        Rebuild();
    }
}
