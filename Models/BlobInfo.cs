using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage.Blob;

namespace Imbokodo.Models
{
    public class BlobInfo
    {
        public string ImageUri { get; set; }
        public string ThumbnailUri { get; set; }
        public string Caption { get; set; }
        public string Tag0 { get; set; }
        public string Tag1 { get; set; }

        public string Tag2 { get; set; }
        public string Tag3 { get; set; }
        public string Tag4 { get; set; }
        public string Tag5 { get; set; }
        public string Tag6 { get; set; }
        public string Tag7 { get; set; }
        public string Tag8 { get; set; }
        public string Tag9 { get; set; }
        public string Tag10 { get; set; }
        public string Tag11 { get; set; }
        public string Tag12 { get; set; }
        public string Tag13 { get; set; }
        public string Tag14 { get; set; }
        public string Tag15 { get; set; }
        public string Tag16 { get; set; }
        public string Tag17 { get; set; }
        public string Tag18 { get; set; }
        public string Tag19 { get; set; }
        public string Tag20 { get; set; }
        public string Tag21 { get; set; }
        public string Tag22 { get; set; }
        public string Tag23 { get; set; }
        public string Tag24 { get; set; }
        public string Tag26 { get; set; }
        public string Tag25 { get; set; }

        internal CloudBlobContainer GetCloudBlobContainer()
        {
            throw new NotImplementedException();
        }
    }
}
