using Rayo;
using Rayo.Controls;
using Rayo.Core;
using Rayo.Layout;
using Rayo.Reactivity;
using Rayo.Rendering;

namespace RayoMvvmApp;

public sealed class MainView : ViewBase<MainViewModel>
{
    public override VisualElement Build()
    {
        var counterText = new Computed<string>(() => $"Clicks: {ViewModel.Counter.Value}");

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
                            .Text("Welcome to Rayo MVVM")
                            .FontSize(30)
                            .Foreground(Color.White)
                            .TextHorizontalAlignment(HorizontalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center),
                        new Label()
                            .Text("The view is bound to a reactive view model resolved from DI.")
                            .FontSize(16)
                            .Foreground(new Color(180, 188, 204))
                            .TextHorizontalAlignment(HorizontalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center),
                        new Label()
                            .Text(counterText)
                            .FontSize(20)
                            .Foreground(new Color(110, 231, 183))
                            .TextHorizontalAlignment(HorizontalAlignment.Center)
                            .HorizontalAlignment(HorizontalAlignment.Center),
                        new Button()
                            .Text("Increment")
                            .Width(160)
                            .Height(48)
                            .OnTapped(ViewModel.IncrementCounter)
                    ));
    }
}
