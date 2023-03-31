# MediaCustomTransport

This repository serves as a test bed and bug demonstration location for MediaElement in Xamarin.Forms when implementing custom controls for MediaElement in Xamarin.Forms.

## Current Issues

- `CurrentState` is not correctly updated on Android
  - This becomes especially clear when seeking using the slider
- `AutoPlay="False"` not respected on Android
  - Videos always start automatically on Android
  - A Workaround exists, but is very hacky
- Seeking does not work properly on Android
  - Binding a Slider to the `Position` property generally works, but the seeking leads to staggering or jumping of the Slider thumb
  - Seeking, independent of binding the `Position` to a Slider or manually setting the `Position` in the code-behind leads to the following effects:
    - The `CurrentState` is not updated
    - The `Position` value is also not getting updated anymore (`PropertyChanged` event doesn't get raised)
    - Thus, when the `CurrentState` changes to `Paused` the video is still playing
    - Only after calling `Play()` (e.g. via the "Play" button) the `Position` and `CurrentState` get updated again, so that the Slider moves again
    - Setting the `Position` in the code-behind potentially breaks existing bindings, which might be an explanation as to why this happens
    - This doesn't explain why these problems also occur when seeking via the bound Slider

**Note:** None of these problems currently exist in the .NET MAUI version, as can be observed in the [sibling repository](https://github.com/ewerspej/MediaCustomTransportMaui).
