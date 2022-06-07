using System;
using System.Collections.Generic;
using System.Text;

namespace Translate
{
    [Android.Runtime.Register("android/media/MediaPlayer", DoNotGenerateAcw = true)]
    internal class MediaPlayer : Java.Lang.Object, Android.Media.IAudioRouting, Android.Media.IVolumeAutomation, IDisposable, Java.Interop.IJavaPeerable
    {
    }
}
