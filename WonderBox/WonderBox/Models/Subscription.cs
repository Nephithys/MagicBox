using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WonderBox.Models
{
    public class Subscription
    {
        public int ID { get; set; }

        public string User { get; set; }

        public string SubscriptionName { get; set; }

        public int Cost { get; set; }
    }
}