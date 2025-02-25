﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepairShop.Application.DTOs
{

    public class DocumentDTO
    {
        public DocumentType? TypeId { get; set; }
        public string Value { get; set; }

    }

    public enum DocumentType
    {
        None = 0,
        [Display(Name = "CPF")]
        CPF = 1,
        [Display(Name = "CNPJ")]
        CNPJ = 2,
        [Display(Name = "RG")]
        RG = 3,
        [Display(Name = "Passaporte")]
        Passport = 4
    }

}
