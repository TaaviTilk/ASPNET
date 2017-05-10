using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Domain
{
    public class Contact
    {
        public int ContactId { get; set; }

        [MaxLength(128)]
        public string ContactValue { get; set; }
    }
}
