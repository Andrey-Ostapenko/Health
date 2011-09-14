﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using Health.Core.API;
using Health.Core.Entities.POCO;
using Health.Site.Attributes;

namespace Health.Site.Models
{
    public class TestModel : CoreViewModel
    {
        public Patient Patient { get; set; }

        [AdditionalMetadata("somes", "1")]
        public string Name { get; set; }

        public int Code { get; set; }

        public DateTime Date { get; set; }
        
        public IList<Patient> Enother { get; set; }
    }
}