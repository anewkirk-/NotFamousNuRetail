using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.IO;
using System.Net;
using System.Threading.Tasks;

namespace NuRetail_NotFamous.Controllers
{
    public class ImageFetcher
    {
        public Image FetchImage(string url)
        {
            using (WebClient client = new WebClient())
            {
                return BytesToImage(client.DownloadData(url));
            }
        }

        private Image BytesToImage(byte[] bytes)
        {
            using (MemoryStream ms = new MemoryStream(bytes))
            {
                return Image.FromStream(ms);
            }

        }

    }
}
