using System;
using System.Collections.Generic;

namespace Fast.Core
{

public class FocusResult {

public string Title {get; set; }

public double ConfidenceLevel {get; set; }

public string AnimationUrl {get; set; }

public string AlertMessage {get; set; }

public string Color {get; set; }

public List<Instruction> Instructions {get; set; }

public ConsultParameters ConsultParameter {get; set; }



}


}