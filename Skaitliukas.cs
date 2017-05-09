using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Configuration;

namespace Skaitliukai_astrus
{
    class Skaitliukas
    {
        private string path_imageFull;
        private string path_imageCropped = null;
        private string fileName;
        private string fileType;
        private int type_id;    // 0 - dujų, 1 - elektros
        private string number;
        private string username;

        public Skaitliukas (string path, int type)
        {         
            fileName = Path.GetFileNameWithoutExtension(path);
            fileType = Path.GetExtension(path);
            type_id = type;
            username = "Naudotojas";
            path_imageFull = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["ImagesFolder"]), fileName + fileType);
            File.Copy(path, path_imageFull, true);
        }

        //GET, SET
        public string FullImagePath
        {
            get
            {
                return path_imageFull;
            }
        }

        public string CroppedImagePath
        {
            get
            {
                if (path_imageCropped == null)
                    path_imageCropped = Path.Combine(Path.Combine(Directory.GetCurrentDirectory(), ConfigurationManager.AppSettings["CroppedImagesFolder"]), fileName + fileType);
                return path_imageCropped;
            }
        }

        public int TypeId
        {
            get
            {
                return type_id;
            }
        }

        public string Number
        {
            get
            {
                return number;
            }
            set
            {
                number = value;
            }
        }

        public string Username
        {
            get
            {
                return username;
            }
        }
    }
}
