using OpenTabletDriver.Attributes;
using OpenTabletDriver.Output;
using OpenTabletDriver.Platform.Pointer;

namespace OpenTabletDriver.Desktop.Output
{
    [PluginName("Artist Mode"), SupportedPlatform(SystemPlatform.Linux)]
    public class LinuxArtistMode : AbsoluteOutputMode
    {
        public LinuxArtistMode(
            InputDevice tablet,
            IPressureHandler pressureHandler,
            ISettingsProvider settingsProvider
        ) : base(tablet, pressureHandler)
        {
            settingsProvider.Inject(this);
        }
    }
}
