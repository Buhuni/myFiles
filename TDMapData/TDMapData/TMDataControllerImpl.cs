using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace TDMapData
{
    [ServiceBehavior(ConcurrencyMode=ConcurrencyMode.Multiple, UseSynchronizationContext = false)]
 
    internal class TMDataControllerImpl : ITMDataController
    {
        TMDataControllerImpl()
        {
            System.Console.WriteLine("Client Connected !!!");
        }

        ~TMDataControllerImpl() {
            System.Console.WriteLine("Client Disconnected !!!");
        }

        public int GetNumTilesAcross(int zoom)
        {

            int numTilesX = 0;

            int numTilesY = 0;

            TMDLLWrapper.GetNumTiles(zoom, out numTilesX, out numTilesY);

            return (numTilesY * numTilesX);

        }

        public int GetNumTilesDown(int zoom)
        {
            int numTilesX = 0;

            int numTilesY = 0;

            TMDLLWrapper.GetTileSize(out numTilesX, out numTilesY);

            return numTilesY;

        }

        public int GetTileHeight()
        {
            int numTilesX = 0;

            int numTilesY = 0;

            TMDLLWrapper.GetTileSize(out numTilesX, out numTilesY);

            return numTilesX;
        }

        public int GetTileWidth()
        {
            int numTilesX = 0;

            int numTilesY = 0;

            TMDLLWrapper.GetTileSize(out numTilesX, out numTilesY);

            return numTilesY;
        }

        public byte[] LoadTile(int zoom, int x, int y)
        {
            int sizeX = 0;

            int sizeY = 0;

            TMDLLWrapper.GetTileSize(out sizeX, out sizeY);

            int charBuffferSize = (sizeX * sizeY * 3);

            byte[] imageData = new byte[charBuffferSize];

            int jpgSize = 0;

            int tileX = 0;

            int tileY = 0;

            TMDLLWrapper.GetTileImageAsRawJPG(zoom, tileX, tileY, imageData, charBuffferSize, out jpgSize);

            return imageData;

        }

    }
}
