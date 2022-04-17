using OpenTabletDriver.Configurations.Parsers.UCLogic;
using OpenTabletDriver.Plugin.Tablet;

namespace OpenTabletDriver.Configurations.Parsers.Huion.New1060Plus
{
    public class New1060PlusReportParser : IReportParser<IDeviceReport>
    {
        public IDeviceReport Parse(byte[] data)
        {
            if (data[1].IsBitSet(6))
                return new UCLogicAuxReport(data);
            else if (data[1].IsBitSet(1) || data[1].IsBitSet(2))
                return new New1060PlusTabletReport(data);
            else
                return new TabletReport(data);
        }
    }
}
