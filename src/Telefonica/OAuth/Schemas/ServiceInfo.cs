using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bluevia.OAuth.Schemas
{
    public class ServiceInfo
    {
        private string nameField;

        private string serviceIDField;

        private string descriptionField;

        public string name
        {
            get
            {
                return this.nameField;
            }
            set
            {
                this.nameField = value;
            }
        }

        public string serviceID
        {
            get
            {
                return this.serviceIDField;
            }
            set
            {
                this.serviceIDField = value;
            }
        }

        public string description
        {
            get
            {
                return this.descriptionField;
            }
            set
            {
                this.descriptionField = value;
            }
        }
    }
}
