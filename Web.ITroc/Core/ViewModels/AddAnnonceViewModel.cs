using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using Web.ITroc.Core.Models;

namespace Web.ITroc.Core.ViewModels
{
    public class AddAnnonceViewModel
    {
        public AddAnnonceViewModel()
        {
            Categories = new List<Category>();
            Files = new List<HttpPostedFileBase>();
        }
        [Required(ErrorMessage = "*")]
        [Display(Name = "Titre de votre annonce")]
        public string AdTitle { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Description de votre annonce")]
        public string AdDescription { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Saisissez une adresse")]
        public string Adresse { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "CP")]
        public string CodePostal { get; set; }

        [Required(ErrorMessage = "*")]
        [Display(Name = "Ville")]
        public string Ville { get; set; }

        //[Required(ErrorMessage = "*")]
        [Display(Name = "Ajoutez une photo")]
        public List<HttpPostedFileBase> Files { get; set; }


        [Required(ErrorMessage = "*")]
        [Display(Name = "Choisissez une catégorie")]
        public int Category { get; set; }

        public string ErrorMess { get; set; }


        public string[] Base64FileFormat { get; private set; }

        public IEnumerable<Category> Categories { get; set; }


        public string PutFileInDb()
        {
            const int maxContentLength = 1024 * 1024 * 3; //3 mb
            var allowedFileExtensions = new string[] { ".jpg", ".gif", ".png" };
            Base64FileFormat = new string[Files.Count];
            if (Base64FileFormat.Length == 0 || Base64FileFormat.Length > 4)
            {
                ErrorMess = "Veuillez Inserer une image. Maximum image authorisé de quatre.";
                return "Nok";
            }

            foreach (HttpPostedFileBase file in Files)
            {
                if (!file.FileName.Contains(".") || !allowedFileExtensions.Contains((file.FileName.Substring(file.FileName.LastIndexOf('.'))).ToLower()))
                {
                    ErrorMess = "S'il vous plaît choisissez un fichier de type : " + string.Join(", ", allowedFileExtensions);
                    return "Nok";
                }

                if (file.ContentLength > maxContentLength)
                {
                    ErrorMess = "Votre fichier est trop volumineux, la taille maximale autorisée est : " + maxContentLength + " MB";
                    return "Nok";
                }

                //byte[] uploadedFile = new byte[file.InputStream.Length];
                //file.InputStream.Read(uploadedFile, 0, uploadedFile.Length);
                Base64FileFormat[Files.IndexOf(file)] = ResizeImage(file);
            }
            return "Ok";
        }

        private string ResizeImage(HttpPostedFileBase file)
        {
            WebImage img = new WebImage(file.InputStream);
            if (img.Width > 500)
                img.Resize(500, 500);
            byte[] uploadedFile = img.GetBytes();
            var tf = Convert.ToBase64String(uploadedFile);
            return tf;
        }
    }
}