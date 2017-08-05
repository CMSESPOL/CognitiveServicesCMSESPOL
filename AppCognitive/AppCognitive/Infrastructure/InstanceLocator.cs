using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppCognitive.Infrastructure
{
    public class InstanceLocator
    {
        public InstanceLocator()
        {
            Main = new ViewModel.CognitiveVM();
        }
        public ViewModel.CognitiveVM Main { get; set; }
    }
}
