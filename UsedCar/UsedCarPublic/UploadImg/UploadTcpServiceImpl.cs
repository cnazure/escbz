using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UploadProxy;

namespace UsedCarPublic.UploadImg
{
    public class UploadTcpServiceImpl : IUploadService
    {
        public bool UploadFile(byte[] fs, string fileName, string path)
        {
            MemoryStream mem = new MemoryStream(fs);

            Proxy proxy = UploadProxy.Proxy.Instance();

            proxy.UpLoadFile(fileName, path, mem);

            return true;
        }
    }
}
