using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ImageResizer;
using Imbokodo.Models;

using Microsoft.WindowsAzure.Storage;
using Microsoft.WindowsAzure.Storage.Blob;
using System.Configuration;
using System.Threading.Tasks;
using System.IO;
using Microsoft.ProjectOxford.Vision;

namespace Imbokodo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Home()
        {
            return View();
        }

        public ActionResult Index()
        {
            // Pass a list of blob URIs in ViewBag
            CloudStorageAccount account = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("photos");
            List<BlobInfo> blobs = new List<BlobInfo>();
            BlobInfo blobinfo = new BlobInfo();

            foreach (IListBlobItem item in container.ListBlobs())
            {
                var blob = item as CloudBlockBlob;

                if (blob != null)
                {
                    blob.FetchAttributes(); // Get blob metadata
                    var caption = blob.Metadata.ContainsKey("Caption") ? blob.Metadata["Caption"] : blob.Name;
                    var tag0 = blob.Metadata.ContainsKey("Tag0") ? blob.Metadata["Tag0"] : blob.Name;
                    var tag1 = blob.Metadata.ContainsKey("Tag1") ? blob.Metadata["Tag1"] : blob.Name;
                    var tag2 = blob.Metadata.ContainsKey("Tag2") ? blob.Metadata["Tag2"] : blob.Name;
                    var tag3 = blob.Metadata.ContainsKey("Tag3") ? blob.Metadata["Tag3"] : blob.Name;
                    var tag4 = blob.Metadata.ContainsKey("Tag4") ? blob.Metadata["Tag4"] : blob.Name;
                    var tag5 = blob.Metadata.ContainsKey("Tag5") ? blob.Metadata["Tag5"] : blob.Name;
                    var tag6 = blob.Metadata.ContainsKey("Tag6") ? blob.Metadata["Tag6"] : blob.Name;
                    var tag7 = blob.Metadata.ContainsKey("Tag7") ? blob.Metadata["Tag7"] : blob.Name;
                    var tag8 = blob.Metadata.ContainsKey("Tag8") ? blob.Metadata["Tag8"] : blob.Name;
                    var tag9 = blob.Metadata.ContainsKey("Tag9") ? blob.Metadata["Tag9"] : blob.Name;
                    var tag10 = blob.Metadata.ContainsKey("Tag10") ? blob.Metadata["Tag10"] : blob.Name;
                    var tag11 = blob.Metadata.ContainsKey("Tag11") ? blob.Metadata["Tag11"] : blob.Name;
                    var tag12 = blob.Metadata.ContainsKey("Tag12") ? blob.Metadata["Tag12"] : blob.Name;
                    var tag13 = blob.Metadata.ContainsKey("Tag13") ? blob.Metadata["Tag13"] : blob.Name;
                    var tag14 = blob.Metadata.ContainsKey("Tag14") ? blob.Metadata["Tag14"] : blob.Name;
                    var tag15 = blob.Metadata.ContainsKey("Tag15") ? blob.Metadata["Tag15"] : blob.Name;
                    var tag16 = blob.Metadata.ContainsKey("Tag16") ? blob.Metadata["Tag16"] : blob.Name; 
                    var tag17 = blob.Metadata.ContainsKey("Tag17") ? blob.Metadata["Tag17"] : blob.Name;
                    var tag18 = blob.Metadata.ContainsKey("Tag18") ? blob.Metadata["Tag18"] : blob.Name;
                    var tag19 = blob.Metadata.ContainsKey("Tag19") ? blob.Metadata["Tag19"] : blob.Name;
                    var tag20 = blob.Metadata.ContainsKey("Tag20") ? blob.Metadata["Tag20"] : blob.Name;
                    var tag21 = blob.Metadata.ContainsKey("Tag21") ? blob.Metadata["Tag21"] : blob.Name;
                    var tag22 = blob.Metadata.ContainsKey("Tag22") ? blob.Metadata["Tag22"] : blob.Name;
                    var tag23 = blob.Metadata.ContainsKey("Tag23") ? blob.Metadata["Tag23"] : blob.Name;
                    var tag24 = blob.Metadata.ContainsKey("Tag24") ? blob.Metadata["Tag24"] : blob.Name;
                    var tag25 = blob.Metadata.ContainsKey("Tag25") ? blob.Metadata["Tag25"] : blob.Name;



                    blobs.Add(new BlobInfo()
                    {
                        ImageUri = blob.Uri.ToString(),
                        ThumbnailUri = blob.Uri.ToString().Replace("/photos/", "/thumbnails/"),
                        //Caption = caption
                        Caption = caption,
                        Tag0 = tag0,
                         Tag1 = tag1,
                          Tag2 = tag2,
                          Tag3 = tag3,
                          Tag4 = tag4,
                          Tag5 = tag5,
                          Tag6 = tag6,
                          Tag7 = tag7,
                          Tag8 = tag8,
                          Tag9 = tag9,
                          Tag10 = tag10, 
                          Tag11 = tag11,
                          Tag12 = tag12,
                          Tag13 = tag13,
                          Tag14 = tag14,
                          Tag15 = tag15,
                          Tag16 = tag16,
                          Tag17 = tag17,
                          Tag18 = tag18,
                          Tag19 = tag19,
                          Tag20 = tag20,
                          Tag21 = tag21,
                          Tag22 = tag22,
                          Tag23 = tag23,
                          Tag24 = tag24,
                          Tag25 = tag24
                    });
                }
            }

            ViewBag.Blobs = blobs.ToArray();
            return View();
        }



        public ActionResult getPropeties(string name)
        {
            Uri uri = new Uri(name);
            CloudStorageAccount account = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
            CloudBlobClient client = account.CreateCloudBlobClient();
            CloudBlobContainer container = client.GetContainerReference("photos");
            string filename = System.IO.Path.GetFileName(uri.LocalPath);

            var blob = container.GetBlockBlobReference(filename);
            String URL = blob.Uri.AbsolutePath.ToString();

            blob.FetchAttributes();
            ViewBag.URL = uri.ToString();
            ViewBag.blobname = blob.Name;
            ViewBag.Legnth = blob.Properties.Length;
            ViewBag.BlobType = blob.BlobType;
            ViewBag.ETag = blob.Properties.ETag;
            ViewBag.Created = blob.Properties.Created;
            ViewBag.LastModified = blob.Properties.LastModified;
            
          
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpPost]
        public string DeleteImg(string Name)
        {
            BlobInfo blobing = new BlobInfo();
            Uri uri = new Uri(Name);
            string filename = System.IO.Path.GetFileName(uri.LocalPath);
            CloudBlobContainer blobContainer = blobing.GetCloudBlobContainer();
            CloudBlockBlob blob = blobContainer.GetBlockBlobReference(filename);
            blob.Delete();

            return "File Successfully Deleted";
        }



        [HttpPost]
        [OutputCache(Duration=3)]
        public async Task<ActionResult> Upload(HttpPostedFileBase file)
        {
            if (file != null && file.ContentLength > 0)
            {
                // Make sure the user selected an image file
                if (!file.ContentType.StartsWith("image"))
                {
                    TempData["Message"] = "Only image files may be uploaded";
                }
                else
                {
                    try
                    {
                        // Save the original image in the "photos" container
                        CloudStorageAccount account = CloudStorageAccount.Parse(ConfigurationManager.AppSettings["StorageConnectionString"]);
                        CloudBlobClient client = account.CreateCloudBlobClient();
                        CloudBlobContainer container = client.GetContainerReference("photos");
                        CloudBlockBlob photo = container.GetBlockBlobReference(Path.GetFileName(file.FileName));
                        await photo.UploadFromStreamAsync(file.InputStream);

                        // Generate a thumbnail and save it in the "thumbnails" container
                        using (var outputStream = new MemoryStream())
                        {
                            file.InputStream.Seek(0L, SeekOrigin.Begin);
                            var settings = new ResizeSettings { MaxWidth = 192 };
                            ImageBuilder.Current.Build(file.InputStream, outputStream, settings);
                            outputStream.Seek(0L, SeekOrigin.Begin);
                            container = client.GetContainerReference("thumbnails");
                            CloudBlockBlob thumbnail = container.GetBlockBlobReference(Path.GetFileName(file.FileName));
                            await thumbnail.UploadFromStreamAsync(outputStream);
                            // Submit the image to Azure's Computer Vision API
                            VisionServiceClient vision = new VisionServiceClient(
                            ConfigurationManager.AppSettings["SubscriptionKey"],
                              ConfigurationManager.AppSettings["VisionEndpoint"]
                            );

                            VisualFeature[] features = new VisualFeature[] { VisualFeature.Description, VisualFeature.Tags };
                            var result = await vision.AnalyzeImageAsync(photo.Uri.ToString(), features);

                            // Record the image description and tags in blob metadata
                            photo.Metadata.Add("Caption", result.Description.Captions[0].Text);
              

                            for (int i = 0; i < result.Description.Tags.Length; i++)
                            {
                                string key = String.Format("Tag{0}", i);
                                photo.Metadata.Add(key, result.Description.Tags[i]);
                            }

                            await photo.SetMetadataAsync();
                        }
                    }
                    catch (Exception ex)
                    {
                        // In case something goes wrong
                        TempData["Message"] = ex.Message;
                    }
                }

            }

            return RedirectToAction("Index");
           
        }

    }
}
