using BLL.Interfaces;
using BLL.Implementation;

namespace BLL;

public static class BLLExtension
{

    public static ILibrairiService GetLibrariService()
    {
        return new LibrairiService();
    }
}
