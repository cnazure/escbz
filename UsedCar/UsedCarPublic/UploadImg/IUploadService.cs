using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UsedCarPublic.UploadImg
{
    public interface IUploadService
    {
        bool UploadFile(byte[] fs, string fileName, string path);
    }
}
