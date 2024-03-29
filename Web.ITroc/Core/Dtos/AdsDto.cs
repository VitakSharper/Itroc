﻿using System.Collections.Generic;

namespace Web.ITroc.Core.Dtos
{
    public class AdsDto
    {
        public int Id { get; set; }
        public string AdTitle { get; set; }
        public string AdDescription { get; set; }
        public string AdCreate { get; set; }
        public string AdAdresse { get; set; }
        public CategoryDto Category { get; set; }
        public CodepostalDto Codepostal { get; set; }
        public ApplicationUserDto User { get; set; }
        public List<string> Images { get; set; }
    }
}