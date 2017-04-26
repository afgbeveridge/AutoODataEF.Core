using System;
using System.Collections.Generic;
using System.Text;

namespace API.Generation.Discovery {

    public class ApiModel {

        public ApiModel(IEnumerable<ControllerModel> controllers) {
            Controllers = controllers;
        }

        public IEnumerable<ControllerModel> Controllers { get; }

    }

}
