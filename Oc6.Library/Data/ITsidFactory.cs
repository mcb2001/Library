namespace Oc6.Library.Data
{
    public interface ITsidFactory
    {
        long CreateTsid();
        string ToTsidString(long tsid);
        bool TryParseTsid(string value, out long tsid);
    }
}
