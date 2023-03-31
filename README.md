# MediaCustomTransport

This repository serves as a test bed and bug demonstration location for MediaElement in Xamarin.Forms when implementing custom controls for MediaElement in Xamarin.Forms.

# Current Issues

## `CurrentState` is not correctly updated on Android ([Issue #408](https://github.com/xamarin/XamarinCommunityToolkit/issues/408))
This becomes especially clear when seeking using the slider (c.f. below)


## Seeking does not work properly on Android ([Issue #1458](https://github.com/xamarin/XamarinCommunityToolkit/issues/1458), [Issue #885](https://github.com/xamarin/XamarinCommunityToolkit/issues/885))
- Binding a Slider to the `Position` property generally works, but the seeking leads to staggering or jumping of the Slider thumb
- Seeking, independent of binding the `Position` to a Slider or manually setting the `Position` in the code-behind leads to the following effects:
  - The `CurrentState` is not updated
  - The `Position` value is also not getting updated anymore (`PropertyChanged` event doesn't get raised)
  - Thus, when the `CurrentState` changes to `Paused` the video is still playing
  - When seeking to a specific position which hasn't been loaded yet, the `Position` jumps to the closest already buffered data point in the timeline, which shouldn't happend - instead, the video should stop playing until enough data has been loaded and then continue playing from the desired playback time
- Only after calling `Play()` (e.g. via the "Play" button) the `Position` and `CurrentState` get properly updated again
- Setting the `Position` in the code-behind potentially breaks existing bindings, which might be an explanation as to why this happens
- This doesn't explain why these problems also occur when seeking via the bound Slider


## Rotating the device into *Landscape* or *Portrait* does not automatically update the MediaElement's size on Android ([Issue #401](https://github.com/xamarin/XamarinCommunityToolkit/issues/401))
The view only updates when interacting with the video, e.g. by pausing and then playing the video again


## `AutoPlay="False"` not respected on Android ([Issue #1715](https://github.com/xamarin/XamarinCommunityToolkit/issues/1715)):
- Videos always start automatically on Android
- A Workaround exists, but is very hacky (setting `Speed="0F"`)

  
**Note:** None of these problems currently exist in the .NET MAUI version, as can be observed in the [sibling repository](https://github.com/ewerspej/MediaCustomTransportMaui).
