using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Fast.Core
{
    public interface ILuisService
    {

        bool IsInitialized { get; set; }

        
    
        

        Task StartEvaluationAsync(string specialInstructions);

        


    }

   
}
