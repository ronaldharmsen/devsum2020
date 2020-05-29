using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dapr;
using Dapr.Client;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace hello_dotnet.Controllers
{
    [ApiController]
    public class StateController : ControllerBase
    {
        // "statestore" is the build-in redis if you run outside k8s
        const string StateStore = "statestore";
        const string StateKey = "sample";

        [Topic("test")]
        [HttpGet("test")]
        public async Task<ActionResult<int>> Test([FromServices] DaprClient stateClient)
        {
            var state = await stateClient.GetStateEntryAsync<int?>(StateStore, StateKey);
            state.Value ??= (int?)0;
            state.Value += 1;
            await state.SaveAsync();

            return state.Value;
        }
    }
}