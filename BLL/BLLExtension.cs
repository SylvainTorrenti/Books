using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.Implementation;

namespace BLL
{
    public static class BLLExtension
    {
        public static ILibrairiService GetLibrariService()
        {
            return new LibrairiService();
        }
    }
}
