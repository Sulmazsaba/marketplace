﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Marketplace.Contracts;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Serilog;
using Sparrow.Logging;
using static Marketplace.Contracts.ClassifiedAds;
namespace Marketplace.Api
{
    [Route("/ad")]
    public class ClassifiedAdsCommandsApi : Controller
    {
        private readonly ClassifiedAdsApplicationService _applicationService;

        public ClassifiedAdsCommandsApi(ClassifiedAdsApplicationService applicationService)
        {
            _applicationService = applicationService;
        }

        [HttpPost]
        public async Task<IActionResult> Post(V1.Create request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("name")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.SetTitle request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("text")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.UpdateText request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("price")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.UpdatePrice request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        [Route("publish")]
        [HttpPut]
        public async Task<IActionResult> Put(V1.RequestToPublish request)
        {
            await _applicationService.Handle(request);
            return Ok();
        }

        private async Task<IActionResult> HandleRequest<T>(T request, Func<T, Task> handler)
        {
            try
            {
                Log.Debug("Handling Request of Type :{type}",typeof(T).Name);
                await handler(request);
                return Ok();
            }
            catch (Exception e)
            {
                Log.Error("Error Handling the request",e);
                return new BadRequestObjectResult(new {error = e.Message, stackTrace = e.StackTrace});
            }
        }

    }
}
