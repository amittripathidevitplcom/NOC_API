using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RJ_NOC_Model;
using RJ_NOC_Utility;
using Microsoft.AspNetCore.Http;
using System.Net.Http;
using System.IO;
using System.Net.Http.Headers;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.Text;
using System.Data.OleDb;
using RJ_NOC_API.Controllers;
using RJ_NOC_DataAccess.Common;

namespace RJ_NOC_API.Controllers
{
    [Route("api/UploadFile")]
    [ApiController]
    public class UploadFileController : RJ_NOC_ControllerBase
    {
        private IConfiguration _configuration;
        public UploadFileController(IConfiguration configuration) : base(configuration)
        {
            _configuration = configuration;
        }

        // the HTTP post request. The Body size limit is disabled 
        [HttpPost, DisableRequestSizeLimit]
        [ActionName("Upload")]
        public async Task<OperationResult<List<UploadFileDataModel>>> UploadFile()
        {
            var result = new OperationResult<List<UploadFileDataModel>>();
            try
            {
                var postedFile = Request.Form.Files[0];
                if (CheckIfMP3File(postedFile))
                {
                    var size = postedFile.Length;
                    if (size > (10 * 1024 * 1024))
                    {
                        result.State = OperationState.Warning;
                        result.ErrorMessage = "File size is bigger than 10MB.!";
                    }
                    // 2. set the file uploaded folder
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "ImageFile");
                    // 3. check for the file length, if it is more than 0 the save it
                    if (postedFile.Length > 0)
                    {
                        // 3a. read the file name of the received file
                        var fileName = ContentDispositionHeaderValue.Parse(postedFile.ContentDisposition).FileName.Trim('"');
                        // 3b. save the file on Path
                        var FileName = System.DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + fileName;

                        List<UploadFileDataModel> uploadFileDataModels = new List<UploadFileDataModel>();
                        UploadFileDataModel uploadFileDataModel = new UploadFileDataModel();
                        uploadFileDataModel.FileName = FileName;
                        uploadFileDataModels.Add(uploadFileDataModel);
                        result.Data = uploadFileDataModels;


                        var finalPath = Path.Combine(uploadFolder, FileName);
                        using (var fileStream = new FileStream(finalPath, FileMode.Create))
                        {
                            postedFile.CopyTo(fileStream);
                        }
                        result.State = OperationState.Success;
                        result.SuccessMessage = "File is uploaded Successfully.!";
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.ErrorMessage = "The File is not received.!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Invalid file extension, Only allow .mp3 file.!";
                }

            }
            catch (Exception ex)
            {
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        private bool CheckIfMP3File(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            return (extension == ".mp3" || extension.ToUpper() == ".MP3"); // Change the extension based on your need
        }
        ////////Upload Images
        // the HTTP post request. The Body size limit is disabled 
        [HttpPost("ImageFile"), DisableRequestSizeLimit]
        [ActionName("UploadImage")]
        public async Task<OperationResult<List<UploadFileDataModel>>> UploadImage()
        {
            var result = new OperationResult<List<UploadFileDataModel>>();
            try
            {
                var postedFile = Request.Form.Files[0];
                if (CheckIfImageFile(postedFile))
                {
                    var size = postedFile.Length;
                    if (size > (1 * 1024 * 1024))
                    {
                        result.State = OperationState.Warning;
                        result.ErrorMessage = "File size is bigger than 1 MB.!";
                    }
                    // 2. set the file uploaded folder
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "ImageFile");
                    // 3. check for the file length, if it is more than 0 the save it
                    if (postedFile.Length > 0)
                    {
                        // 3a. read the file name of the received file
                        var fileName = ContentDispositionHeaderValue.Parse(postedFile.ContentDisposition).FileName.Trim('"');
                        // 3b. save the file on Path
                        var FileName = System.DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + fileName;
                        var FileNameSave = System.DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + "-" + fileName;

                        List<UploadFileDataModel> uploadFileDataModels = new List<UploadFileDataModel>();
                        UploadFileDataModel uploadFileDataModel = new UploadFileDataModel();
                        uploadFileDataModel.FileName = FileNameSave;
                        uploadFileDataModels.Add(uploadFileDataModel);
                        result.Data = uploadFileDataModels;



                        var finalPath = Path.Combine(uploadFolder, FileName);
                        var finalPathSave = Path.Combine(uploadFolder, FileNameSave);
                        using (var fileStream = new FileStream(finalPath, FileMode.Create))
                        {
                            postedFile.CopyTo(fileStream);
                        }

                        using (FileStream pngStream = new FileStream(finalPath, FileMode.OpenOrCreate))
                        {
                            ResizeImage(pngStream, finalPathSave);
                        }

                        result.State = OperationState.Success;
                        result.SuccessMessage = "File is uploaded Successfully.!";
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.ErrorMessage = "The File is not received.!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    result.ErrorMessage = "Invalid file extension, Only allow .bmp, .jpg, .jpeg, .gif, .png file.!";
                }

            }
            catch (Exception ex)
            {
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }
        ////////Upload Images
        // the HTTP post request. The Body size limit is disabled 


        [HttpPost("UploadDocument"), DisableRequestSizeLimit]
        [ActionName("UploadDocument")]
        public async Task<OperationResult<List<UploadFileWithPathDataModel>>> UploadDocument()
        {
            var result = new OperationResult<List<UploadFileWithPathDataModel>>();
            try
            {
                var postedFile = Request.Form.Files[0];
                if (CheckIfImageWithPDFFile(postedFile))
                {
                    var size = postedFile.Length;
                    if (size > (1 * 1024 * 1024))
                    {
                        result.State = OperationState.Warning;
                        result.ErrorMessage = "File size is bigger than 1 MB.!";
                    }
                    // 2. set the file uploaded folder
                    var uploadFolder = Path.Combine(Directory.GetCurrentDirectory(), "ImageFile");
                    // 3. check for the file length, if it is more than 0 the save it
                    if (postedFile.Length > 0)
                    {
                        // 3a. read the file name of the received file
                        var fileName = ContentDispositionHeaderValue.Parse(postedFile.ContentDisposition).FileName.Trim('"');
                        // 3b. save the file on Path
                        var FileName = System.DateTime.Now.ToString("ddMMMyyyyhhmmsstt") + fileName;
                        var finalPathSave = Path.Combine(uploadFolder, FileName);
                        string FilePath = UtilityHelper.CommonFuncationUtility.UploadFilePath() + FileName;

                        List<UploadFileWithPathDataModel> uploadFileDataModels = new List<UploadFileWithPathDataModel>();
                        UploadFileWithPathDataModel uploadFileDataModel = new UploadFileWithPathDataModel();
                        uploadFileDataModel.Dis_FileName = fileName;
                        uploadFileDataModel.FileName = FileName;
                        uploadFileDataModel.FilePath = FilePath;
                        uploadFileDataModels.Add(uploadFileDataModel);
                        result.Data = uploadFileDataModels;



                        var finalPath = Path.Combine(uploadFolder, FileName);
                        using (var fileStream = new FileStream(finalPath, FileMode.Create))
                        {
                            postedFile.CopyTo(fileStream);
                        }

                        using (FileStream pngStream = new FileStream(finalPath, FileMode.OpenOrCreate))
                        {
                            ResizeImage(pngStream, finalPathSave);
                        }

                        result.State = OperationState.Success;
                        result.SuccessMessage = "File is uploaded Successfully.!";
                    }
                    else
                    {
                        result.State = OperationState.Error;
                        result.ErrorMessage = "The File is not received.!";
                    }
                }
                else
                {
                    result.State = OperationState.Error;
                    //result.ErrorMessage = "Invalid file extension, Only allow .bmp, .jpg, .jpeg, .gif, .png, .pdf, .xlsx, .xls file.!";
                    result.ErrorMessage = "Invalid file extension, Only allow .bmp, .jpg, .jpeg, .gif, .png, .pdf file.!";
                }

            }
            catch (Exception ex)
            {
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message;
            }
            return result;
        }

        private bool CheckIfImageFile(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            return (extension.ToLower() == ".bmp" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif" || extension.ToLower() == ".png"); // Change the extension based on your need
        } 
        private bool CheckIfImageWithPDFFile(IFormFile file)
        {
            var extension = "." + file.FileName.Split('.')[file.FileName.Split('.').Length - 1];
            //return (extension.ToLower() == ".pdf" || extension.ToLower() == ".bmp" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif" || extension.ToLower() == ".png"|| extension.ToLower() == ".xlsx" || extension.ToLower() == ".xls"); // Change the extension based on your need .xlsx, .xls
            return (extension.ToLower() == ".pdf" || extension.ToLower() == ".bmp" || extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".gif" || extension.ToLower() == ".png"); // Change the extension based on your need .xlsx, .xls
        }
        public static void ResizeImage(Stream sourcePath, string targetPath, int width, int height)
        {
            try
            {
                var image = System.Drawing.Image.FromStream(sourcePath);
                // Dim width = CInt((image.Width))
                // Dim height = CInt((image.Height))
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                var thumbGraph = Graphics.FromImage(destImage);
                thumbGraph.CompositingMode = CompositingMode.SourceCopy;
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                var wrapMode = new ImageAttributes();
                wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                thumbGraph.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                // Dim ms As MemoryStream = New MemoryStream()
                destImage.Save(targetPath, ImageFormat.Jpeg);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        public static void ResizeImage(Stream sourcePath, string targetPath)
        {
            try
            {
                var image = System.Drawing.Image.FromStream(sourcePath);
                int width = Convert.ToInt32((image.Width));
                int height = Convert.ToInt32((image.Height));
                var destRect = new Rectangle(0, 0, width, height);
                var destImage = new Bitmap(width, height);
                destImage.SetResolution(image.HorizontalResolution, image.VerticalResolution);
                var thumbGraph = Graphics.FromImage(destImage);
                thumbGraph.CompositingMode = CompositingMode.SourceCopy;
                thumbGraph.CompositingQuality = CompositingQuality.HighQuality;
                thumbGraph.InterpolationMode = InterpolationMode.HighQualityBicubic;
                thumbGraph.SmoothingMode = SmoothingMode.HighQuality;
                thumbGraph.PixelOffsetMode = PixelOffsetMode.HighQuality;
                var wrapMode = new ImageAttributes();
                wrapMode.SetWrapMode(System.Drawing.Drawing2D.WrapMode.TileFlipXY);
                thumbGraph.DrawImage(image, destRect, 0, 0, image.Width, image.Height, GraphicsUnit.Pixel, wrapMode);
                // Dim ms As MemoryStream = New MemoryStream()
                destImage.Save(targetPath, ImageFormat.Jpeg);
                // Return ms.ToArray()
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }

        }

        [HttpPost("DeleteDocument")]
        public async Task<OperationResult<bool>> DeleteDocument([FromBody] string path)
        {
            var result = new OperationResult<bool>();
            try
            {
                result.Data = await Task.Run(() =>
                {
                    if (string.IsNullOrWhiteSpace(path))
                    {
                        return false;
                    }
                    var arr = path.Split("/");
                    var filePath = Path.Combine(Path.GetFullPath("ImageFile"), arr[arr.Length - 1]);
                    if (!System.IO.File.Exists(filePath))
                    {
                        return false;
                    }
                    System.IO.File.Delete(filePath);
                    return true;
                });
                if (result.Data)
                {
                    result.State = OperationState.Success;
                    result.SuccessMessage = "Deleted successfully .!";
                }
                else
                {
                    result.State = OperationState.Warning;
                    result.ErrorMessage = "No file found.!";
                }
            }
            catch (Exception ex)
            {
                CommonDataAccessHelper.Insert_ErrorLog("UploadFile.DeleteDocument", ex.ToString());
                result.State = OperationState.Error;
                result.ErrorMessage = ex.Message.ToString();
            }
            finally
            {
                // UnitOfWork.Dispose();
            }
            return result;
        }

    }
}


