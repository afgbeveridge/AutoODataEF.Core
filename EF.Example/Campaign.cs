using API.Generation.Support;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Example {

    public class Campaign {

        public int CampaignId { get; set; }

        public decimal Cost { get; set; }

        [ApiExposedResourceProperty]
        public DateTime? RunDate { get; set; }

    }

}
