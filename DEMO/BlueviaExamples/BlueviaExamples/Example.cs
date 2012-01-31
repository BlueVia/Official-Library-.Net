using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Bluevia;
using Bluevia.Core;
using Bluevia.Core.Schemas;


namespace BlueviaExamples
{

    interface Example
    {
        string getDescription();
        void call();
    }
}