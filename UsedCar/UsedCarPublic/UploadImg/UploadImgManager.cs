using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsedCarPublic.UploadImg
{
    public class UploadImgManager
    {
        private static IUploadService upload;


        public static IUploadService GetUploadInstance()
        {
            if (PublicMethods.GetAppSettings("UploadTransport") == "TCP")
                upload = new UploadTcpServiceImpl();
            else
                upload = new UploadTcpServiceImpl();

            return upload;
        }
    }
}
