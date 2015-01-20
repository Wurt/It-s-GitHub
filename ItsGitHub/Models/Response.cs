using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItsGitHub.Models
{
   public class Response
    {
        public int ID { get; set; }
        public string Content { get; set; }
        public int AssignmentId { get; set; }
               public DateTime DateCreatedForResp
        {
            get
            {
                return this.dateCreated.HasValue
                   ? this.dateCreated.Value
                   : DateTime.Now;
            }

            set { this.dateCreated = value; }
        }

        private DateTime? dateCreated = null;
    }

    }

