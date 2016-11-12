using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tweeter.Models
{
    public class Twit
    {
        public int TwitId { get; set; }

        //The ApplicationUser reference lets us personalize our own parent model (Twit) since we can't change the ApplicationUser property that is built in to the Authentication of .Net.
        public ApplicationUser BaseUser { get; set; }
        public List<Twit> Follows { get; set; }
    }
}